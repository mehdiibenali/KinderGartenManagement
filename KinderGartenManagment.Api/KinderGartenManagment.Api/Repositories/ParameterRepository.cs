using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class ParameterRepository : IParameterRepository 
    { 
        private ApplicationDbContext _context; 
        public ParameterRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< Parameter >> GetAll() 
        { 
            return await _context. Parameters .ToListAsync(); 
        } 
 
        public async Task< Parameter > GetByIdAsync(int id) 
        { 
            return await _context. Parameters .FindAsync(id); 
        } 
 
        public async Task InsertAsync( Parameter parameter ) 
        { 
            await _context. Parameters .AddAsync( parameter ); 
        } 
 
        public async Task DeleteAsync(int parameterId ) 
        { 
            Parameter parameter = await _context. Parameters .FindAsync( parameterId ); 
            _context. Parameters .Remove( parameter ); 
        } 
 
        public void Update( Parameter parameter ) 
        { 
            _context.Entry( parameter ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
