using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace KinderGartenManagment.Api.Repositories
{
    public class EnrollementSummerClubRepository: IEnrollementSummerClubRepository
    {
        private ApplicationDbContext _context;
        public EnrollementSummerClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Enrollement>> GetAll()
        {
            var t = await _context.Enrollements.Include(c => c.EleveEnrollements).Where(e => e.Type == "Club d'été").ToListAsync();
            return t;
        }
        public async Task<IEnumerable<object>> GetYears(int eleveid)
        {
            return await _context.Enrollements.Where(e => e.Type == "Club d'été" && e.EleveEnrollements.All(ee => ee.EleveId != eleveid)).Select(g => new { debut = g.DateDeDebut.Year, fin = g.DateDeFin.Year }).Distinct().ToListAsync();
        }
        public async Task<IEnumerable<Enrollement>> SearchByYear(int anneededebut, int anneedefin)
        {
            return await _context.Enrollements.Where(e => e.Type == "Club d'été").Where(g => g.DateDeDebut.Year == anneededebut && g.DateDeFin.Year == anneedefin).ToListAsync();
        }
        public async Task<Enrollement> GetByIdAsync(int id)
        {
            return await _context.Enrollements.Where(e => e.Type == "Club d'été").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Enrollement Enrollement)
        {
            await _context.Enrollements.AddAsync(Enrollement);
        }

        public async Task DeleteAsync(int EnrollementId)
        {
            Enrollement Enrollement = await _context.Enrollements.FindAsync(EnrollementId);
            _context.Enrollements.Remove(Enrollement);
        }

        public void Update(Enrollement Enrollement)
        {
            _context.Entry(Enrollement).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Enrollement>> SearchByName(string Enrollementsearch)
        {
            return await _context.Enrollements
                .Where(e=>e.Type== "Club d'été")
                .Where(x => x.Name.Contains(Enrollementsearch))
                .ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Enrollement>> GetEnrollementsByEleveId(int eleveId)
        {
            return await _context.Enrollements
                .Where(e => e.Type == "Club d'été")
                .Include(p => p.EleveEnrollements)
                .Where(p => p.EleveEnrollements.Select(ep => ep.EleveId).Contains(eleveId))
                .ToListAsync();
        }
    }
}
