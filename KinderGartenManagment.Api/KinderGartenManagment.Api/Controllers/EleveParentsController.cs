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
    public class EleveParentsController : ControllerBase
    {
        private readonly IEleveParentRepository _eleveParentRepository;
        private readonly IMapper _mapper;

        public EleveParentsController(IEleveParentRepository eleveParentRepository, IMapper imapper)
        {
            _eleveParentRepository = eleveParentRepository;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable<EleveParent>> GetEleveParents()
        {
            var resultListe = await _eleveParentRepository.GetAll();
            return resultListe;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleveParent(int id, EleveParentViewModel eleveparent)
        {

            try
            {
                var p = _mapper.Map<EleveParent>(eleveparent);
                _eleveParentRepository.Update(p);
                await _eleveParentRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<EleveParent> PostEleveParent(EleveParentViewModel eleveparent)
        {
            try
            {
                var p = _mapper.Map<EleveParent>(eleveparent);
                await _eleveParentRepository.InsertAsync(p);
                await _eleveParentRepository.SaveAsync();
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("{id}")]
        public async Task<Object> DeleteEleveParent(int id)
        {
            await _eleveParentRepository.DeleteAsync(id);
            await _eleveParentRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
