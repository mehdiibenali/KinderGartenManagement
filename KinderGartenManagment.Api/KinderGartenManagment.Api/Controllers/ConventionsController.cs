using AutoMapper; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using KinderGartenManagment.Api.Models; 
using KinderGartenManagment.Api.ViewModels; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
 
namespace KinderGartenManagment.Api.Controllers 
{ 
    [Route("api/[controller]")] 
    [ApiController] 
    public class ConventionsController : ControllerBase 
    { 
        private readonly IConventionRepository _conventionRepository ; 
        private readonly IMapper _mapper; 
 
        public ConventionsController ( IConventionRepository conventionRepository , IMapper imapper) 
        { 
            _conventionRepository = conventionRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< Convention >> GetConventions () 
        { 
            var resultListe = await _conventionRepository .GetAll(); 
            return resultListe; 
        }
        [HttpGet("GetActive/{parentid}/{datetime}")]
        public async Task<ActionResult<Convention>> GetActive(int parentid,DateTime datetime)
        {
            var resultListe = await _conventionRepository.GetActive(parentid,datetime);
            if (resultListe == null)
            {
                return NotFound();
            }

            return Ok(resultListe);
        }
        [HttpGet("SearchByYear/{year}")]
        public async Task<ActionResult<IEnumerable<Convention>>> SearchByYear(int year)
        {
            var resultListe = await _conventionRepository.SearchByYear(year);
            if (resultListe == null)
            {
                return NotFound();
            }

            return Ok(resultListe);
        }
        [HttpGet("{id}")] 
        public async Task<ActionResult< Convention >> GetConvention (int id) 
        { 
            Convention convention = await _conventionRepository .GetByIdAsync(id); 
 
            if ( convention == null) 
            { 
                return NotFound(); 
            } 
 
            return convention ; 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConvention(int id, ConventionViewModel convention)
        {

            try
            {
                var p = _mapper.Map<Convention>(convention);
                p.Id = id;
                _conventionRepository.Update(p);
                await _conventionRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost] 
        public async Task< Convention > PostConvention ( ConventionViewModel convention ) 
        { 
            try 
            { 
                var p = _mapper.Map< Convention >( convention ); 
                await _conventionRepository .InsertAsync(p); 
                await _conventionRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeleteConvention (int id) 
        { 
            await _conventionRepository .DeleteAsync(id); 
            await _conventionRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        }
    } 
} 
