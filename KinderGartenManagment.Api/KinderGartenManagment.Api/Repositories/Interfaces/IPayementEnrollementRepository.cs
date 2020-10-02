using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IPayementEnrollementRepository  
    { 
        Task<IEnumerable< PayementEnrollement >> GetAll(); 
        Task< PayementEnrollement > GetByIdAsync(int payementenrollementId ); 
        Task InsertAsync( PayementEnrollement payementenrollement ); 
        Task DeleteAsync(int payementenrollementId ); 
        void Update( PayementEnrollement payementenrollement ); 
        Task SaveAsync(); 
    } 
} 
