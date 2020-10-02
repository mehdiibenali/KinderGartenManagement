using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class PayementEnrollement
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public int Paid { get; set; }
        public int PayementId { get; set; }
        public string Comment { get; set; }
        public virtual Payement Payement { get; set; }
        public virtual ICollection<PayementDates> PayementDates { get; set; }
    }
}
