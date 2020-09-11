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
    public class ParametersController : ControllerBase 
    { 
        private readonly IParameterRepository _parameterRepository ; 
        private readonly IMapper _mapper; 
 
        public ParametersController ( IParameterRepository parameterRepository , IMapper imapper) 
        { 
            _parameterRepository = parameterRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< Parameter >> GetParameters () 
        { 
            var resultListe = await _parameterRepository .GetAll(); 
            return resultListe; 
        } 
        [HttpGet("{id}")] 
        public async Task<ActionResult< Parameter >> GetParameter (int id) 
        { 
            Parameter parameter = await _parameterRepository .GetByIdAsync(id); 
 
            if ( parameter == null) 
            { 
                return NotFound(); 
            } 
 
            return parameter ; 
        } 
 
 
        [HttpPost] 
        public async Task< Parameter > PostParameter ( ParameterViewModel parameter ) 
        { 
            try 
            { 
                var p = _mapper.Map< Parameter >( parameter ); 
                await _parameterRepository .InsertAsync(p); 
                await _parameterRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeleteParameter (int id) 
        { 
            await _parameterRepository .DeleteAsync(id); 
            await _parameterRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 