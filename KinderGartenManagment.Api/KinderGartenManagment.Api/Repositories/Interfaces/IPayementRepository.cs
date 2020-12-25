using System; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using KinderGartenManagment.Api.Models;
using KinderGartenManagment.Api.ViewModels;

namespace KinderGartenManagment.Api.Interfaces.Repositories 
{ 
    public interface IPayementRepository  
    { 
        Task<IEnumerable< Payement >> GetAll(); 
        Task< Payement > GetByIdAsync(int payementId ); 
        Task InsertAsync( Payement payement ); 
        Task DeleteAsync(int payementId );
        Task<List<UnpaidViewModel>> GetUnpaid(string eleveids);
        void Update( Payement payement ); 
        Task SaveAsync(); 
    } 
} 
