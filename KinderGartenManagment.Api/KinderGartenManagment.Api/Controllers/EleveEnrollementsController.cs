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
    public class EleveEnrollementsController : ControllerBase 
    { 
        private readonly IEleveEnrollementRepository _eleveEnrollementRepository ; 
        private readonly IMapper _mapper; 
 
        public EleveEnrollementsController ( IEleveEnrollementRepository eleveEnrollementRepository , IMapper imapper) 
        { 
            _eleveEnrollementRepository = eleveEnrollementRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< EleveEnrollement >> GetEleveEnrollements () 
        { 
            var resultListe = await _eleveEnrollementRepository .GetAll(); 
            return resultListe; 
        }
        [HttpPost("GetCurrentEleveEnrollement")]
        public async Task<Object> GetCurrentEleveEnrollement(GetCurrentEleveEnrollementViewModel gcee)
        {
            try
            {
                var result = await _eleveEnrollementRepository.GetCurrentEleveEnrollement(gcee.Date, gcee.EleveId);
                if (result != null)
                {
                    return result.DateDeFin;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost] 
        public async Task< EleveEnrollement > PostEleveEnrollement ( EleveEnrollementViewModel eleveEnrollement ) 
        { 
            try 
            { 
                var p = _mapper.Map< EleveEnrollement >( eleveEnrollement ); 
                await _eleveEnrollementRepository .InsertAsync(p); 
                await _eleveEnrollementRepository .SaveAsync(); 
                return p; 
            } 
            catch (Exception e) 
            { 
                throw e; 
            } 
        }

        [HttpDelete("{eleveid}/{Enrollementid}/{Datededebut}")]
        public async Task<Object> DeleteEleveParent(int eleveid, int Enrollementid, DateTime Datededebut)
        {
            await _eleveEnrollementRepository.DeleteAsync(eleveid, Enrollementid, Datededebut);
            await _eleveEnrollementRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    } 
} 
