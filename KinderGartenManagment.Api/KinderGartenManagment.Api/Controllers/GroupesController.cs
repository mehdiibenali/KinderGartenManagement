﻿using AutoMapper;
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
    public class GroupesController : ControllerBase
    {
        private readonly IGroupeRepository _groupeRepository;
        private readonly IMapper _mapper;

        public GroupesController(IGroupeRepository groupeRepository, IMapper imapper)
        {
            _groupeRepository = groupeRepository;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Groupe>> GetGroupes()
        {
            var resultListe = await _groupeRepository.GetAll();
            return resultListe;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Groupe>> GetGroupe(int id)
        {
            Groupe groupe = await _groupeRepository.GetByIdAsync(id);

            if (groupe == null)
            {
                return NotFound();
            }

            return groupe;
        }   
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
        public async Task<Groupe> PostGroupe(GroupeViewModel groupe)
        {
            try
            {
                var p = _mapper.Map<Groupe>(groupe);    
                await _groupeRepository.InsertAsync(p);
                await _groupeRepository.SaveAsync();
                return await _groupeRepository.GetByIdAsync(p.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("{id}")]
        public async Task<Object> DeleteGroupe(int id)
        {
            await _groupeRepository.DeleteAsync(id);
            await _groupeRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}