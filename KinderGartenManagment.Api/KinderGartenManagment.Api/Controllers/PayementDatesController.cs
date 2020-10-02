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
    public class PayementDatesController : ControllerBase
    {
        private readonly IPayementDatesRepository _payementDatesRepository;
        private readonly IMapper _mapper;

        public PayementDatesController(IPayementDatesRepository payementDatesRepository, IMapper imapper)
        {
            _payementDatesRepository = payementDatesRepository;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PayementDates>> GetPayementDates()
        {
            var resultListe = await _payementDatesRepository.GetAll();
            return resultListe;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PayementDates>> GetPayementDates(int id)
        {
            PayementDates payementdates = await _payementDatesRepository.GetByIdAsync(id);

            if (payementdates == null)
            {
                return NotFound();
            }

            return payementdates;
        }


        [HttpPost]
        public async Task<PayementDates> PostPayementDates(PayementDatesViewModel payementdates)
        {
            try
            {
                var p = _mapper.Map<PayementDates>(payementdates);
                await _payementDatesRepository.InsertAsync(p);
                await _payementDatesRepository.SaveAsync();
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        public async Task<Object> DeletePayementDates(int id)
        {
            await _payementDatesRepository.DeleteAsync(id);
            await _payementDatesRepository.SaveAsync();

            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
