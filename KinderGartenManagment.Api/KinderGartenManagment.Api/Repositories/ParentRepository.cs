using System.Collections.Generic;
using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;

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
            return await _context.Parents.ToListAsync();
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            return await _context.Parents.FindAsync(id);
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
