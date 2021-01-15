using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IEnrollementGroupeRepository  
    { 
        Task<IEnumerable< Enrollement >> GetAll(); 
        Task< Enrollement > GetByIdAsync(int EnrollementId );
        Task<IEnumerable<object>> GetYears();
        Task<IEnumerable<Enrollement>> Search(List<int?> annees, string Enrollementsearch, int? classeid);
        Task InsertAsync( Enrollement Enrollement ); 
        Task DeleteAsync(int EnrollementId ); 
        void Update( Enrollement Enrollement );
        Task<IEnumerable<EleveEnrollement>> GetEnrollementsByEleveId(int eleveId);
        Task SaveAsync(); 
    } 
} 
