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
        Task<PayementEnrollement> GetCurrentEleveEnrollement(DateTime Date, int EleveId);
        void Delete(int eleveid , int Enrollementid, DateTime Datededebut); 
        void Update( EleveEnrollement eleveEnrollement ); 
        Task SaveAsync(); 
    } 
} 
