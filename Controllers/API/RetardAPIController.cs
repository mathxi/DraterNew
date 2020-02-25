using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DraterNew.Models.Request;

namespace DraterNew.Controllers.API
{
    public class RetardAPIController : Controller
    {
        [HttpGet]
        [Route("Api/Retard/{idRetard}")]
        public ActionResult Retard(int idRetard)
        {
            return Json(RetardRequest.getRetard(idRetard), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Api/Retards")]
        public ActionResult getAllRetards()
        {
            return Json(RetardRequest.GetRetards(), JsonRequestBehavior.AllowGet);
        }
    }
}