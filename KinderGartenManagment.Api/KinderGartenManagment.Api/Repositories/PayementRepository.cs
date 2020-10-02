using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class PayementRepository : IPayementRepository 
    { 
        private ApplicationDbContext _context; 
        public PayementRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< Payement >> GetAll() 
        { 
            return await _context. Payements .ToListAsync(); 
        } 
 
        public async Task< Payement > GetByIdAsync(int id) 
        { 
            return await _context. Payements .FindAsync(id); 
        } 
 
        public async Task InsertAsync( Payement payement ) 
        { 
            await _context. Payements .AddAsync( payement ); 
        } 
 
        public async Task DeleteAsync(int payementId ) 
        { 
            Payement payement = await _context. Payements .FindAsync( payementId ); 
            _context. Payements .Remove( payement ); 
        } 
 
        public void Update( Payement payement ) 
        { 
            _context.Entry( payement ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
