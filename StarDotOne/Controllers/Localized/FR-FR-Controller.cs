using System.Web.Mvc;

namespace StarDotOne.Controllers
{
    [LocaleRoute("hello/{locale}/{action=Index}", "FR-FR")]
    public class FRFRController : Controller
    {
        // GET: /hello/fr-fr/
        public ActionResult Index()
        {
            return Content("Je suis le contrôleur FR-FR.");
        }

    }
}
