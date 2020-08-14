//using System.Collections.Generic; 
//using KinderGartenManagment.Api.Models; 
//using Microsoft.EntityFrameworkCore; 
//using KinderGartenManagment.Api.Context; 
//using KinderGartenManagment.Api.Interfaces.Repositories; 
//using System.Threading.Tasks; 
//using System.Linq; 
 
//namespace KinderGartenManagment.Api.Repositories 
//{ 
//    public class ClubRepository : IClubRepository 
//    { 
//        private ApplicationDbContext _context; 
//        public ClubRepository (ApplicationDbContext context) 
//        { 
//            _context = context; 
//        } 
//        public async Task<IEnumerable< Club >> GetAll() 
//        { 
//            return await _context. Clubs .ToListAsync(); 
//        } 
 
//        public async Task< Club > GetByIdAsync(int id) 
//        { 
//            return await _context. Clubs .FindAsync(id); 
//        } 
 
//        public async Task InsertAsync( Club club ) 
//        { 
//            await _context. Clubs .AddAsync( club ); 
//        } 
 
//        public async Task DeleteAsync(int clubId ) 
//        { 
//            Club club = await _context. Clubs .FindAsync( clubId ); 
//            _context. Clubs .Remove( club ); 
//        } 
 
//        public void Update( Club club ) 
//        { 
//            _context.Entry( club ).State = EntityState.Modified; 
//        } 
 
//        public async Task SaveAsync() 
//        { 
//            await _context.SaveChangesAsync(); 
//        } 
 
//    } 
//} 
