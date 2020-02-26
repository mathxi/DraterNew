using DraterNew.Models.Class;
using DraterNew.Models.Request;
using DraterNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraterNew.Controllers
{
    [Authorize]
    public class RetardController : Controller
    {
        // GET: Retard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Retard/Create")]
        public ActionResult Create()
        {

            ViewBag.Retards_Tags = new SelectList(TagsRequest.GetTags(), "id", "libelle");
            //ViewBag.Eleve = new SelectList(EleveRequest.GetEleves(), "id", "pseudo");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Retard/Create")]
        public ActionResult Create([Bind(Include = "id,titre,description,Retards_Tags,pj")] Retard retard)
        {
            if (ModelState.IsValid)
            {
                retard.file = Request["fileEnvoie"];
                retard.eleve = EleveRequest.GetEleveById(Int32.Parse(User.Identity.Name));
                RetardRequest.Create(retard);
                retard = RetardRequest.getLastRetard(retard);
                Retards_Tags rt =  new Retards_Tags { Id_Retard = retard.id, Id_Tags = Int32.Parse(Request["Retards_Tags"]) };
                Tags_RetardRequest.Create(rt);


                return RedirectToAction("Index", "Home");
            }


            ViewBag.Retards_Tags = new SelectList(TagsRequest.GetTags(), "id", "libelle");
            //ViewBag.Eleve = new SelectList(EleveRequest.GetEleves(), "id", "pseudo");
            return View();
        }

        [HttpGet]
        [Route("Retard/List")]
        public ActionResult List()
        {

            List<Retard> retards = RetardRequest.getRetardByEleve(Int32.Parse(User.Identity.Name));
            return View(retards);

        }

        [HttpGet]
        [Route("Retard/Edit")]
        public ActionResult Edit(int id)
        {
            ViewBag.Retards_Tags = new SelectList(TagsRequest.GetTags(), "id", "libelle");
            //ViewBag.Eleve = new SelectList(EleveRequest.GetEleves(), "id", "pseudo");
            CreateRetardsVM retard = new CreateRetardsVM(RetardRequest.getRetard(id));
            return View(retard);

        }

        [HttpGet]
        [Route("Retard/Delete")]
        public ActionResult Delete(int id)
        {

            RetardRequest.Delete(id, Int32.Parse(User.Identity.Name));
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [Route("Retard/Edit")]
        public ActionResult Edit(Retard retard)
        {
            if (ModelState.IsValid)
            {
                retard.file = Request["fileEnvoie"];
                retard.eleve = EleveRequest.GetEleveById(Convert.ToInt64(Request["Eleve"]));
                RetardRequest.Update(retard);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Retards_Tags = new SelectList(TagsRequest.GetTags(), "id", "libelle");
            //ViewBag.Eleve = new SelectList(EleveRequest.GetEleves(), "id", "pseudo");
            return View();

        }

    }
}