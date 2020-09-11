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
    public class ElevesController : ControllerBase
    {
        private readonly IEleveRepository _eleveRepository;
        private readonly IMapper _mapper;

        public ElevesController(IEleveRepository eleveRepository, IMapper imapper)
        {
            _eleveRepository = eleveRepository;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Eleve>> GetEleves()
        {
            var resultListe = await _eleveRepository.GetAll();
            return resultListe;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetEleve(int id)
        {
            Eleve eleve = await _eleveRepository.GetByIdAsync(id);

            if (eleve == null)
            {
                return NotFound();
            }

            return eleve;
        }
        [HttpPost("Search")]
        public async Task<IEnumerable<Eleve>> Search(SearchEleveViewModel search)
        {
            var resultListe = await _eleveRepository.Search(search.EleveSearch,search.ParentSearch,search.Sexe,search.HasConvention,search.ClasseId,search.GroupeId,search.ClubId,search.ConventionId);
            return resultListe;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleve(int id, EleveViewModel eleve)
        {

            try
            {
                var p = _mapper.Map<Eleve>(eleve);
                p.Id = id;
                _eleveRepository.Update(p);
                await _eleveRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<Eleve> PostEleve(EleveViewModel eleve)
        {
            try
            {
                var p = _mapper.Map<Eleve>(eleve);
                await _eleveRepository.InsertAsync(p);
                await _eleveRepository.SaveAsync();
                return await _eleveRepository.GetByIdAsync(p.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("{id}")]
        public async Task<Object> DeleteEleve(int id)
        {
            await _eleveRepository.DeleteAsync(id);
            await _eleveRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
