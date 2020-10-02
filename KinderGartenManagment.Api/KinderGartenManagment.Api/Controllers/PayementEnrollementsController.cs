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
    public class PayementEnrollementsController : ControllerBase 
    { 
        private readonly IPayementEnrollementRepository _payementEnrollementRepository ; 
        private readonly IMapper _mapper; 
 
        public PayementEnrollementsController ( IPayementEnrollementRepository payementEnrollementRepository , IMapper imapper) 
        { 
            _payementEnrollementRepository = payementEnrollementRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< PayementEnrollement >> GetPayementEnrollements () 
        { 
            var resultListe = await _payementEnrollementRepository .GetAll(); 
            return resultListe; 
        } 
        [HttpGet("{id}")] 
        public async Task<ActionResult< PayementEnrollement >> GetPayementEnrollement (int id) 
        { 
            PayementEnrollement payementenrollement = await _payementEnrollementRepository .GetByIdAsync(id); 
 
            if ( payementenrollement == null) 
            { 
                return NotFound(); 
            } 
 
            return payementenrollement ; 
        } 
 
 
        [HttpPost] 
        public async Task< PayementEnrollement > PostPayementEnrollement ( PayementEnrollementViewModel payementenrollement ) 
        { 
            try 
            { 
                var p = _mapper.Map< PayementEnrollement >( payementenrollement ); 
                await _payementEnrollementRepository .InsertAsync(p); 
                await _payementEnrollementRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeletePayementEnrollement (int id) 
        { 
            await _payementEnrollementRepository .DeleteAsync(id); 
            await _payementEnrollementRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 
