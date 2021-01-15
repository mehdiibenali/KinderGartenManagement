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
        [HttpGet("{code}")] 
        public async Task<ActionResult< IEnumerable<Parameter> >> GetParameter (string code) 
        { 
            IEnumerable<Parameter> parameters = await _parameterRepository .GetByCodeAsync(code); 
 
            if ( parameters == null) 
            { 
                return NotFound(); 
            } 
 
            return Ok(parameters) ; 
        }
        [HttpGet("GetDates/{annee}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetDates(string annee)
        {
            IEnumerable<Parameter> CurrentScholarYear = await _parameterRepository.GetByCodeAsync("CurrentScholarYear");
            DateTime Start;
            string anneededebut = CurrentScholarYear.First().Value.Split('-')[0];
            if (anneededebut == annee)
            {
                IEnumerable<Parameter> datededebut = await _parameterRepository.GetByCodeAsync("ScholarYearBeginning");
                Start = DateTime.Parse(datededebut.First().Value + " " + anneededebut);
            }
            else
            {
                Start = DateTime.Parse("January 1 " + annee);
            }
            DateTime End;
            string anneedefin = CurrentScholarYear.First().Value.Split('-')[1];
            if (anneedefin == annee)
            {
                IEnumerable<Parameter> datedefin = await _parameterRepository.GetByCodeAsync("ScholarYearEnd");
                End = DateTime.Parse(datedefin.First().Value + " " + anneedefin);
            }
            else
            {
                End = DateTime.Parse("December 31 " + annee);
            }
            IEnumerable<Object> dates = await _parameterRepository.GetDates(Start,End);
            if (dates == null)
            {
                return NotFound();
            }

            return Ok(dates);
        }
        [HttpPost("GetMonthDates")]
        public async Task<Object> GetMonthDates(MonthYearViewModel myvm)
        {
     
                List<DatesViewModel> result = await _parameterRepository.GetMonthDates(myvm.Month, myvm.Year);
                return result;
            
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
