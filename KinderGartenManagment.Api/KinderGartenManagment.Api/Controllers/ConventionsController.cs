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
        private readonly IParentRepository _parentRepository;
        private readonly IMapper _mapper; 
 
        public ConventionsController ( IConventionRepository conventionRepository , IParentRepository parentRepository , IMapper imapper) 
        { 
            _conventionRepository = conventionRepository ;
            _parentRepository = parentRepository;
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< Convention >> GetConventions () 
        { 
            var resultListe = await _conventionRepository .GetAll(); 
            return resultListe; 
        }
        [HttpPost("GetActive")]
        public async Task<ActionResult<Convention>> GetActive(GetConventionViewModel gcvm)
        {
            Parent parent = await _parentRepository.GetByIdAsync(gcvm.ParentId);
            if (parent == null)     
            {
                return NotFound();
            }
            if (gcvm.DateTime == null) { gcvm.DateTime = DateTime.Now; };
            var result = await _conventionRepository.GetActive(gcvm.ParentId,gcvm.DateTime.Value);
            if (result == null)
            {
                return Ok();
            }

            return Ok(result);
        }
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<Convention>>> Search(SearchConventionViewModel searchconvention)
        {
            var resultListe = await _conventionRepository.Search(searchconvention.Name,searchconvention.annees);
            if (resultListe == null)
            {
                return NotFound();
            }

            return Ok(resultListe);
        }
        [HttpGet("GetYears")]
        public async Task<ActionResult<IEnumerable<Object>>> GetYears()
        {
            var resultliste = await _conventionRepository.GetYears();
            return Ok(resultliste);
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
        public async Task< Convention > PostConvention ( ConventionViewModel convention) 
        { 
            try 
            { 
                var c = _mapper.Map< Convention >( convention ); 
                await _conventionRepository .InsertAsync(c); 
                await _conventionRepository .SaveAsync(); 
                return c; 
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
