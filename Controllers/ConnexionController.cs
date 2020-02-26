using DraterNew.Models.Class;
using DraterNew.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DraterNew.Controllers
{
    public class ConnexionController : Controller
    {
        [HttpGet]
        [Route("Connexion")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }


        }

        // GET: Connexion
        [HttpPost]
        [Route("Connexion")]
        public ActionResult Index(string Pseudo, string MDP)
        {
            Eleve eleve = null;
            if (Pseudo != null && MDP != null)
            {
                eleve = EleveRequest.GetEleveByPseudoAndMDP(Pseudo, MDP);
                if (Convert.ToString(eleve.id) != null)
                {
                    FormsAuthentication.SetAuthCookie(Convert.ToString(eleve.id), true);
                    Session["EleveConnecte"] = eleve.id;

                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.ConnexionErreur = "Connexion echouée !";

            return View();
        }
        [Route("Deconnexion")]
        public ActionResult Disconect()
        {
            FormsAuthentication.SignOut();
            Session["EleveConnecte"] = null;
            return RedirectToAction("Index", "Connexion");
        }
    }
  
}