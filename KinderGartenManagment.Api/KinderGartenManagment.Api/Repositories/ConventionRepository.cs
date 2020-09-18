using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq;
using System;

namespace KinderGartenManagment.Api.Repositories 
{ 
    public class ConventionRepository : IConventionRepository 
    { 
        private ApplicationDbContext _context; 
        public ConventionRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< Convention >> GetAll() 
        {
            return await _context.Conventions.Include(c => c.ConventionFees). ToListAsync(); 
        }
        public async Task<Convention> GetActive(int parentid,DateTime datetime)
        {
            return await _context.Conventions
                .Where(c => c.ParentConventions.Any(cp => cp.ParentId == parentid && cp.DateDeFin > datetime)).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<object>> GetYears()
        {
            return await _context.Conventions.Select(c => new { debut = c.DateDeDebut.Year, fin = c.DateDeFin.Year }).Distinct().ToListAsync();
        }
        public async Task<IEnumerable<Convention>> Search(string? name,List<int?> annees)
        {
            IEnumerable<Convention> conventions = _context.Conventions;
            if (annees != null)
            {
                conventions = conventions.Where(c => c.DateDeDebut.Year == annees.First() && c.DateDeFin.Year == annees.Last());
            }
            if (name != null)
            {
                conventions = conventions.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }
            return conventions.ToList();
        }

        public async Task< Convention > GetByIdAsync(int id) 
        { 
            return await _context. Conventions .FindAsync(id); 
        } 
 
        public async Task InsertAsync( Convention convention ) 
        { 
            await _context. Conventions .AddAsync( convention ); 
        } 
 
        public async Task DeleteAsync(int conventionId ) 
        { 
            Convention convention = await _context. Conventions .FindAsync( conventionId ); 
            _context. Conventions .Remove( convention ); 
        } 
 
        public void Update( Convention convention ) 
        { 
            _context.Entry( convention ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
