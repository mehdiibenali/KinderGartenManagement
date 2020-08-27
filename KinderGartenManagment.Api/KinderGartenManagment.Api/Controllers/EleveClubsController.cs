///using AutoMapper; 
//using KinderGartenManagment.Api.Interfaces.Repositories; 
//using KinderGartenManagment.Api.Models; 
//using KinderGartenManagment.Api.ViewModels; 
//using Microsoft.AspNetCore.Mvc; 
//using System; 
//using System.Collections.Generic; 
//using System.Linq; 
//using System.Threading.Tasks; 
 
//namespace KinderGartenManagment.Api.Controllers 
//{ 
//    [Route("api/[controller]")] 
//    [ApiController] 
//    public class EleveClubsController : ControllerBase 
//    { 
//        private readonly IEleveClubRepository _eleveClubRepository ; 
//        private readonly IMapper _mapper; 
 
//        public EleveClubsController ( IEleveClubRepository eleveClubRepository , IMapper imapper) 
//        { 
//            _eleveClubRepository = eleveClubRepository ; 
//            _mapper = imapper; 
//        } 
//        [HttpGet] 
//        public async Task<IEnumerable< EleveClub >> GetEleveClubs () 
//        { 
//            var resultListe = await _eleveClubRepository .GetAll(); 
//            return resultListe; 
//        } 
//        [HttpGet("{id}")] 
//        public async Task<ActionResult< EleveClub >> GetEleveClub (int id) 
//        { 
//            EleveClub eleveclub = await _eleveClubRepository .GetByIdAsync(id); 
 
//            if ( eleveclub == null) 
//            { 
//                return NotFound(); 
//            } 
 
//            return eleveclub ; 
//        } 
 
//        //    return groupe; 
//        //} 
 
//        //PUT: api/PublishingHouses/5 
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754. 
//        //[HttpPut("{id}")] 
//        //public async Task<IActionResult> PutPublishingHouse(int id, PublishingHouseViewModel publishingHouse) 
//        //{ 
 
//        //    try 
//        //    { 
//        //        var p = _mapper.Map<PublishingHouse>(publishingHouse); 
//        //        p.Id = id; 
//        //        _publishingHouseRepository.Update(p); 
//        //        await _publishingHouseRepository.SaveAsync(); 
//        //    } 
//        //    catch (DbUpdateConcurrencyException) 
//        //    { 
//        //        throw; 
//        //    } 
//        //    return NoContent(); 
//        //} 
 
//        [HttpPost] 
//        public async Task< EleveClub > PostEleveClub ( EleveClubViewModel eleveclub ) 
//        { 
//            try 
//            { 
//                var p = _mapper.Map< EleveClub >( eleveclub ); 
//                await _eleveClubRepository .InsertAsync(p); 
//                await _eleveClubRepository .SaveAsync(); 
//                return p; 
//            } 
//            catch (Exception e) 
//            { 
//                throw e; 
//            } 
//        } 
 
//        [HttpDelete("{id}")] 
//        public async Task<Object> DeleteEleveClub (int id) 
//        { 
//            await _eleveClubRepository .DeleteAsync(id); 
//            await _eleveClubRepository .SaveAsync(); 
 
//            return Ok(new { message = "Deleted Successfully" }); 
//        } 
//    } 
//} 
