using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IClasseRepository  
    { 
        Task<IEnumerable< Classe >> GetAll(); 
        Task< Classe > GetByIdAsync(int classeId ); 
        Task InsertAsync( Classe classe ); 
        Task DeleteAsync(int classeId ); 
        void Update( Classe classe ); 
        Task SaveAsync(); 
    } 
} 
