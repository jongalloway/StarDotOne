using System.Web.Mvc;

namespace StarDotOne.Controllers
{
    [LocaleRoute("hello/{locale}/{action=Index}", "EN-GB")]
    public class ENGController : Controller
    {
        // GET: /hello/en-gb/
        public ActionResult Index()
        {
            return Content("I am the EN-GB controller.");
        }

    }
}
