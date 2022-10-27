using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PredmetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PredmetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public class PredmetAddVM
        {
            public string nazivPremeta { get;  set; }
            public string sifraPredmeta { get;  set; }
            public int ectsBodovi { get; set; }
          
        }


        [HttpPost]
        public Predmet Add([FromBody] PredmetAddVM x)
        {
            var noviZapis = new Predmet
            {
              Naziv=x.nazivPremeta,
              Sifra=x.sifraPredmeta,
              ECTS=x.ectsBodovi
                    
            };

            _dbContext.Add(noviZapis);//priprema sql
            _dbContext.SaveChanges();//execute sql
            return noviZapis;
        }

        

        [HttpGet]
        public List<PredmetGetAllVM> GetAll(string? f, float min_prosjecna_ocjena)
        {
            var pripremaUpita = _dbContext.Predmet
                .Where(s => (f==null || s.Naziv.ToLower().StartsWith(f.ToLower()))
                && (_dbContext.Ocjena.Where(o=>o.PredmetID==s.Id).Average(z => z.BrojcanaOcjena)<=min_prosjecna_ocjena)
                )
                .OrderBy(s => s.Naziv)
                .ThenBy(s => s.Sifra).Take(100)
                .Select(s => new PredmetGetAllVM
                {
                    Naziv=s.Naziv,
                    ECTS=s.ECTS.ToString(),
                    ProsjecnaOcjena=0
                });

            return pripremaUpita.ToList();// execute select top 100 from predmet
        }
    }
}
