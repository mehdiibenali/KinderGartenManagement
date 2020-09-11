using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class ConventionFee
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Fee { get; set; }
        public int ConventionId { get; set; }
        public virtual Convention Convention { get; set; }
    }
}
