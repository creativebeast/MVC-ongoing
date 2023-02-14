using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ShowGET")]
        public IActionResult Obrazki(string nazwa)
        {
            ViewData["nazwa"] = nazwa ?? "";
            return View();
        }

        public IActionResult Newsletter(string Imie, string Nazwisko, string Email)
        {           
            ViewData["Imie"] = Imie ?? "";
            ViewData["Nazwisko"] = Nazwisko ?? "";
            ViewData["Email"] = Email ?? "";
            string fromMail = "usuallymissing@gmail.com";
            string fromPassword = "coekybuydthvrtah";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "NEWSLETTER WEB JAK SKLEP";
            
            if (Email != null)
            {
                message.To.Add(new MailAddress(Email));

                message.Body = $"<html><body> GRATULUJEMY \n WŁAŚNIE ZAPISAŁEŚ SIĘ DO NEWSLETTERA \n WEB JAK SKLEP 2023 </body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
            }

            return View();
        }
        public IActionResult Sets()
        {
            return View();
        }
        public IActionResult Singles()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}