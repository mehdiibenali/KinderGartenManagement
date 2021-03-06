﻿using AutoMapper;
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
        [HttpGet("{eleveid}/{parentid}")]
        public async Task<ActionResult<EleveParent>> GetEleveParentsById(int eleveid,int parentid)
        {
            var result = await _eleveParentRepository.GetByIdAsync(eleveid,parentid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetByParentTuteur/{eleveid}")]
        public async Task<ActionResult<EleveParent>> GetByParentTuteur(int eleveid)
        {
            var result = await _eleveParentRepository.GetByEleveIdParentTuteur(eleveid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("{eleveid}/{parentid}")]
        public async Task<IActionResult> PutEleveParent(int eleveid, int parentid)
        {

            try
            {
                await _eleveParentRepository.UpdateAsync(eleveid,parentid);
                await _eleveParentRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }
        [HttpPut("DisableParentTuteur/{eleveid}")]
        public async Task<IActionResult> DisableParentTuteur(int eleveid)
        {

            try
            {
                await _eleveParentRepository.DisableParentTuteurAsync(eleveid);
                await _eleveParentRepository.SaveAsync();
                return Ok();    
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
        [HttpDelete("{eleveid}/{parentid}")]
        public async Task<Object> DeleteEleveParent(int eleveid,int parentid)
        {
            await _eleveParentRepository.DeleteAsync(eleveid,parentid);
            await _eleveParentRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
