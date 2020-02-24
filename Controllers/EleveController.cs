using DraterNew.Models.Class;
using DraterNew.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraterNew.Controllers
{
    public class EleveController : Controller
    {
        // GET: Eleve
        [HttpGet]
        [Route("Eleve/Create")]
        public ActionResult Create()
        {
            ViewBag.Classe = new SelectList(ClasseRequest.GetAllClasses(), "Id", "Libelle");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Eleve/Create")]
        public ActionResult Create([Bind(Include = "id,pseudo,mail,mdp,idClasse, Photo_Profile")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                eleve.idClasse = ClasseRequest.GetClasse(Int64.Parse(Request["Classe"]));
                var resultat = Request["fileEnvoie"];
                EleveRequest.Create(eleve);
                return RedirectToAction("Home", "Index" );
            }

            ViewBag.Classe = new SelectList(ClasseRequest.GetAllClasses(), "id", "libelle", eleve.idClasse);
            return View(eleve);
        }


    }
}