using System.Collections.Generic;
using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Microsoft.Data.SqlClient;
using KinderGartenManagment.Api.ViewModels;

namespace KinderGartenManagment.Api.Repositories
{
    public class EleveRepository : IEleveRepository
    {
        private ApplicationDbContext _context;
        public EleveRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Object>> GetAll()
        {
            return from e in _context.Eleves
                   join ee in _context.EleveEnrollements on new { Id = e.Id, Active = true, Type = "Groupe" } equals new { Id = ee.EleveId, Active = ee.Enrollement.DateDeFin >= DateTime.Now, Type = ee.Enrollement.Type } into eeg
                   from eleveenrollementgroupes in eeg.DefaultIfEmpty()
                   select new   
                   {
                       Id = e.Id,
                       Prenom = e.Prenom,
                       Nom = e.Nom,
                       LieuDeNaissance = e.LieuDeNaissance,
                       Adresse = e.Adresse,
                       Sexe = e.Sexe,
                       EleveParents = e.EleveParents,
                       Enrollement = eleveenrollementgroupes.Enrollement.Name,
                   };
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
                //var T = Eleves.Select(e => e.EleveEnrollements);
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
        [System.Obsolete]
        public async Task<List<EleveViewModel>> GetElevesByEnrollementIdAndMonth(int month, int year, int enrollementid)
        {
            SqlParameter monthparameter = new SqlParameter("@Month", month);
            SqlParameter yearparameter = new SqlParameter("@Year", year);
            SqlParameter enrollementidparameter = new SqlParameter("@EnrollementID", enrollementid);
            string sqlQuery = "EXEC dbo.get_eleves_by_enrollement " + "@Month" + "," + "@Year" + "," + "@EnrollementID";
            var result = await _context.Query<EleveViewModel>().FromSql(sqlQuery, monthparameter, yearparameter, enrollementidparameter).ToListAsync();
            return result;
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
