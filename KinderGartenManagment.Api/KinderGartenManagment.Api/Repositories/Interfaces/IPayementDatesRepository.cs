using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IPayementDatesRepository  
    { 
        Task<IEnumerable< PayementDates >> GetAll(); 
        Task< PayementDates > GetByIdAsync(int payementdatesId ); 
        Task InsertAsync( PayementDates payementdates ); 
        Task DeleteAsync(int payementdatesId ); 
        void Update( PayementDates payementdates ); 
        Task SaveAsync(); 
    } 
} 
