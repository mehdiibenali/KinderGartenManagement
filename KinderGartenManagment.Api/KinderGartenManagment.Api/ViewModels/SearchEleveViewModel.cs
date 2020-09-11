using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.ViewModels
{
    public class SearchEleveViewModel
    {
        public string EleveSearch { get; set; }
        public string ParentSearch { get; set; }
        public string Sexe { get; set; }
        public bool? HasConvention { get; set; }
        public int? ClasseId { get; set; }
        public int? GroupeId { get; set; }
        public int? ClubId { get; set; }
        public int? ConventionId { get; set; }
    }
}
