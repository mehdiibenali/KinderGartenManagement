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
        Task<IEnumerable<object>> GetYears();
        Task<IEnumerable<Convention>> Search(string? Name,List<int?> annees);
        Task< Convention > GetByIdAsync(int conventionId ); 
        Task InsertAsync( Convention convention ); 
        Task DeleteAsync(int conventionId ); 
        void Update( Convention convention ); 
        Task SaveAsync(); 
    } 
} 
