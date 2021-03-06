﻿using DraterNew.Models.Request;

namespace DraterNew.Models.Class
{
    public class Retard
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public string file { get; set; }

        public Eleve eleve { get; set; }

        //public virtual ICollection<Retards_Tags> Retards_Tags { get; set; }

        public int votes { get; set; }
        public int currentUserVote { get; set; }

        public Retard(int id, string titre, string description, string file, int idEleve)
        {
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.file = "https://picsum.photos/200";
            this.eleve = EleveRequest.GetEleveById(idEleve);
            votes = Vote.GetValueFromList(VoteRequest.getVoteByRetard(id));
            //currentUserVote = DidIVoted(  );
        }
         public Retard()
        {
            
        }

        public Retard(int id, string titre, string description, string file, int idEleve, int idUserConnecte)
        {
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.file = "https://picsum.photos/200";
            this.eleve = EleveRequest.GetEleveById(idEleve);
            votes = Vote.GetValueFromList(VoteRequest.getVoteByRetard(id));
            currentUserVote = DidIVoted(idUserConnecte, id);
        }

        
        public static int DidIVoted(int idEleveConnected, int idRetard)
        {
            return Vote.GetValueFromList(VoteRequest.getVoteByEleveRetard(idEleveConnected, idRetard));
        }
    }

    public class TopXRetard
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public string file { get; set; }

        public Eleve eleve { get; set; }

        public int nbVote { get; set; }

        //public virtual ICollection<Retards_Tags> Retards_Tags { get; set; }

        public int votes { get; set; }
        public int currentUserVote { get; set; }

        public TopXRetard(int id, string titre, string description, string file, int idEleve, int nbVote)
        {
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.file = "https://picsum.photos/200";
            this.eleve = EleveRequest.GetEleveById(idEleve);
            this.nbVote = nbVote;
            votes = Vote.GetValueFromList(VoteRequest.getVoteByRetard(id));
            //currentUserVote = DidIVoted(  );
        }

        public TopXRetard(int id, string titre, string description, string file, int idEleve, int idUserConnecte, int nbVote)
        {
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.file = "https://picsum.photos/200";
            this.eleve = EleveRequest.GetEleveById(idEleve);
            this.nbVote = nbVote;
            votes = Vote.GetValueFromList(VoteRequest.getVoteByRetard(id));
            currentUserVote = DidIVoted(idUserConnecte, id);
        }


        public static int DidIVoted(int idEleveConnected, int idRetard)
        {
            return Vote.GetValueFromList(VoteRequest.getVoteByEleveRetard(idEleveConnected, idRetard));
        }
    }
}
