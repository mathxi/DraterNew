using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Class
{
    public class Vote
    {
        public int id { get; set; }

        public int idEleve { get; set; }

        public int idRetard { get; set; }

        public DateTime dateVote { get; set; }

        public Boolean valeur{ get; set; }

        public static int GetValueFromList(List<Vote> votes)
        {
            int voteValue = 0;
            foreach (var vote in votes)
            {
                voteValue += vote.valeur == true ? 1 : -1;
            }
            return voteValue;
        }
    }
}