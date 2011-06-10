using System.Linq;
using System.Web.Mvc;
using FriendsEditorDemo.Models;

namespace FriendsEditorDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(Person person)
        {
            // Just to show we have actually got the data as .NET objects
            var message = string.Format("Saved {0} {1}", person.FirstName, person.LastName);
            message += string.Format(" with {0} friends", person.Friends.Count);
            message += string.Format(" ({0} on Twitter)", person.Friends.Where(x => x.IsOnTwitter).Count());

            return Json(new { message });
        }
    }
}
