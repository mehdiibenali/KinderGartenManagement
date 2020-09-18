using System.Collections.Generic;
using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace KinderGartenManagment.Api.Repositories
{
    public class EleveRepository : IEleveRepository
    {
        private ApplicationDbContext _context;
        public EleveRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Eleve>> GetAll()
        {
            return await _context.Eleves.Include(c => c.EleveParents).ToListAsync();
        }

        public async Task<Eleve> GetByIdAsync(int id)
        {
            Eleve Eleve = await _context.Eleves.Include(c => c.EleveEnrollements).FirstOrDefaultAsync(x=>x.Id == id) ;
            Eleve.EleveParents = await _context.EleveParents.Where(ep => ep.ParentTuteur == true && ep.EleveId == id).ToListAsync();
            return Eleve;
        }

        public async Task InsertAsync(Eleve eleve)
        {
            await _context.Eleves.AddAsync(eleve);
        }
        public async Task<IEnumerable<Eleve>> Search(string elevesearch, string parentsearch, string sexe, bool? hasconvention, int? classeid, int? groupeid, int? clubid, int? conventionid)
        {
            IEnumerable<Eleve> Eleves = _context.Eleves.Include(e => e.EleveEnrollements).ThenInclude(ee=>ee.Enrollement).Include(e=>e.EleveParents).ThenInclude(ep=>ep.Parent).ThenInclude(p=>p.ParentConventions);
            if (elevesearch != null)
            {
                Eleves = Eleves.Where(e => e.Nom.ToLower().Contains(elevesearch) || e.Prenom.ToLower().Contains(elevesearch) || (e.Nom.ToLower() + ' ' + e.Prenom.ToLower()).Contains(elevesearch) || (e.Prenom.ToLower()+' '+e.Nom.ToLower()).Contains(elevesearch));

            }
            if (parentsearch != null)
            {
                Eleves = Eleves.Where(e => e.EleveParents
                .Any(ep => ep.Parent.NomDeFamille.ToLower().Contains(parentsearch) || ep.Parent.Prenom.ToLower().Contains(parentsearch) || (ep.Parent.NomDeFamille.ToLower() + ' ' + ep.Parent.Prenom.ToLower()).Contains(parentsearch) || (ep.Parent.Prenom.ToLower() + ' ' + ep.Parent.NomDeFamille.ToLower()).Contains(parentsearch))
                );
            }
            if (sexe!=null){
                Eleves = Eleves.Where(e => e.Sexe == sexe);
            }
            if (hasconvention != null && hasconvention!=false)
            {
                Eleves = Eleves.Where(e => e.EleveParents.Any(ep => ep?.ParentTuteur == true && ep?.Parent.ParentConventions?.Any(pc => pc.DateDeFin > DateTime.Now)==true));
            };
            if (classeid != null)
            {
                var T = Eleves.Select(e => e.EleveEnrollements);
                Eleves = Eleves.Where(e => e.EleveEnrollements.Any(ee => ee.Enrollement.ClasseId == classeid));
            };
            if (groupeid != null)
            {
                Eleves = Eleves.Where(e => e.EleveEnrollements.Any(ee => ee.EnrollementId == groupeid));
            };
            if (clubid != null)
            {
                Eleves = Eleves.Where(e => e.EleveEnrollements.Any(ee => ee.EnrollementId == clubid));
            };
            if (conventionid != null)
            {
                Eleves = Eleves.Where(e => e.EleveParents.Any(ep => ep?.ParentTuteur == true && ep?.Parent.ParentConventions?.Any(pc => pc?.DateDeFin > DateTime.Now && pc?.ConventionId == conventionid)==true));
            };
            Eleves = Eleves.ToList();
            return Eleves;
        }
        public async Task DeleteAsync(int eleveId)
        {
            Eleve eleve = await _context.Eleves.FindAsync(eleveId);
            _context.Eleves.Remove(eleve);
        }

        public void Update(Eleve eleve)
        {
            _context.Entry(eleve).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
