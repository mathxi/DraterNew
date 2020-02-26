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
    [Authorize]
    public class RetardAPIController : Controller
    {
        [HttpGet]
        [Route("Api/Retard/{idRetard}")]
        public ActionResult Retard(int idRetard)
        {
            return Json(RetardRequest.getRetard(idRetard), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Route("Api/Retard/getTags")]
        public ActionResult GetTags()
        {
            return Json(TagsRequest.GetTags(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Api/Retards")]
        public ActionResult getAllRetards(List<int> tags)
        {
            ObservableCollection<Retard> listRetard = RetardRequest.GetRetards(Convert.ToInt32(User.Identity.Name),tags);
            return Json(listRetard, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Api/TopXRetards")]
        public ActionResult getTopXRetards(int nbRetard)
        {
            List<TopXRetard> listTop100Retard = RetardRequest.GetTopX(Convert.ToInt32(User.Identity.Name), 100);
            ObservableCollection<Retard> listRetard = new ObservableCollection<Retard>();
            foreach( TopXRetard element in listTop100Retard)
            {
                Retard retard = new Retard(element.id, element.titre, element.description, element.file, Convert.ToInt32(element.eleve.id), Convert.ToInt32(User.Identity.Name));
                listRetard.Add(retard);
            }
            return Json(listRetard, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Api/Retards/GetByTags")]
        public ActionResult GetRetardsByTags(int nbRetard)
        {
            List<TopXRetard> listTop100Retard = RetardRequest.GetTopX(Convert.ToInt32(User.Identity.Name), 100);
            ObservableCollection<Retard> listRetard = new ObservableCollection<Retard>();
            foreach (TopXRetard element in listTop100Retard)
            {
                Retard retard = new Retard(element.id, element.titre, element.description, element.file, Convert.ToInt32(element.eleve.id), Convert.ToInt32(User.Identity.Name));
                listRetard.Add(retard);
            }
            return Json(listRetard, JsonRequestBehavior.AllowGet);
        }
    }
}