using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IEleveEnrollementRepository  
    { 
        Task<IEnumerable< EleveEnrollement >> GetAll(); 
        Task InsertAsync( EleveEnrollement eleveEnrollement ); 
        Task DeleteAsync(int eleveid , int Enrollementid); 
        void Update( EleveEnrollement eleveEnrollement ); 
        Task SaveAsync(); 
    } 
} 
