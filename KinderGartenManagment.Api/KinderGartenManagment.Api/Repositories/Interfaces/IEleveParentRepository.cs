using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IEleveParentRepository  
    { 
        Task<IEnumerable< EleveParent >> GetAll();
        Task<EleveParent> GetByIdAsync(int eleveid, int parentid);
        Task<EleveParent> GetByEleveIdParentTuteur(int eleveid);
        Task InsertAsync( EleveParent eleveparent ); 
        Task DeleteAsync(int eleveid, int parentid );
        Task UpdateAsync(int eleveid, int parentid);
        Task DisableParentTuteurAsync(int eleveid);
        Task SaveAsync(); 
    } 
} 
