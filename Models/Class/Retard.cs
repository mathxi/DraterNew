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

        public Eleve eleve { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Retards_Tags> Retards_Tags { get; set; }

        public Retard()
        {
            this.Retards_Tags = new HashSet<Retards_Tags>();
        }
    }
}