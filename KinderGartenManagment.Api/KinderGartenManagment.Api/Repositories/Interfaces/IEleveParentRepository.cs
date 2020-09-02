using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IEleveParentRepository  
    { 
        Task<IEnumerable< EleveParent >> GetAll(); 
        Task InsertAsync( EleveParent eleveparent ); 
        Task DeleteAsync(int eleveid, int parentid ); 
        void Update( EleveParent eleveparent );
        Task DisableParentTuteurAsync(int eleveid);
        Task SaveAsync(); 
    } 
} 
