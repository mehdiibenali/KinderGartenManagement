using System.Collections.Generic;
using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;

namespace KinderGartenManagment.Api.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private ApplicationDbContext _context;
        public ParentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Object>> GetAll()
        {
            return from p in _context.Parents
                   join pc in _context.ParentConventions on new { Id = p.Id, Active = true } equals new { Id = pc.ParentId, Active = pc.DateDeFin > DateTime.Now } into ppc
                   from subparentconvention in ppc.DefaultIfEmpty()
                   select new { p, NameOfConvention = subparentconvention.Convention.Name ?? null };
        }

        public async Task<Parent> GetByIdAsync(int id)  
        {

            Parent Parent = await _context.Parents.FindAsync(id);
            Parent.ParentConventions = await _context.ParentConventions.Include(pc => pc.Convention).Where(pc => pc.DateDeFin > DateTime.Now && pc.ParentId == id).ToListAsync();
            return Parent;
    
          }

        public async Task InsertAsync(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
        }
        public async Task DeleteAsync(int parentId)
        {
            Parent parent = await _context.Parents.FindAsync(parentId);
            _context.Parents.Remove(parent);
        }
        public void Update(Parent parent)
        {
            _context.Entry(parent).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Object>> GetParentsByEleveId(int eleveId)
        {
             return from p in _context.Parents
                           join ep in _context.EleveParents on p.Id equals ep.ParentId where ep.EleveId == eleveId
                           join pc in _context.ParentConventions on new { Id = p.Id, Active = true } equals new { Id = pc.ParentId, Active = (pc.DateDeFin>DateTime.Now) } into ppc
                           from subparentconvention in ppc.DefaultIfEmpty()
                           select new { p, NameOfConvention = subparentconvention.Convention.Name ??  null };
        }
        public async Task<IEnumerable<Parent>> GetParentsByConventionId(int conventionid)
        {
            return await _context.Parents.Where(p => p.ParentConventions.Any(pc => pc.ConventionId == conventionid)).ToListAsync();
        }
        public async Task<IEnumerable<Parent>> SearchByName(string parentsearch)
        {
            parentsearch = parentsearch.ToLower();
            return await _context.Parents
                .Include(c => c.ParentConventions).ThenInclude(c => c.Convention)
                .Where(x => x.Prenom.Contains(parentsearch) || x.NomDeFamille.Contains(parentsearch) || (x.NomDeFamille+' '+x.Prenom).Contains(parentsearch) || (x.Prenom+' '+x.NomDeFamille).Contains(parentsearch))
                .ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
