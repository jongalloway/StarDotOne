using System.Web.Mvc;

namespace StarDotOne.Controllers
{
    [LocaleRoute("hello/{locale}/{action=Index}", "EN-US")]
    public class ENUSController : Controller
    {
        // GET: /hello/
        public ActionResult Index()
        {
            return Content("I am the EN-US controller.");
        }

    }
}
