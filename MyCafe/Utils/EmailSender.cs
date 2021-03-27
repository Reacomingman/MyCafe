using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyCafe_v1._5.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, String path, String fileName)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            /**
            var bytes = File.ReadAllBytes(path);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(fileName, file);
         */
       
            var response = client.SendEmailAsync(msg);
        }

    }
}