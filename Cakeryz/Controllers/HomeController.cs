using Cakeryz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cakeryz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MudCake()
        {
            return View();
        }
        public IActionResult ContactSubmitted()
        {
            return View();
        }
        public IActionResult privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(ContactMail contactMail)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress("zcakery@outlook.com");

                //To Email Address - your need to enter your to email address
                mail.To.Add(contactMail.Email);
                mail.To.Add("zcakery@outlook.com");

                mail.Subject = contactMail.Name;

                mail.IsBodyHtml = true;

                string content = "Name : " + contactMail.Name;
                content += "<br/> Message : " + contactMail.Message;
                content += "<br/> Email : " + contactMail.Email;

                mail.Body = content;


                //create SMTP instant

                //pass mail server address and specify the port number if required
                SmtpClient smtpClient = new SmtpClient("smtp.outlook.com");

                //Create network credential and give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("zcakery@outlook.com", "@test123#");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 25; // this is default port number - you can also change this
                smtpClient.EnableSsl = true; // if ssl required you need to enable it
                smtpClient.Send(mail);

                ViewBag.Message = "Mail Send";

                // now i need to create the from 
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                //If any error occured it will show
                ViewBag.Message = ex.Message.ToString();
            }
            return RedirectToAction("ContactSubmitted");
        }

        
    }
}
