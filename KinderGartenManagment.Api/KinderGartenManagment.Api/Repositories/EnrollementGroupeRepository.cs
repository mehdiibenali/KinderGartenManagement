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
    public class EnrollementGroupeRepository : IEnrollementGroupeRepository
    {
        private ApplicationDbContext _context;
        public EnrollementGroupeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Enrollement>> GetAll()
        {
            var t = await _context.Enrollements.Include(c => c.EleveEnrollements).Where(e=>e.Type=="Groupe").ToListAsync();
            return t;
        }
        public async Task<IEnumerable<object>> GetYears()
        {
            return await _context.Enrollements.Where(e=>e.Type=="Groupe").Select(g => new {debut= g.DateDeDebut.Year, fin=g.DateDeFin.Year}).Distinct().ToListAsync();
        }
        public async Task<IEnumerable<Enrollement>> Search(List<int?> annees, string Enrollementsearch, int? classeid)
        {
            IEnumerable<Enrollement> enrollement = _context.Enrollements.Where(e => e.Type == "Groupe");
            if (annees !=null)
            {
                enrollement = enrollement.Where(g => g.DateDeDebut.Year == annees.First() && g.DateDeFin.Year == annees.Last());
            }
            if (Enrollementsearch != null)
            {
                enrollement = enrollement.Where(x => x.Name.Contains(Enrollementsearch));
            }
            if (classeid != null)
            {
                enrollement = enrollement.Where(e => e.ClasseId == classeid.Value);
            }
            return enrollement.ToList() ;
        }
        public async Task<Enrollement> GetByIdAsync(int id)
        {
            return await _context.Enrollements.Where(e => e.Type == "Groupe").Include(c => c.Classe).FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<EleveEnrollement>> GetEnrollementsByEleveId(int eleveId)
        {
            return await _context.EleveEnrollements.Include(ee => ee.Enrollement).ThenInclude(e => e.Classe)
                .Where(ee => ee.Enrollement.Type == "Groupe")
                .Where(ee => ee.EleveId == eleveId).ToListAsync();
        }   
    }
}
