using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IGroupeRepository  
    { 
        Task<IEnumerable< Groupe >> GetAll(); 
        Task< Groupe > GetByIdAsync(int groupeId ); 
        Task InsertAsync( Groupe groupe ); 
        Task DeleteAsync(int groupeId ); 
        void Update( Groupe groupe );
        Task<IEnumerable<Groupe>> GetGroupesByEleveId(int eleveId);
        Task SaveAsync(); 
    } 
} 
