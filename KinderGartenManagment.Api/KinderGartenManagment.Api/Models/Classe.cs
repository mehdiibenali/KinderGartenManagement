using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Classe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Enrollement> Enrollements { get; set; }
    }
}
