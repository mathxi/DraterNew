using DraterNew.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Class
{
    public class Eleve
    {
        public long id { get; set; }
        public string pseudo { get; set; }
        public string mail { get; set; }
        public string MDP { get; set; }
        public Classe idClasse { get; set; }
        public string photo_profile { get; set; }

        public Eleve()
        {

        }
        public Eleve(long id, string pseudo, string mail, string mdp , long idClasse, string photo_profile)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.mail = mail;
            this.MDP = mdp;
            this.idClasse = ClasseRequest.GetClasse(idClasse);
            this.photo_profile = photo_profile;
        }

    }
}