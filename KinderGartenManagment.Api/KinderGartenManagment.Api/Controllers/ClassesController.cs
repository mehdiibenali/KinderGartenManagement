using AutoMapper;
using KinderGartenManagment.Api.Interfaces.Repositories;
using KinderGartenManagment.Api.Models;
using KinderGartenManagment.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload([FromForm] IFormFile file)
        {
            try
            {
                //var file = Request.Form.Files[0];
                var pathToSave = "C:/Users/ASUS/Desktop/HexaApp/HexaApp.api/HexaApp.api/Resources";
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = pathToSave + "/" + fileName;
                    var dbPath = "assets/" + fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                    //return StatusCode(200, dbPath) ;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
