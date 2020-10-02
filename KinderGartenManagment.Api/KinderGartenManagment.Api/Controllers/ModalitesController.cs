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
    public class ModalitesController : ControllerBase 
    { 
        private readonly IModaliteRepository _modaliteRepository ; 
        private readonly IMapper _mapper; 
 
        public ModalitesController ( IModaliteRepository modaliteRepository , IMapper imapper) 
        { 
            _modaliteRepository = modaliteRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< Modalite >> GetModalites () 
        { 
            var resultListe = await _modaliteRepository .GetAll(); 
            return resultListe; 
        } 
        [HttpGet("{id}")] 
        public async Task<ActionResult< Modalite >> GetModalite (int id) 
        { 
            Modalite modalite = await _modaliteRepository .GetByIdAsync(id); 
 
            if ( modalite == null) 
            { 
                return NotFound(); 
            } 
 
            return modalite ; 
        } 
 
 
        [HttpPost] 
        public async Task< Modalite > PostModalite ( ModaliteViewModel modalite ) 
        { 
            try 
            { 
                var p = _mapper.Map< Modalite >( modalite ); 
                await _modaliteRepository .InsertAsync(p); 
                await _modaliteRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeleteModalite (int id) 
        { 
            await _modaliteRepository .DeleteAsync(id); 
            await _modaliteRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 
