using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class EleveGroupe
    {
        public int EleveId { get; set; }
        public int GroupeId { get; set; }

        public DateTime DateDeDebut { get; set; }

        public DateTime? DateDeFin { get; set; }
        public Eleve Eleve { get; set; }
        public Groupe Groupe { get; set; }
    }
}
