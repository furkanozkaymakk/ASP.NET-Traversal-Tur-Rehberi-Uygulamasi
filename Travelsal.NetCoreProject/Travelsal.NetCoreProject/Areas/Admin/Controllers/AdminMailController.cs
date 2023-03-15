using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Travelsal.NetCoreProject.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(mailRequest.Name, mailRequest.SenderMail);
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;
            //mimeMessage.Body = mailRequest.Body;

            SmtpClient client= new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
