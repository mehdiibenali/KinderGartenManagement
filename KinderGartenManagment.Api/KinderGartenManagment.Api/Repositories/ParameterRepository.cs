using System.Collections.Generic; 
using KinderGartenManagment.Api.Models; 
using Microsoft.EntityFrameworkCore; 
using KinderGartenManagment.Api.Context; 
using KinderGartenManagment.Api.Interfaces.Repositories; 
using System.Threading.Tasks; 
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using KinderGartenManagment.Api.ViewModels;

namespace KinderGartenManagment.Api.Repositories 
{ 
    public class ParameterRepository : IParameterRepository 
    { 
        private ApplicationDbContext _context; 
        public ParameterRepository (ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<IEnumerable< Parameter >> GetAll() 
        { 
            return await _context. Parameters .ToListAsync(); 
        } 
 
        public async Task< IEnumerable<Parameter> > GetByCodeAsync(string code) 
        { 
            return await _context. Parameters .Where(p=>p.Code==code).ToListAsync(); 
        } 
        //public async Task<IEnumerable<string>> GetSections(int eleveid)
        //{
        //    var currentscholaryear = _context.Parameters.Where(p => p.Code == "CurrentScholarYear").FirstOrDefaultAsync().Result.Value.Split('-');
        //    var sections = await _context.Parameters.Where(p => p.Code == "Section").Select(c => c.Value).ToListAsync();
        //    var frais = _context.Eleves.FindAsync(eleveid).Result.Payements.Where(p => p.PayementEnrollements.Any(pe => pe.Section == "Frais d'inscription" && pe.PayementDates.Any(pd=>pd.DateDeDebut.Year.ToString()== currentscholaryear[0] && pd.DateDeFin.Year.ToString()==currentscholaryear[1]))).FirstOrDefault();
        //    if (frais != null)
        //    {
        //        sections
        //    }
        //}
 
        public async Task InsertAsync( Parameter parameter ) 
        { 
            await _context. Parameters .AddAsync( parameter ); 
        } 
        public async Task<IEnumerable<Object>> GetDates (DateTime Start, DateTime End)
        {
            var start = Start;
            var end = new DateTime(End.Year, End.Month, DateTime.DaysInMonth(End.Year, End.Month));
            var diff=(Enumerable.Range(0, Int32.MaxValue)
                                 .Select(e => start.AddMonths(e))
                                 .TakeWhile(e => e < end)
                                 .Select(e => new { month=e.ToString("MMMM"), start=DateTime.Parse(e.ToString("MMMM")+" 1 "
                                 +e.ToString("yyyy")),end=DateTime.Parse(e.ToString("MMMM")+" "+DateTime.DaysInMonth(e.Year,e.Month)
                                 .ToString()+" "+e.ToString("yyyy"))})).ToList();
            diff[0] = new
            {
                month = start.ToString("MMMM"),
                start = DateTime.Parse(start.ToString("MMMM") + " " + Start.ToString("dd") + " "
                      + start.ToString("yyyy")),
                end = DateTime.Parse(start.ToString("MMMM") + " " + DateTime.DaysInMonth(start.Year, start.Month)
                      .ToString() + " " + start.ToString("yyyy"))
            };
            diff[diff.Count()-1]= new
            {
                month = end.ToString("MMMM"),
                start = DateTime.Parse(end.ToString("MMMM") + " 1 "
                      + end.ToString("yyyy")),
                end = DateTime.Parse(end.ToString("MMMM") + " "+End.ToString("dd")
                       + " " + end.ToString("yyyy"))
            };
            return diff;
        }
        [System.Obsolete]
        public async Task<List<DatesViewModel>> GetMonthDates(int month, int year)
        {
            //SqlParameter monthparameter = new SqlParameter();
            //monthparameter.ParameterName = "@Month";
            //monthparameter.SqlDbType = SqlDbType.Int;
            //monthparameter.Value = month;

            SqlParameter monthparameter = new SqlParameter("@Month", month);
            //monthparameter.SqlDbType = SqlDbType.Int;

            //SqlParameter yearparameter = new SqlParameter();
            //yearparameter.ParameterName = "@Year";
            //yearparameter.SqlDbType = SqlDbType.Int;
            //yearparameter.Value = year;

            SqlParameter yearparameter = new SqlParameter("@Year", year);
            //yearparameter.SqlDbType = SqlDbType.Int;
            string sqlQuery = "EXEC dbo.get_dates " + "@Month"+","+"@Year";
            var result = await _context.Query<DatesViewModel>().FromSql(sqlQuery, monthparameter, yearparameter).ToListAsync();
            return result;
        }
        public async Task DeleteAsync(int parameterId ) 
        { 
            Parameter parameter = await _context. Parameters .FindAsync( parameterId ); 
            _context. Parameters .Remove( parameter ); 
        } 
 
        public void Update( Parameter parameter ) 
        { 
            _context.Entry( parameter ).State = EntityState.Modified; 
        } 
 
        public async Task SaveAsync() 
        { 
            await _context.SaveChangesAsync(); 
        } 
 
    } 
} 
