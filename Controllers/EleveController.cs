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
    public class EleveController : Controller
    {
        [AllowAnonymous]
        // GET: Eleve
        [HttpGet]
        [Route("Eleve/Create")]
        public ActionResult Create()
        {
            ViewBag.Classe = new SelectList(ClasseRequest.GetAllClasses(), "Id", "Libelle");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Eleve/Create")]
        public ActionResult Create([Bind(Include = "id,pseudo,mail,mdp,idClasse, Photo_Profile")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                eleve.idClasse = ClasseRequest.GetClasse(Int64.Parse(Request["Classe"]));
                eleve.photo_profile = Request["fileEnvoie"];
                EleveRequest.Create(eleve);
                return RedirectToAction("Index", "Home" );
            }

            ViewBag.Classe = new SelectList(ClasseRequest.GetAllClasses(), "id", "libelle", eleve.idClasse);
            return View(eleve);
        }

        [HttpGet]
        [Route("Eleve/Update")]
        public ActionResult Update()
        {
            EleveVM elevevm = new EleveVM(EleveRequest.GetEleveById(long.Parse(User.Identity.Name)));

            ViewBag.Classe = new SelectList(ClasseRequest.GetAllClasses(), "id", "libelle", elevevm.Eleve.idClasse);
            return View(elevevm);
        }

        [HttpGet]
        [Route("Eleve/Stats")]
        public ActionResult Stats()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Eleve/Update/{id}")]
        public ActionResult Update([Bind(Include = "id,pseudo,mail,mdp,idClasse, Photo_Profile")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                eleve.idClasse = ClasseRequest.GetClasse(Int64.Parse(Request["Classe"]));
                eleve.photo_profile = Request["fileEnvoie"];
                EleveRequest.Update(eleve);

                return RedirectToAction("Index", "Home");
                
            }

            ViewBag.Classe = new SelectList(ClasseRequest.GetAllClasses(), "id", "libelle", eleve.idClasse);
            return View(eleve);
        }

        [HttpGet]
        [Route("Eleve/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            EleveRequest.Delete(id);
            return RedirectToAction("Index", "Home");
        }


    }
}