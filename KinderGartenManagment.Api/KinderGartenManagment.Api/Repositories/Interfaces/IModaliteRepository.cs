using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IModaliteRepository  
    { 
        Task<IEnumerable< Modalite >> GetAll(); 
        Task< Modalite > GetByIdAsync(int modaliteId ); 
        Task InsertAsync( Modalite modalite ); 
        Task DeleteAsync(int modaliteId ); 
        void Update( Modalite modalite ); 
        Task SaveAsync(); 
    } 
} 
