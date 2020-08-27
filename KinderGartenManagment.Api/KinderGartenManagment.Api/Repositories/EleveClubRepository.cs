//using System.Collections.Generic; 
//using KinderGartenManagment.Api.Models; 
//using Microsoft.EntityFrameworkCore; 
//using KinderGartenManagment.Api.Context; 
//using KinderGartenManagment.Api.Interfaces.Repositories; 
//using System.Threading.Tasks; 
//using System.Linq; 
 
//namespace KinderGartenManagment.Api.Repositories 
//{ 
//    public class EleveClubRepository : IEleveClubRepository 
//    { 
//        private ApplicationDbContext _context; 
//        public EleveClubRepository (ApplicationDbContext context) 
//        { 
//            _context = context; 
//        } 
//        public async Task<IEnumerable< EleveClub >> GetAll() 
//        { 
//            return await _context. EleveClubs .ToListAsync(); 
//        } 
 
//        public async Task< EleveClub > GetByIdAsync(int id) 
//        { 
//            return await _context. EleveClubs .FindAsync(id); 
//        } 
 
//        public async Task InsertAsync( EleveClub eleveclub ) 
//        { 
//            await _context. EleveClubs .AddAsync( eleveclub ); 
//        } 
 
//        public async Task DeleteAsync(int eleveclubId ) 
//        { 
//            EleveClub eleveclub = await _context. EleveClubs .FindAsync( eleveclubId ); 
//            _context. EleveClubs .Remove( eleveclub ); 
//        } 
 
//        public void Update( EleveClub eleveclub ) 
//        { 
//            _context.Entry( eleveclub ).State = EntityState.Modified; 
//        } 
 
//        public async Task SaveAsync() 
//        { 
//            await _context.SaveChangesAsync(); 
//        } 
 
//    } 
//} 
