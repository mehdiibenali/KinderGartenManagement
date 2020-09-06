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
    public class ConventionFeesController : ControllerBase 
    { 
        private readonly IConventionFeeRepository _conventionFeeRepository ; 
        private readonly IMapper _mapper; 
 
        public ConventionFeesController ( IConventionFeeRepository conventionFeeRepository , IMapper imapper) 
        { 
            _conventionFeeRepository = conventionFeeRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< ConventionFee >> GetConventionFees () 
        { 
            var resultListe = await _conventionFeeRepository .GetAll(); 
            return resultListe; 
        } 
        [HttpGet("{id}")] 
        public async Task<ActionResult< ConventionFee >> GetConventionFee (int id) 
        { 
            ConventionFee conventionfee = await _conventionFeeRepository .GetByIdAsync(id); 
 
            if ( conventionfee == null) 
            { 
                return NotFound(); 
            } 
 
            return conventionfee ; 
        } 
 
        [HttpPost] 
        public async Task< ConventionFee > PostConventionFee ( ConventionFeeViewModel conventionfee ) 
        { 
            try 
            { 
                var p = _mapper.Map< ConventionFee >( conventionfee ); 
                await _conventionFeeRepository .InsertAsync(p); 
                await _conventionFeeRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeleteConventionFee (int id) 
        { 
            await _conventionFeeRepository .DeleteAsync(id); 
            await _conventionFeeRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 
