using DraterNew.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Class
{
    public class Retard
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public string file { get; set; }

        public int votes { get; set; }

        public Retard(int id, string titre, string description, string file)
        {
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.file = file;

            List<Vote> votes = VoteRequest.getVoteByRetard(id);

            this.votes = Vote.GetValueFromList(votes);
        }
    }
}
