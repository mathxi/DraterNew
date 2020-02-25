using DraterNew.Models.Class;
using DraterNew.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraterNew.Controllers
{
    public class TagsController : Controller
    {
        // GET: Tags

        [HttpGet]
        [Route("Tags/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Tags/Create")]
        public ActionResult Create(Tags tags)
        {
            if (ModelState.IsValid)
            {
                TagsRequest.Create(tags);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}