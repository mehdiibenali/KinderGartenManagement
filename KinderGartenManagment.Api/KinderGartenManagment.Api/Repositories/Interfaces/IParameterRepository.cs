using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IParameterRepository  
    { 
        Task<IEnumerable< Parameter >> GetAll();
        Task<IEnumerable<Parameter>> GetByCodeAsync(string code);
        Task InsertAsync( Parameter parameter );
        Task<IEnumerable<Object>> GetDates(DateTime Start, DateTime End);
        Task DeleteAsync(int parameterId ); 
        void Update( Parameter parameter ); 
        Task SaveAsync(); 
    } 
} 
