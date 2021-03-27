using MyCafe_v1._5.Models;
using MyCafe_v1._5.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCafe_v1._5.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Manager, Employee")]
        public ActionResult Main()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Manager, Employee")]
        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]    
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    //String path = model.Attachment.ToString();
                    //string fileName = model.Attachment.FileName;

                    String fileName = model.FilePath;
                    string filePath = Server.MapPath("~/"+fileName);

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents, filePath, fileName);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }    


        [Authorize]
        public ActionResult Map()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Administrator, Manager, Employee")]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Manager, Employee")]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);

                    string path = Server.MapPath(string.Format("~/{0}", "Uploads"));
                  
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    file.SaveAs(Path.Combine(path, fileName));

                    ViewBag.Message = "File uploaded successfully";
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "File uploaded failed";
                return View(new SendEmailViewModel());
            }

        }

    }
}