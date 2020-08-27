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
            return await _context. EleveParents.Include(c => c.Eleve).Include(c => c.Parent).ToListAsync(); 
        } 
 
        public async Task< EleveParent > GetByIdAsync(int id) 
        { 
            return await _context. EleveParents .FindAsync(id); 
        } 
 
        public async Task InsertAsync( EleveParent eleveparent ) 
        { 
            await _context. EleveParents .AddAsync( eleveparent ); 
        } 
 
        public async Task DeleteAsync(int eleveparentId ) 
        { 
            EleveParent eleveparent = await _context. EleveParents .FindAsync( eleveparentId ); 
            _context. EleveParents .Remove( eleveparent ); 
        } 
 
        public void Update( EleveParent eleveparent ) 
        { 
            _context.Entry( eleveparent ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
