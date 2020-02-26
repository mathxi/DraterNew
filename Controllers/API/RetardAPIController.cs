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

        [HttpGet]
        [Route("Api/Top100Retards")]
        public ActionResult getTop100Retards()
        {
            List<Top100Retard> listTop100Retard = RetardRequest.GetTop100(Convert.ToInt32(User.Identity.Name));
            ObservableCollection<Retard> listRetard = new ObservableCollection<Retard>();
            foreach( Top100Retard element in listTop100Retard)
            {
                Retard retard = new Retard(element.id, element.titre, element.description, element.file, Convert.ToInt32(element.eleve.id), Convert.ToInt32(User.Identity.Name));
                listRetard.Add(retard);
            }
            return Json(listRetard, JsonRequestBehavior.AllowGet);
        }
    }
}