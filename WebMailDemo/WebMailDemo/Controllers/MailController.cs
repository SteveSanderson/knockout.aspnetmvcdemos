using System.Linq;
using System.Web.Mvc;
using WebMailDemo.Models;

namespace WebMailDemo.Controllers
{
    public class MailController : Controller
    {
        private readonly MailDbContext context = new MailDbContext();

        public ActionResult Index()
        {
            // Initially send just the list of folders to the client
            return View(context.MailFolders);
        }

        public JsonResult MailData(string folder) {
            var mails = from mail in context.MailItems
                        where mail.MailFolder.Name == folder
                        orderby mail.Date descending
                        select mail;

            return Json(mails.ToList().Select(mail => new {
                mail.Id,
                mail.From,
                mail.To,
                Date = mail.Date.ToString("MMM dd yyyy, hh:mm"),
                mail.Subject,
                mail.MessageContent                
            }));
        }
    }
}