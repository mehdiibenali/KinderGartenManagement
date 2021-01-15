using AutoMapper; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using KinderGartenManagment.Api.Models; 
using KinderGartenManagment.Api.ViewModels; 
using Microsoft.AspNetCore.Mvc; 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using KinderGartenManagment.Api.Context;

namespace KinderGartenManagment.Api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayementsController : ControllerBase
    {
        private readonly IPayementRepository _payementRepository;
        private readonly IPayementEnrollementRepository _payementEnrollementRepository;
        private readonly IModaliteRepository _modaliteRepository;
        private readonly IMapper _mapper;

        public PayementsController(IPayementRepository payementRepository, IPayementEnrollementRepository payementEnrollementRepository, IModaliteRepository modaliteRepository, IMapper imapper)
        {
            _payementRepository = payementRepository;
            _payementEnrollementRepository = payementEnrollementRepository;
            _modaliteRepository = modaliteRepository;
            _mapper = imapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Payement>> GetPayements()
        {
            var resultListe = await _payementRepository.GetAll();
            return resultListe;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Payement>> GetPayement(int id)
        {
            Payement payement = await _payementRepository.GetByIdAsync(id);

            if (payement == null)
            {
                return NotFound();
            }
                    
            return payement;
        }
        [HttpGet("GetUnpaid/{eleveids}")]
        public async Task<Object> GetUnpaid(string eleveids)
        {
            
            List<UnpaidViewModel> payementenrollements = await _payementRepository.GetUnpaid(eleveids);
     
            return payementenrollements.Where(pe=>pe.EnrollementPaid!="True").GroupBy(pe => new { pe.EleveId, pe.Prenom, pe.Nom }).Select(pe => new { eleve = pe.Key.Nom + ' ' + pe.Key.Prenom, payementenrollements =pe.ToList().GroupBy(pc => pc.EnrollementId).Select(pc => pc.ToList()) });
        }

        [HttpPost] 
        public async Task< Payement > PostPayement ( PayementViewModel payement ) 
        { 
            try 
            { 
                var p = _mapper.Map< Payement >( payement );
                await _payementRepository.InsertAsync(p);
                await _payementRepository.SaveAsync();
                foreach (PayementEnrollementViewModel payementenrollementviewmodel in payement.PayementEnrollementModels)
                {
                    var pe = _mapper.Map<PayementEnrollement>(payementenrollementviewmodel);
                    pe.PayementId = p.Id;
                    await _payementEnrollementRepository.InsertAsync(pe);
                    await _payementEnrollementRepository.SaveAsync();
                }
                foreach (ModaliteViewModel modalitesviewmodel in payement.ModaliteModels)
                {
                    var m = _mapper.Map<Modalite>(modalitesviewmodel);
                    m.PayementId = p.Id;
                    await _modaliteRepository.InsertAsync(m);
                    await _modaliteRepository.SaveAsync();
                }


                return p; 
            }
            catch (Exception e) 
            { 
                throw e; 
            } 
        }
        
        [HttpDelete("{id}")] 
        public async Task<Object> DeletePayement (int id) 
        { 
            await _payementRepository .DeleteAsync(id); 
            await _payementRepository .SaveAsync(); 
 
            return Ok(new { message = "Deleted Successfully" }); 
        } 
    } 
} 
