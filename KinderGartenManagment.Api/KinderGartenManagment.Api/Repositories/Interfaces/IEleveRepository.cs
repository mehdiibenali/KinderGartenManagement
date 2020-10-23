using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinderGartenManagment.Api.Models;

namespace KinderGartenManagment.Api.Interfaces.Repositories
{
    public interface IEleveRepository
    {
        Task<IEnumerable<Object>> GetAll();
        Task<Eleve> GetByIdAsync(int eleveId);
        Task InsertAsync(Eleve eleve);
        Task<IEnumerable<Eleve>> Search(string elevesearch, string parentsearch, string sexe, bool? hasconvention, int? classeid, int? groupeid, int? clubid, int? conventionid);
        Task DeleteAsync(int eleveId);
        void Update(Eleve eleve);
        Task SaveAsync();
    }
}
