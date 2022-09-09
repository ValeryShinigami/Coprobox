using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using coproBox.Models;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;

namespace coproBox.Controllers
{
    public class ContactController : Controller
    {
        private IDal dal;

        public ContactController(IWebHostEnvironment environment)
        {
            this.dal = new Dal();
        }

        //GET
        public ActionResult PageContact()

        {
            return View();
        }

        [HttpPost]
        public ActionResult PageContact(coproBox.Models.Gmail model)

        {
           
            MailMessage message = new MailMessage("contact.coprobox@gmail.com", "myriam.sorhaindo@gmail.com"); //DE c'est le 1er paramètre

            message.Subject = model.Sujet;
            message.Body = model.Body+"\n"+model.De;
            message.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //smtp du client
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("contact.coprobox@gmail.com", "msktkejyzfjrmanp");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(message);
           // ViewBag.Message = "Mail envoyé avec succès!";
            return View();
        }
    }
}