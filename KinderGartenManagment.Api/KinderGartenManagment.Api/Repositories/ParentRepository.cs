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
        public async Task<IEnumerable<Parent>> GetAll()
        {
            return _context.Parents.Select(p => new
            {
                p,
                ParentConventions = p.ParentConventions
                                           .Where(p => p.Active == true)
            })
            .AsEnumerable()
            .Select(x => x.p).ToList();
            //return await _context.Parents.Include(p => p.ParentConventions).ThenInclude(pc => pc.Convention).ToListAsync();

        }

        public async Task<Parent> GetByIdAsync(int id)  
        {

            Parent Parent = await _context.Parents.FindAsync(id);
            Parent.ParentConventions = await _context.ParentConventions.Include(pc => pc.Convention).Where(pc => pc.Active == true && pc.ParentId == id).ToListAsync();
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
            IEnumerable<Parent> Parents = _context.Parents.Include(p => p.EleveParents).Select(p => new
            {
                p,
                ParentConventions = p.ParentConventions
                                             .Where(p => p.Active == true),
            }
                ).AsEnumerable()
            .Select(x => x.p).ToList();
             return from p in _context.Parents
                           join ep in _context.EleveParents on p.Id equals ep.ParentId
                           join pc in _context.ParentConventions on new { Id = p.Id, Active = true } equals new { Id = pc.ParentId, Active = pc.Active } into ppc
                           from subparentconvention in ppc.DefaultIfEmpty()
                           select new { p, NameOfConvention = subparentconvention.Convention.Name ??  null };




            return Parents
                    .Where(p => p.EleveParents.Select(ep => ep.EleveId).Contains(eleveId));
            //IEnumerable<Parent> test =await _context.Parents.IncludeFilter(p => p.ParentConventions.Where(pc => pc.Active == true)).Take(1).ToListAsync();
            return Parents;
        }
        public async Task<IEnumerable<Parent>> SearchByName(string parentsearch)
        {   
            return await _context.Parents
                .Include(c => c.ParentConventions).ThenInclude(c => c.Convention)
                .Where(x => x.Prenom.Contains(parentsearch) || x.NomDeFamille.Contains(parentsearch))
                .ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
