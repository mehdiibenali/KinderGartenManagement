using System.Collections.Generic;
using KinderGartenManagment.Api.Models;
using Microsoft.EntityFrameworkCore;
using KinderGartenManagment.Api.Context;
using KinderGartenManagment.Api.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

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
            return await _context.Eleves.Include(c => c.EleveGroupes).Include(c => c.EleveParents).FirstOrDefaultAsync(x=>x.Id == id) ;
        }

        public async Task InsertAsync(Eleve eleve)
        {
            await _context.Eleves.AddAsync(eleve);
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
