using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq;
using System;
using KinderGartenManagment.Api.ViewModels;
using AutoMapper;

namespace KinderGartenManagment.Api.Repositories 
{ 
    public class EleveEnrollementRepository : IEleveEnrollementRepository 
    { 
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EleveEnrollementRepository (ApplicationDbContext context, IMapper imapper) 
        { 
            _context = context;
            _mapper = imapper;
        }
        public async Task<IEnumerable< EleveEnrollement >> GetAll() 
        { 
            return await _context.EleveEnrollements.Include(c => c.Eleve).Include(c => c.Enrollement).ToListAsync(); 
        } 
 
 
        public async Task InsertAsync( EleveEnrollement eleveEnrollement ) 
        {
            await _context. EleveEnrollements .AddAsync( eleveEnrollement );
            Enrollement enrollement = await _context.Enrollements.Where(e => e.Id == eleveEnrollement.EnrollementId).FirstOrDefaultAsync();
            if (enrollement.Type == "Groupe")
            {
                EleveEnrollement currentEleveEnrollement = await _context.EleveEnrollements.Include(ee => ee.Enrollement).Where(ee => ee.Enrollement.Type == "Groupe" && ee.DateDeFin > eleveEnrollement.DateDeDebut && ee.EleveId == eleveEnrollement.EleveId).FirstOrDefaultAsync();
                if (currentEleveEnrollement != null)
                {
                    PayementEnrollement currentPayementEnrollement = new PayementEnrollement();
                    var paid = 0;
                    List<PayementEnrollement> currentPayementEnrollements = await _context.PayementEnrollements.Where(pe => pe.EleveEnrollementId == currentEleveEnrollement.Id && pe.DateDeFin == currentEleveEnrollement.DateDeFin).ToListAsync();
                    if (currentPayementEnrollements.Count > 0)
                    {
                        foreach (PayementEnrollement cpe in currentPayementEnrollements)
                        {
                            if (cpe.DateDeDebut >= eleveEnrollement.DateDeDebut)
                            {
                                paid = paid + cpe.Paid;
                                _context.PayementEnrollements.Remove(cpe);
                            }
                            else
                            {
                                currentPayementEnrollement = cpe;
                            }
                        }
                        PayementEnrollementViewModel payementEnrollement = new PayementEnrollementViewModel()
                        {
                            Section = "Scolarité",
                            Paid = 0,
                            EleveEnrollementId = eleveEnrollement.Id,
                            DateDeDebut = eleveEnrollement.DateDeDebut,
                            DateDeFin = currentEleveEnrollement.DateDeFin.Value,
                        };
                        currentEleveEnrollement.DateDeFin = eleveEnrollement.DateDeDebut;
                        _context.Entry(currentEleveEnrollement).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        currentPayementEnrollement.DateDeFin = eleveEnrollement.DateDeDebut;
                        _context.Entry(currentPayementEnrollement).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        var pe = _mapper.Map<PayementEnrollement>(payementEnrollement);
                        await _context.PayementEnrollements.AddAsync(pe);
                    }
                    else
                    {
                        currentEleveEnrollement.DateDeFin = eleveEnrollement.DateDeDebut;
                        _context.Entry(currentEleveEnrollement).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task<PayementEnrollement> GetCurrentEleveEnrollement(DateTime Date, int EleveId)
        {
            PayementEnrollement pe= await _context.PayementEnrollements.Include(pe=>pe.EleveEnrollement).Where(pe => pe.EleveEnrollement.EleveId == EleveId && pe.Section== "Groupe"  && pe.DateDeDebut <= Date && pe.DateDeFin > Date).FirstOrDefaultAsync();
            return pe;
        }

        public void Update( EleveEnrollement eleveEnrollement ) 
        { 
            _context.Entry( eleveEnrollement ).State = EntityState.Modified; 
        }
        public async Task DeleteAsync(int eleveid, int Enrollementid, DateTime Datededebut)
        {
            EleveEnrollement eleveEnrollement = _context.EleveEnrollements.Where(p => p.EleveId == eleveid && p.EnrollementId == Enrollementid).First();
            _context.EleveEnrollements.Remove(eleveEnrollement);
        }
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
