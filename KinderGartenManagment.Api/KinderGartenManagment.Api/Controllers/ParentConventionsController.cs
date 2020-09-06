using AutoMapper; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using KinderGartenManagment.Api.Models; 
using KinderGartenManagment.Api.ViewModels; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
 
namespace KinderGartenManagment.Api.Controllers 
{ 
    [Route("api/[controller]")] 
    [ApiController] 
    public class ParentConventionsController : ControllerBase 
    { 
        private readonly IParentConventionRepository _parentConventionRepository ; 
        private readonly IMapper _mapper; 
 
        public ParentConventionsController ( IParentConventionRepository parentConventionRepository , IMapper imapper) 
        { 
            _parentConventionRepository = parentConventionRepository ; 
            _mapper = imapper; 
        } 
        [HttpGet] 
        public async Task<IEnumerable< ParentConvention >> GetParentConventions () 
        { 
            var resultListe = await _parentConventionRepository .GetAll(); 
            return resultListe; 
        } 
        [HttpGet("{parentid}/{conventionid}/{datededebut}")] 
        public async Task<ActionResult< ParentConvention >> GetParentConvention (int parentid, int conventionid, DateTime datededebut) 
        { 
            ParentConvention parentconvention = await _parentConventionRepository .GetByIdAsync(parentid,conventionid,datededebut); 
 
            if ( parentconvention == null) 
            { 
                return Ok(); 
            } 
 
            return parentconvention ; 
        }
        [HttpPut]
        public async Task<ParentConvention> PutParent(ParentConventionViewModel parentconvention)
        {

            try
            {
                var pc = _mapper.Map<ParentConvention>(parentconvention);
                _parentConventionRepository.Update(pc);
                await _parentConventionRepository.SaveAsync();
                return pc;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
           
        }
        [HttpPut("DisableConventionActive/{parentid}")]
        public async Task<IActionResult> DisableConventionActive(int parentid)
        {

            try
            {
                await _parentConventionRepository.DisableConventionActive(parentid);
                await _parentConventionRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> AddParentConvention( AddParentConventionViewModel pcvm) 
        {
             try
             {
                await _parentConventionRepository.DisableConventionActive(pcvm.ParentId);
                await _parentConventionRepository.SaveAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
               throw;
             }
            if (pcvm.NewConventionId != null)
            {
                try
                {
                    ParentConvention pc = new ParentConvention
                    {
                        ParentId = pcvm.ParentId,
                        ConventionId = pcvm.NewConventionId.Value,
                        DateDeDebut = DateTime.Now,
                    };
                    await _parentConventionRepository.InsertAsync(pc);
                    await _parentConventionRepository.SaveAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return Ok();
        } 
 
        [HttpDelete("{id}")] 
        public async Task<Object> DeleteParentConvention (int id) 
        { 
            await _parentConventionRepository .DeleteAsync(id); 
            await _parentConventionRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 
