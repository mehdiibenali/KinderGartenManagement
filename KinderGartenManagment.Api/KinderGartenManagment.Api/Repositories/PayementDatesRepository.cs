using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class PayementDatesRepository : IPayementDatesRepository 
    { 
        private ApplicationDbContext _context; 
        public PayementDatesRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< PayementDates >> GetAll() 
        { 
            return await _context. PayementDates .ToListAsync(); 
        } 
 
        public async Task< PayementDates > GetByIdAsync(int id) 
        { 
            return await _context. PayementDates .FindAsync(id); 
        } 
 
        public async Task InsertAsync( PayementDates payementdates ) 
        { 
            await _context. PayementDates .AddAsync( payementdates ); 
        } 
 
        public async Task DeleteAsync(int payementdatesId ) 
        { 
            PayementDates payementdates = await _context. PayementDates .FindAsync( payementdatesId ); 
            _context. PayementDates .Remove( payementdates ); 
        } 
 
        public void Update( PayementDates payementdates ) 
        { 
            _context.Entry( payementdates ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
