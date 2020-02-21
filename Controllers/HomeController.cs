using System.Web.Mvc;

namespace DraterNew.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {

            return View();

        }

    }
}