using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Payement
    {
        public int Id { get; set; }
        public int ReceiptNumber { get; set; }
        public virtual ICollection<Modalite> Modalites { get; set; }
        public virtual ICollection<PayementEnrollement> PayementEnrollements { get; set; }
    }
}
