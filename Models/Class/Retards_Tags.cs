using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraterNew.Models.Class
{
    public class Retards_Tags
    {
        public long Id_Retard { get; set; }
        public long Id_Tags { get; set; }
        public long Id { get; set; }

        public virtual Retard Retard { get; set; }
        public virtual Tags Tags { get; set; }
    }
}