using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCafe_v1._5.Controllers
{
    public class InnovativeController : Controller
    {
        // GET: Innovative
        [Authorize(Roles = "Administrator, Manager, Employee")]
        public ActionResult Index()
        {
            return View();
        }

    }
}