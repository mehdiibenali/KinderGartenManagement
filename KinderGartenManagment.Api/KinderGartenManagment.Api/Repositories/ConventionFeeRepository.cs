using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class ConventionFeeRepository : IConventionFeeRepository 
    { 
        private ApplicationDbContext _context; 
        public ConventionFeeRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< ConventionFee >> GetAll() 
        { 
            return await _context. ConventionFees .ToListAsync(); 
        } 
 
        public async Task< ConventionFee > GetByIdAsync(int id) 
        { 
            return await _context. ConventionFees .FindAsync(id); 
        } 
 
        public async Task InsertAsync( ConventionFee conventionfee ) 
        { 
            await _context. ConventionFees .AddAsync( conventionfee ); 
        } 
 
        public async Task DeleteAsync(int conventionfeeId ) 
        { 
            ConventionFee conventionfee = await _context. ConventionFees .FindAsync( conventionfeeId ); 
            _context. ConventionFees .Remove( conventionfee ); 
        } 
 
        public void Update( ConventionFee conventionfee ) 
        { 
            _context.Entry( conventionfee ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
