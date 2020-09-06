using System.Collections.Generic;
using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace KinderGartenManagment.Api.Repositories
{
    public class GroupeRepository : IGroupeRepository
    {
        private ApplicationDbContext _context;
        public GroupeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Groupe>> GetAll()
        {
            var t = await _context.Groupes.Include(c => c.EleveGroupes).ToListAsync();
            return t;
        }
        public async Task<IEnumerable<object>> GetYears(int eleveid)
        {
            return await _context.Groupes.Where(g=>g.EleveGroupes.Any(eg=>eg.EleveId==eleveid)).Select(g => new {debut= g.DateDeDebut.Year, fin=g.DateDeFin.Year }).Distinct().ToListAsync();
        }
        public async Task<IEnumerable<Groupe>> SearchByYear(int anneededebut,int anneedefin)
        {
            return await _context.Groupes.Where(g => g.DateDeDebut.Year == anneededebut && g.DateDeFin.Year == anneedefin).ToListAsync();
        }
        public async Task<Groupe> GetByIdAsync(int id)
        {
            return await _context.Groupes.Include(c => c.Classe).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Groupe groupe)
        {
            await _context.Groupes.AddAsync(groupe);
        }

        public async Task DeleteAsync(int groupeId)
        {
            Groupe groupe = await _context.Groupes.FindAsync(groupeId);
            _context.Groupes.Remove(groupe);
        }

        public void Update(Groupe groupe)
        {
            _context.Entry(groupe).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Groupe>> SearchByName(string groupesearch)
        {
            return await _context.Groupes
                .Include(c => c.Classe)
                .Where(x => x.Name.Contains(groupesearch))
                .ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Groupe>> GetGroupesByEleveId(int eleveId)
        {
            return await _context.Groupes
                .Include(p => p.EleveGroupes)
                .Where(p => p.EleveGroupes.Select(ep => ep.EleveId).Contains(eleveId))
                .Include(p => p.Classe).ToListAsync();
        }
    }
}
