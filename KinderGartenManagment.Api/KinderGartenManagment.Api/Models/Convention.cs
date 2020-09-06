using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Convention
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateDeDebut { get; set; }

        public DateTime DateDeFin { get; set; }
        public virtual ICollection<ParentConvention> ParentConventions { get; set; }
        public virtual ICollection<ConventionFee> ConventionFees { get; set; }
    }
}
