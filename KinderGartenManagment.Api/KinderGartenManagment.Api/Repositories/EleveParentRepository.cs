using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class EleveParentRepository : IEleveParentRepository 
    { 
        private ApplicationDbContext _context; 
        public EleveParentRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< EleveParent >> GetAll() 
        { 
            return await _context. EleveParents.ToListAsync(); 
        } 
 
        public async Task< EleveParent > GetByIdAsync(int eleveid,int parentid) 
        { 
            return await _context. EleveParents .Where(ep=>ep.EleveId==eleveid && ep.ParentId==parentid).FirstOrDefaultAsync();
        
        }
        public async Task<EleveParent> GetByEleveIdParentTuteur(int eleveid)
        {
            return await _context.EleveParents.Where(ep => ep.EleveId == eleveid && ep.ParentTuteur == true).FirstOrDefaultAsync();
        }

        public async Task InsertAsync( EleveParent eleveparent ) 
        {
            EleveParent ep = _context.EleveParents.Where(ep => ep.ParentTuteur == true && ep.EleveId == eleveparent.EleveId).FirstOrDefault();
            if (ep != null)
            {
                ep.ParentTuteur = false;
                _context.Entry(ep).State = EntityState.Modified;
            }
            eleveparent.ParentTuteur = true;
            await _context. EleveParents .AddAsync( eleveparent ); 
        }

        public async Task DeleteAsync(int eleveid,int parentid ) 
        { 
           EleveParent eleveparent = _context. EleveParents .Where(p=>p.EleveId==eleveid && p.ParentId==parentid).First(); 
            _context. EleveParents .Remove( eleveparent );
            EleveParent ep = _context.EleveParents.Where(ep => ep.ParentTuteur == false && ep.EleveId == eleveid).FirstOrDefault();
            if (ep != null)
            {
                ep.ParentTuteur = true;
                _context.Entry(ep).State = EntityState.Modified;
            }
        } 
 
        public async Task UpdateAsync( int eleveid , int parentid) 
        {
            EleveParent ep = _context.EleveParents.Where(ep => ep.ParentTuteur == true && ep.EleveId == eleveid).FirstOrDefault();
            if (ep != null)
            {
                ep.ParentTuteur = false;
                _context.Entry(ep).State = EntityState.Modified;
            }
            EleveParent newep = await _context.EleveParents.Where(pe => pe.EleveId == eleveid && pe.ParentId == parentid).FirstOrDefaultAsync();
            if (newep != null)
            {
                newep.ParentTuteur = true;
                _context.Entry(newep).State = EntityState.Modified;
            }
        }
        public async Task DisableParentTuteurAsync(int eleveid)
        {
            EleveParent ep = _context.EleveParents.Where(ep => ep.ParentTuteur == true && ep.EleveId == eleveid).FirstOrDefault();
            if (ep != null)
            {
                ep.ParentTuteur = false;
                _context.Entry(ep).State = EntityState.Modified;
            }
        }
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
