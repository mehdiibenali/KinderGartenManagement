using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinderGartenManagment.Api.Models;
using KinderGartenManagment.Api.ViewModels;

namespace KinderGartenManagment.Api.Interfaces.Repositories
{
    public interface IEleveRepository
    {
        Task<IEnumerable<Object>> GetAll();
        Task<Eleve> GetByIdAsync(int eleveId);
        Task InsertAsync(Eleve eleve);
        Task<IEnumerable<Eleve>> Search(string elevesearch, string parentsearch, string sexe, bool? hasconvention, int? classeid, int? groupeid, int? clubid, int? conventionid);
        Task<List<EleveViewModel>> GetElevesByEnrollementIdAndMonth(int month, int year, int enrollementid);

        Task DeleteAsync(int eleveId);
        void Update(Eleve eleve);
        Task SaveAsync();
    }
}
