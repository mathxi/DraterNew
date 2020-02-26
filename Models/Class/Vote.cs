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

        public Vote() { }
        public Vote(int id, int idEleve, int idRetard, DateTime dateVote, bool valeur)
        {
            this.id = id;
            this.idEleve = idEleve;
            this.idRetard = idRetard;
            this.dateVote = dateVote;
            this.valeur = valeur;
        }

        public static int GetValueFromList(List<Vote> votes)
        {
            int voteValue = 0;
            foreach (var vote in votes)
            {
                // +1 si vote up -1 si vote down et 0 si pas de vote
               // voteValue += vote.valeur == true ? 1 : -1;
                if(vote.valeur == true)
                {
                    voteValue++;
                }
                else if(vote.valeur == false)
                {
                    voteValue--;
                }
            }

            return voteValue;
        }
    }
}