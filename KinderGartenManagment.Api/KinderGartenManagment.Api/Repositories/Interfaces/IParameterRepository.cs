using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models; 
 
namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IParameterRepository  
    { 
        Task<IEnumerable< Parameter >> GetAll(); 
        Task< Parameter > GetByIdAsync(string code ); 
        Task InsertAsync( Parameter parameter ); 
        Task DeleteAsync(int parameterId ); 
        void Update( Parameter parameter ); 
        Task SaveAsync(); 
    } 
} 
