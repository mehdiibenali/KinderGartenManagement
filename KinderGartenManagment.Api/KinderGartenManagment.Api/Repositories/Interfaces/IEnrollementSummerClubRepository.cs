using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinderGartenManagment.Api.Models;

namespace KinderGartenManagment.Api.Interfaces.Repositories
{
    public interface IEnrollementSummerClubRepository
    {
        Task<IEnumerable<Enrollement>> GetAll();
        Task<Enrollement> GetByIdAsync(int EnrollementId);
        Task<IEnumerable<object>> GetYears(int eleveid);
        Task<IEnumerable<Enrollement>> SearchByYear(int anneededebut, int anneedefin);
        Task InsertAsync(Enrollement Enrollement);
        Task DeleteAsync(int EnrollementId);
        void Update(Enrollement Enrollement);
        Task<IEnumerable<Enrollement>> GetEnrollementsByEleveId(int eleveId);
        Task<IEnumerable<Enrollement>> SearchByName(string Enrollementsearch);
        Task SaveAsync();
    }
}
