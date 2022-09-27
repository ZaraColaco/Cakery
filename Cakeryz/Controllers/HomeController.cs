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
                mail.From = new MailAddress("contactzcakery@gmail.com");

                //To Email Address - your need to enter your to email address
                mail.To.Add(contactMail.Email);
                mail.To.Add("contactzcakery@gmail.com");

                mail.Subject = contactMail.Name;

                mail.IsBodyHtml = true;

                string content = "Name : " + contactMail.Name;
                content += "<br/> Message : " + contactMail.Message;
                content += "<br/> Email : " + contactMail.Email;

                mail.Body = content;


                //create SMTP instant

                //pass mail server address and specify the port number if required
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                //Create network credential and give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("contactzcakery@gmail.com", "@test123#");
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

        [HttpPost]
        public IActionResult Services(ServicesMail servicesMail)///////////////////////////////////services to be removed 
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress("contactzcakery@gmail.com");

                //To Email Address - your need to enter your to email address
                mail.To.Add(User.Identity.Name);
                mail.To.Add("contactzcakery@gmail.com");

                mail.Subject = servicesMail.Services;

                //you can specify also CC and BCC - i will skip this
                //mail.CC.Add("");
                //mail.Bcc.Add("");

                mail.IsBodyHtml = true;

                string content = "First Name : " + servicesMail.FName;
                content += "<br/> Last Name : " + servicesMail.LName;
                content += "<br/> Services : " + servicesMail.Services;
                content += "<br/> Message : " + servicesMail.Message;


                mail.Body = content;


                //create SMTP instant

                //you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("contactzcakery@gmail.com", "@test123#");
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
            return RedirectToAction("ServicesSubmitted");
        }
    }
}
