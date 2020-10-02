using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq; 
 
namespace KinderGartenManagment.Api.Repositories 
{ 
    public class ModaliteRepository : IModaliteRepository 
    { 
        private ApplicationDbContext _context; 
        public ModaliteRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< Modalite >> GetAll() 
        { 
            return await _context. Modalites .ToListAsync(); 
        } 
 
        public async Task< Modalite > GetByIdAsync(int id) 
        { 
            return await _context. Modalites .FindAsync(id); 
        } 
 
        public async Task InsertAsync( Modalite modalite ) 
        { 
            await _context. Modalites .AddAsync( modalite ); 
        } 
 
        public async Task DeleteAsync(int modaliteId ) 
        { 
            Modalite modalite = await _context. Modalites .FindAsync( modaliteId ); 
            _context. Modalites .Remove( modalite ); 
        } 
 
        public void Update( Modalite modalite ) 
        { 
            _context.Entry( modalite ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
