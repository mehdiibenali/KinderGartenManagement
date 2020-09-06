using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IConventionRepository  
    { 
        Task<IEnumerable< Convention >> GetAll();
        Task<Convention> GetActive(int parentid,DateTime datetime);
        Task<IEnumerable<Convention>> SearchByYear(int year);
        Task< Convention > GetByIdAsync(int conventionId ); 
        Task InsertAsync( Convention convention ); 
        Task DeleteAsync(int conventionId ); 
        void Update( Convention convention ); 
        Task SaveAsync(); 
    } 
} 
