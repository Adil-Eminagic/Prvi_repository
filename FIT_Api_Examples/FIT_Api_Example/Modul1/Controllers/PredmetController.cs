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
            public string nazivPremeta { get; internal set; }
            public string sifraPredmeta { get; internal set; }
            public int ectsBodovi { get; internal set; }
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
        public List<PredmetGetAllVM> GetAll()
        {
            var pripremaUpita = _dbContext.Predmet
                .Where(s => s.Naziv.StartsWith("A"))
                .OrderBy(s => s.Naziv)
                .ThenBy(s => s.Sifra).Take(100)
                .Select(s => new PredmetGetAllVM
                {
                    Naziv=s.Naziv,
                    ECTS=s.ECTS,
                    ProsjecnaOcjena=0
                });

            return pripremaUpita.ToList();// execute select top 100 from predmet
        }
    }
}
