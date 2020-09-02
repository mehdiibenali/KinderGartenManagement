using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class EleveGroupeRepository : IEleveGroupeRepository 
    { 
        private ApplicationDbContext _context; 
        public EleveGroupeRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< EleveGroupe >> GetAll() 
        { 
            return await _context.EleveGroupes.Include(c => c.Eleve).Include(c => c.Groupe).ToListAsync(); 
        } 
 
 
        public async Task InsertAsync( EleveGroupe elevegroupe ) 
        { 
            await _context. EleveGroupes .AddAsync( elevegroupe ); 
        } 
 
        public async Task DeleteAsync(int elevegroupeId ) 
        { 
            EleveGroupe elevegroupe = await _context. EleveGroupes .FindAsync( elevegroupeId ); 
            _context. EleveGroupes .Remove( elevegroupe ); 
        } 
 
        public void Update( EleveGroupe elevegroupe ) 
        { 
            _context.Entry( elevegroupe ).State = EntityState.Modified; 
        }
        public async Task DeleteAsync(int eleveid, int groupeid)
        {
            EleveGroupe elevegroupe = _context.EleveGroupes.Where(p => p.EleveId == eleveid && p.GroupeId == groupeid).First();
            _context.EleveGroupes.Remove(elevegroupe);
        }
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
