using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DraterNew.Models.Request;

namespace DraterNew.Models.Class
{
    public class Retard : Controller
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public string file { get; set; }

        public int votes { get; set; }
        public int currentUserVote { get; set; }

        public Retard(int id, string titre, string description, string file)
        {
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.file = file;
            votes = Vote.GetValueFromList(VoteRequest.getVoteByRetard(id));
            currentUserVote = DidIVoted(id);
        }
        public static int DidIVoted(int idRetard)
        {
            Eleve eleve = EleveRequest.GetEleveById();
            return Vote.GetValueFromList(VoteRequest.getVoteByEleveRetard(eleve.id, idRetard));
        }
    }
}
