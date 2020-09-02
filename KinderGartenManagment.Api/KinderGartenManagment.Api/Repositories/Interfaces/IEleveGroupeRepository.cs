using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IEleveGroupeRepository  
    { 
        Task<IEnumerable< EleveGroupe >> GetAll(); 
        Task InsertAsync( EleveGroupe elevegroupe ); 
        Task DeleteAsync(int eleveid , int groupeid); 
        void Update( EleveGroupe elevegroupe ); 
        Task SaveAsync(); 
    } 
} 
