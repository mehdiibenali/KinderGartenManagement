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
    public class ParentsController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;
        private readonly IMapper _mapper;

        public ParentsController(IParentRepository parentRepository, IMapper imapper)
        {
            _parentRepository = parentRepository;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Parent>> GetParents()
        {
            var resultListe = await _parentRepository.GetAll();
            return resultListe;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetParent(int id)
        {
            Parent parent = await _parentRepository.GetByIdAsync(id);

            if (parent == null)
            {
                return NotFound();
            }

            return parent;
        }
        [HttpGet("SearchByName/{parentsearch}")]
        public async Task<ActionResult<IEnumerable<Parent>>> SearchByName(string parentsearch)
        {
            var result = await this._parentRepository.SearchByName(parentsearch);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
            
        }
        [HttpGet("ByEleveId/{eleveId}")]
        public async Task<IEnumerable<Object>> GetParentsByEleveId(int eleveId)
        {
            var resultListe = await _parentRepository.GetParentsByEleveId(eleveId);
            return resultListe;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParent(int id, ParentViewModel parent)
        {

            try
            {
                var p = _mapper.Map<Parent>(parent);
                p.Id = id;
                _parentRepository.Update(p);
                await _parentRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<Parent> PostParent(ParentViewModel parent)
        {
            try
            {
                var p = _mapper.Map<Parent>(parent);
                await _parentRepository.InsertAsync(p);
                await _parentRepository.SaveAsync();
                return await _parentRepository.GetByIdAsync(p.Id);
            }
            catch (Exception e) 
            {
                throw e;
            }
        }
        [HttpDelete("{id}")]
        public async Task<Object> DeleteParent(int id)
        {
            await _parentRepository.DeleteAsync(id);
            await _parentRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}

