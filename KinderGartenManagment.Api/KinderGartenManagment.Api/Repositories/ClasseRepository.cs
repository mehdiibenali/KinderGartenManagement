using System.Collections.Generic;
using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace KinderGartenManagment.Api.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        private ApplicationDbContext _context;
        public ClasseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Classe>> GetAll()
        {
            return await _context.Classes.Include(c=>c.Enrollements).ToListAsync();
        }

        public async Task<Classe> GetByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task InsertAsync(Classe classe)
        {
            await _context.Classes.AddAsync(classe);
        }

        public async Task DeleteAsync(int classeId)
        {
            Classe classe = await _context.Classes.FindAsync(classeId);
            _context.Classes.Remove(classe);
        }

        public void Update(Classe classe)
        {
            _context.Entry(classe).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
