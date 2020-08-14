using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinderGartenManagment.Api.Models;

namespace KinderGartenManagment.Api.Interfaces.Repositories
{
    public interface IEleveRepository
    {
        Task<IEnumerable<Eleve>> GetAll();
        Task<Eleve> GetByIdAsync(int eleveId);
        Task InsertAsync(Eleve eleve);
        Task DeleteAsync(int eleveId);
        void Update(Eleve eleve);
        Task SaveAsync();
    }
}