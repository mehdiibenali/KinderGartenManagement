//using System.Collections.Generic; 
//using KinderGartenManagment.Api.Models; 
//using Microsoft.EntityFrameworkCore; 
//using KinderGartenManagment.Api.Context; 
//using KinderGartenManagment.Api.Interfaces.Repositories; 
//using System.Threading.Tasks; 
//using System.Linq; 
 
//namespace KinderGartenManagment.Api.Repositories 
//{ 
//    public class ConventionRepository : IConventionRepository 
//    { 
//        private ApplicationDbContext _context; 
//        public ConventionRepository (ApplicationDbContext context) 
//        { 
//            _context = context; 
//        } 
//        public async Task<IEnumerable< Convention >> GetAll() 
//        { 
//            return await _context. Conventions .ToListAsync(); 
//        } 
 
//        public async Task< Convention > GetByIdAsync(int id) 
//        { 
//            return await _context. Conventions .FindAsync(id); 
//        } 
 
//        public async Task InsertAsync( Convention convention ) 
//        { 
//            await _context. Conventions .AddAsync( convention ); 
//        } 
 
//        public async Task DeleteAsync(int conventionId ) 
//        { 
//            Convention convention = await _context. Conventions .FindAsync( conventionId ); 
//            _context. Conventions .Remove( convention ); 
//        } 
 
//        public void Update( Convention convention ) 
//        { 
//            _context.Entry( convention ).State = EntityState.Modified; 
//        } 
 
//        public async Task SaveAsync() 
//        { 
//            await _context.SaveChangesAsync(); 
//        } 
 
//    } 
//} 
