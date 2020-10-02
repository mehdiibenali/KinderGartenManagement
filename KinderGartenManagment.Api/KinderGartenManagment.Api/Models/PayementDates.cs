using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class PayementDates
    {
        public int Id { get; set; }
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public int PayementEnrollementId { get; set; }
        public virtual PayementEnrollement PayementEnrollement { get; set; }
    }
}
