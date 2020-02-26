using DraterNew.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.ViewModel
{
    public class CreateRetardsVM
    {

        private Tags tags;
        private Retard retard;
        private Eleve eleve;

        public Tags Tags { get => tags; set => tags = value; }
        public Retard Retard { get => retard; set => retard = value; }
        public Eleve Eleve { get => eleve; set => eleve = value; }

        public CreateRetardsVM(Retard retard)
        {
            this.Retard = retard;
        }
    }
}