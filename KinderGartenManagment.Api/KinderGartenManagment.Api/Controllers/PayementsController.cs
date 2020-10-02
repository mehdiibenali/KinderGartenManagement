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
    public class PayementsController : ControllerBase 
    { 
        private readonly IPayementRepository _payementRepository ; 
        private readonly IMapper _mapper; 
 
        public PayementsController ( IPayementRepository payementRepository , IMapper imapper) 
        { 
            _payementRepository = payementRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< Payement >> GetPayements () 
        { 
            var resultListe = await _payementRepository .GetAll(); 
            return resultListe; 
        } 
        [HttpGet("{id}")] 
        public async Task<ActionResult< Payement >> GetPayement (int id) 
        { 
            Payement payement = await _payementRepository .GetByIdAsync(id); 
 
            if ( payement == null) 
            { 
                return NotFound(); 
            } 
 
            return payement ; 
        } 
 
 
        [HttpPost] 
        public async Task< Payement > PostPayement ( PayementViewModel payement ) 
        { 
            try 
            { 
                var p = _mapper.Map< Payement >( payement ); 
                await _payementRepository .InsertAsync(p); 
                await _payementRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeletePayement (int id) 
        { 
            await _payementRepository .DeleteAsync(id); 
            await _payementRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 
