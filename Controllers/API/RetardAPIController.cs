using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DraterNew.Models.Class;
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
            ObservableCollection<Retard> listRetard = RetardRequest.GetRetards(Convert.ToInt32(User.Identity.Name));
            return Json(listRetard, JsonRequestBehavior.AllowGet);
        }
    }
}