using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IParentConventionRepository  
    { 
        Task<IEnumerable< ParentConvention >> GetAll(); 
        Task< ParentConvention > GetByIdAsync(int parentid, int conventionid, DateTime datededebut); 
        Task InsertAsync( ParentConvention parentconvention ); 
        Task DeleteAsync(int parentconventionId ); 
        void Update( ParentConvention parentconvention );
        Task DisableConventionActive(int parentid);
        Task SaveAsync(); 
    } 
} 
