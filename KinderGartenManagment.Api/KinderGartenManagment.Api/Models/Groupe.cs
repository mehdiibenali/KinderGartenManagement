using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnneeDeDebut { get; set; }
        public int AnneDeFin { get; set; }
        public int ClasseId { get; set; }
        public virtual Classe Classe { get; set; }
    }
}
