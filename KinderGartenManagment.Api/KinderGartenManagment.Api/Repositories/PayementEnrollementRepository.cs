using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class PayementEnrollementRepository : IPayementEnrollementRepository 
    { 
        private ApplicationDbContext _context; 
        public PayementEnrollementRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< PayementEnrollement >> GetAll() 
        { 
            return await _context. PayementEnrollements .ToListAsync(); 
        } 
 
        public async Task< PayementEnrollement > GetByIdAsync(int id) 
        { 
            return await _context. PayementEnrollements .FindAsync(id); 
        } 
 
        public async Task InsertAsync( PayementEnrollement payementenrollement ) 
        { 
            await _context. PayementEnrollements .AddAsync( payementenrollement ); 
        } 
 
        public async Task DeleteAsync(int payementenrollementId ) 
        { 
            PayementEnrollement payementenrollement = await _context. PayementEnrollements .FindAsync( payementenrollementId ); 
            _context. PayementEnrollements .Remove( payementenrollement ); 
        } 
 
        public void Update( PayementEnrollement payementenrollement ) 
        { 
            _context.Entry( payementenrollement ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
