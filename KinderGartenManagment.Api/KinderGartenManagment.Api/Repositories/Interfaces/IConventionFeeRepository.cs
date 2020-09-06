using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IConventionFeeRepository  
    { 
        Task<IEnumerable< ConventionFee >> GetAll(); 
        Task< ConventionFee > GetByIdAsync(int conventionfeeId ); 
        Task InsertAsync( ConventionFee conventionfee ); 
        Task DeleteAsync(int conventionfeeId ); 
        void Update( ConventionFee conventionfee ); 
        Task SaveAsync(); 
    } 
} 
