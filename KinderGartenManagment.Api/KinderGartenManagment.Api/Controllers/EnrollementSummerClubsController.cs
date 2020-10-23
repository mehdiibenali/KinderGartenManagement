using AutoMapper;
using KinderGartenManagment.Api.Interfaces.Repositories;
using KinderGartenManagment.Api.Models;
using KinderGartenManagment.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KinderGartenManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollementSummerClubsController : ControllerBase
    {
        private readonly IEnrollementSummerClubRepository _EnrollementRepository;
        private readonly IMapper _mapper;

        public EnrollementSummerClubsController(IEnrollementSummerClubRepository EnrollementRepository, IMapper imapper)
        {
            _EnrollementRepository = EnrollementRepository;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Enrollement>> GetEnrollements()
        {
            var resultListe = await _EnrollementRepository.GetAll();
            return resultListe;
        }
        [HttpGet("GetYears/{eleveid}")]
        public async Task<ActionResult<IEnumerable<object>>> GetYears(int eleveid)
        {
            var resultListe = await _EnrollementRepository.GetYears(eleveid);
            if (resultListe != null) { return Ok(resultListe); };
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollement>> GetEnrollement(int id)
        {
            Enrollement Enrollement = await _EnrollementRepository.GetByIdAsync(id);

            if (Enrollement == null)
            {
                return NotFound();
            }

            return Enrollement;
        }
        [HttpGet("SearchByYear/{anneededebut}/{anneedefin}")]
        public async Task<ActionResult<IEnumerable<Enrollement>>> SearchByYear(int anneededebut, int anneedefin)
        {
            IEnumerable<Enrollement> Enrollement = await _EnrollementRepository.SearchByYear(anneededebut, anneedefin);

            if (Enrollement == null)
            {
                return NotFound();
            }

            return Ok(Enrollement);
        }
        [HttpGet("SearchByName/{Enrollementsearch}")]
        public async Task<ActionResult<IEnumerable<Enrollement>>> SearchByName(string Enrollementsearch)
        {
            var result = await this._EnrollementRepository.SearchByName(Enrollementsearch);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
        [HttpGet("ByEleveId/{eleveId}")]
        public async Task<IEnumerable<Enrollement>> GetEnrollementsByEleveId(int eleveId)
        {
            var resultListe = await _EnrollementRepository.GetEnrollementsByEleveId(eleveId);
            return resultListe;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollement(int id, EnrollementViewModel Enrollement)
        {

            try
            {
                var p = _mapper.Map<Enrollement>(Enrollement);
                p.Id = id;
                _EnrollementRepository.Update(p);
                await _EnrollementRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<Enrollement> PostEnrollement(EnrollementViewModel Enrollement)
        {
            try
            {
                var p = _mapper.Map<Enrollement>(Enrollement);
                p.Type = "Club d'été";
                await _EnrollementRepository.InsertAsync(p);
                await _EnrollementRepository.SaveAsync();
                return await _EnrollementRepository.GetByIdAsync(p.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("{id}")]
        public async Task<Object> DeleteEnrollement(int id)
        {
            await _EnrollementRepository.DeleteAsync(id);
            await _EnrollementRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
