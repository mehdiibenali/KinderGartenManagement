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
    public class ClassesController : ControllerBase
    {
        private readonly IClasseRepository _classeRepository;
        private readonly IMapper _mapper;

        public ClassesController(IClasseRepository classeRepository, IMapper imapper)
        {
            _classeRepository = classeRepository;
            _mapper = imapper;
        }
        // GET: api/PublishingHouses
        [HttpGet]
        public async Task<IEnumerable<Classe>> GetClasses()
        {
            var resultListe = await _classeRepository.GetAll();
            return resultListe;
        }
        // GET: api/PublishingHouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classe>> GetClasse(int id)
        {
            Classe classe = await _classeRepository.GetByIdAsync(id);

            if (classe == null)
            {
                return NotFound();
            }

            return classe;
        }

        //    return groupe;
        //}

        //PUT: api/PublishingHouses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPublishingHouse(int id, PublishingHouseViewModel publishingHouse)
        //{

        //    try
        //    {
        //        var p = _mapper.Map<PublishingHouse>(publishingHouse);
        //        p.Id = id;
        //        _publishingHouseRepository.Update(p);
        //        await _publishingHouseRepository.SaveAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }
        //    return NoContent();
        //}

        [HttpPost]
        public async Task<Classe> PostClasse(ClasseViewModel groupe)
        {
            try
            {
                var p = _mapper.Map<Classe>(groupe);
                await _classeRepository.InsertAsync(p);
                await _classeRepository.SaveAsync();
                //return await _classeRepository.GetByIdAsync(p.Id);
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        public async Task<Object> DeleteClasse(int id)
        {
            await _classeRepository.DeleteAsync(id);
            await _classeRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
