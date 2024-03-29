using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IParentRepository  
    { 
        Task<IEnumerable<Object>> GetAll(); 
        Task< Parent > GetByIdAsync(int parentId); 
        Task InsertAsync( Parent parent ); 
        Task DeleteAsync(int parentId ); 
        void Update( Parent parent );
        Task<IEnumerable<Object>> GetParentsByEleveId(int eleveId);
        Task<IEnumerable<Parent>> GetParentsByConventionId(int conventionid);
        Task<IEnumerable<Parent>> SearchByName(string parentsearch);
        Task SaveAsync(); 
    } 
} 
