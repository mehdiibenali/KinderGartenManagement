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
    public class ClassesController : ControllerBase
    {
        private readonly IClasseRepository _classeRepository ;
        private readonly IMapper _mapper;

        public ClassesController ( IClasseRepository classeRepository , IMapper imapper)
        {
            _classeRepository = classeRepository ;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable< Classe >> GetClasses ()
        {
            var resultListe = await _classeRepository .GetAll();
            return resultListe;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult< Classe >> GetClasse (int id)
        {
            Classe classe = await _classeRepository .GetByIdAsync(id);

            if ( classe == null)
            {
                return NotFound();
            }

            return classe;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasse(int id, ClasseViewModel classe)
        {

            try
            {
                var p = _mapper.Map<Classe>(classe);
                p.Id = id;
                _classeRepository.Update(p);
                await _classeRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task< Classe > PostClasse ( ClasseViewModel classe)
        {
            try
            {
                var p = _mapper.Map< Classe >( classe );
                await _classeRepository .InsertAsync(p);
                await _classeRepository .SaveAsync();
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        public async Task<Object> DeleteClasse (int id)
        {
            await _classeRepository .DeleteAsync(id);
            await _classeRepository .SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
