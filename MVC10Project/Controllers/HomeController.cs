using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MVC10Project.MailKits;
using MVC10Project.Models;
using System.Diagnostics;

namespace MVC10Project.Controllers
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

        public async Task<IActionResult> Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public async Task<IActionResult> SendMail(string name, string email, string msg, string header)
        {
            var message = new MimeMessage();

            string mailBoxSender = "FROMtest@yandex.ru";

            message.From.Add(new MailboxAddress(name, mailBoxSender));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = header;

            message.Body = new TextPart("html")
            {
                Text = "Сообщение от: " + name + " <br>" +
                "С почтового ящика: " + mailBoxSender + "<br>" +
                "Текст сообщения: " + msg
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465);
                await client.AuthenticateAsync(mailBoxSender, "*************");
                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }
            return View("Contact");
        }

        public async Task<IActionResult> SendMessage()
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("TOtext@yandex.ru", "Новое письмо из сервиса", "Текст письма");


            return View("SendMessage");
        }


        public IActionResult Privacy()
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