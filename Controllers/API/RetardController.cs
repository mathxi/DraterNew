using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DraterNew.Models.Request;

namespace DraterNew.Controllers.API
{
    public class RetardController : Controller
    {
        [Route("Api/Retard/{idRetard}")]
        [HttpGet]
        public ActionResult Retard(int idRetard)
        {

            return Json(RetardRequest.getRetard(idRetard), JsonRequestBehavior.AllowGet);
        }

        [Route("Api/Retards")]
        [HttpGet]
        public ActionResult Retards()
        {

            return Json(RetardRequest.GetRetards(), JsonRequestBehavior.AllowGet);
        }

    }
}