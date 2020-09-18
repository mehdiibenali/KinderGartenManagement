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
    public class ParentConventionRepository : IParentConventionRepository 
    { 
        private ApplicationDbContext _context; 
        public ParentConventionRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< ParentConvention >> GetAll() 
        { 
            return await _context. ParentConventions .ToListAsync(); 
        } 
 
        public async Task< ParentConvention > GetByIdAsync(int parentid,int conventionid,DateTime datededebut) 
        { 
            return await _context. ParentConventions .Where(pc=>pc.DateDeDebut==datededebut && pc.ConventionId==conventionid && pc.ParentId==parentid).FirstOrDefaultAsync(); 
        } 
 
        public async Task InsertAsync( ParentConvention parentconvention ) 
        {
            Convention convention = await _context.Conventions.FindAsync(parentconvention.ConventionId);
            parentconvention.DateDeFin = convention.DateDeFin;
            await _context. ParentConventions .AddAsync( parentconvention ); 
        } 
 
        public async Task DeleteAsync(int parentconventionId ) 
        { 
            ParentConvention parentconvention = await _context. ParentConventions .FindAsync( parentconventionId ); 
            _context. ParentConventions .Remove( parentconvention ); 
        } 
 
        public void Update( ParentConvention parentconvention ) 
        { 
            _context.Entry( parentconvention ).State = EntityState.Modified; 
        }
        public async Task DisableConventionActive(int parentid,DateTime datedefin)
        {
            ParentConvention pc = _context.ParentConventions.Where(ep => ep.DateDeFin > DateTime.Now && ep.ParentId == parentid).FirstOrDefault();
            if (pc != null)
            {
                pc.DateDeFin = datedefin;
                _context.Entry(pc).State = EntityState.Modified;
            }
        }
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
