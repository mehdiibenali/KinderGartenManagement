using AutoMapper; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using KinderGartenManagment.Api.Models; 
using KinderGartenManagment.Api.ViewModels; 
using Microsoft.AspNetCore.Mvc; 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
 
namespace KinderGartenManagment.Api.Controllers 
{ 
    [Route("api/[controller]")] 
    [ApiController] 
    public class EleveGroupesController : ControllerBase 
    { 
        private readonly IEleveGroupeRepository _eleveGroupeRepository ; 
        private readonly IMapper _mapper; 
 
        public EleveGroupesController ( IEleveGroupeRepository eleveGroupeRepository , IMapper imapper) 
        { 
            _eleveGroupeRepository = eleveGroupeRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< EleveGroupe >> GetEleveGroupes () 
        { 
            var resultListe = await _eleveGroupeRepository .GetAll(); 
            return resultListe; 
        } 

        //[HttpPut("{id}")] 
        //public async Task<IActionResult> PutPublishingHouse(int id, PublishingHouseViewModel publishingHouse) 
        //{ 
 
        //    try 
        //    { 
        //        var p = _mapper.Map<PublishingHouse>(publishingHouse); 
        //        p.Id = id; 
        //        _publishingHouseRepository.Update(p); 
        //        await _publishingHouseRepository.SaveAsync(); 
        //    } 
        //    catch (DbUpdateConcurrencyException) 
        //    { 
        //        throw; 
        //    } 
        //    return NoContent(); 
        //} 
 
        [HttpPost] 
        public async Task< EleveGroupe > PostEleveGroupe ( EleveGroupeViewModel elevegroupe ) 
        { 
            try 
            { 
                var p = _mapper.Map< EleveGroupe >( elevegroupe ); 
                await _eleveGroupeRepository .InsertAsync(p); 
                await _eleveGroupeRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeleteEleveGroupe (int id) 
        { 
            await _eleveGroupeRepository .DeleteAsync(id); 
            await _eleveGroupeRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 
