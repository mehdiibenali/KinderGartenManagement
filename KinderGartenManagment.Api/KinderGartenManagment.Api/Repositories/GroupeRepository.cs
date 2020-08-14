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
            var t = await _context.Groupes.ToListAsync();
            return t;
        }

        public async Task<Groupe> GetByIdAsync(int id)
        {
            return await _context.Groupes.FindAsync(id);
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
