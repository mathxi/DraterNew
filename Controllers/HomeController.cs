using System.Web.Mvc;

namespace DraterNew.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]

        [Route("")]
        public ActionResult Index()
        {
            
            return View();

        }

    }
}