using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Models
{
    public class Convention
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
