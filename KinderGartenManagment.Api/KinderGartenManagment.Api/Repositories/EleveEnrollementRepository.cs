using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class EleveEnrollementRepository : IEleveEnrollementRepository 
    { 
        private ApplicationDbContext _context; 
        public EleveEnrollementRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< EleveEnrollement >> GetAll() 
        { 
            return await _context.EleveEnrollements.Include(c => c.Eleve).Include(c => c.Enrollement).ToListAsync(); 
        } 
 
 
        public async Task InsertAsync( EleveEnrollement eleveEnrollement ) 
        { 
            await _context. EleveEnrollements .AddAsync( eleveEnrollement ); 
        } 
 
        public async Task DeleteAsync(int eleveEnrollementId ) 
        { 
            EleveEnrollement eleveEnrollement = await _context. EleveEnrollements .FindAsync( eleveEnrollementId ); 
            _context. EleveEnrollements .Remove( eleveEnrollement ); 
        } 
 
        public void Update( EleveEnrollement eleveEnrollement ) 
        { 
            _context.Entry( eleveEnrollement ).State = EntityState.Modified; 
        }
        public async Task DeleteAsync(int eleveid, int Enrollementid)
        {
            EleveEnrollement eleveEnrollement = _context.EleveEnrollements.Where(p => p.EleveId == eleveid && p.EnrollementId == Enrollementid).First();
            _context.EleveEnrollements.Remove(eleveEnrollement);
        }
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
