using DraterNew.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.ViewModel
{
    public class EleveVM
    {
        private Classe classe;
        private Eleve eleve;
        public Classe Classe{ get => classe; set => classe = value; }
        public Eleve Eleve { get => eleve; set => eleve = value; }

        public EleveVM()
        {

        }
    }
}