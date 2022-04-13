using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;////dodato za toListAsync
using Microsoft.Extensions.Logging;
using Template.Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IspitController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public IspitController(IspitDbContext context)
        {
            Context = context;
        }

        [Route("PreuzmiProdavnice")]
        [HttpGet]
        public async Task<List<Prodavnica>> PreuzmiProdavnice()
        {
          //var vraceneProdavnice=await Context.Prodavnica.FindAsync(idProdavnice);
          return await Context.Prodavnica.ToListAsync();
        }


        [Route("PreuzmiBrendove/{idProdavnice}")]
        [HttpGet]
        public async Task<List<Brend>> PreuzmiBredove(int idProdavnice)
        {
          var vraceneProdavnice=await Context.Prodavnica.Where(p=>p.ID==idProdavnice).FirstAsync();
          var vraceniBrendovi=await Context.Brend.Where(p=>p.Prodavnica.Contains(vraceneProdavnice)).ToListAsync();
          return vraceniBrendovi;
        }

        [Route("PreuzmiTip/{idProdavnice}")]
        [HttpGet]
        public async Task<List<Tip>> PreuzmiTip(int idProdavnice)
        {
          var vraceneProdavnice=await Context.Prodavnica.Where(p=>p.ID==idProdavnice).FirstAsync();
          var vraceniTipovi=await Context.Tip.Where(p=>p.Prodavnica.Contains(vraceneProdavnice)).ToListAsync();
          return vraceniTipovi;
        }
   

        [Route("PrijemPodataka/{nizacena}/{visacena}/{idBrenda}/{idTipa}/{idProd}")]
        [HttpGet]
        public async Task<List<Proizvod>> PrijemPodataka(float nizacena, float visacena, int idBrenda, int idTipa,int idProd)
        {
          var nadjeniPodaci = await Context.Proizvod.Where(p=>p.Prodavnica.ID==idProd && p.Brend.ID==idBrenda && p.Tip.ID==idTipa  && p.cena>=nizacena  && p.cena<=visacena).ToListAsync(); ///moras tamo gde je await da imas i async
          if (nadjeniPodaci!=null){
                       
              return nadjeniPodaci;
              }
          else 
          {
            return nadjeniPodaci=null;
          }
        }
        [Route("KupovinaKonfiguracije/{nizIzabranihProizvoda}/{idProdavnice}")]
        [HttpPut]
        public async Task<ActionResult> KupovinaKonfiguracije(string nizIzabranihProizvoda, int idProdavnice)
        {///radi preko contains posto je to jedini nacin da pretrazujes da li je neki manji string u vecem stringu!
        //niz izabranih proizvoda sastoji se od id-eva elemenata i slova a koje ih razdvaja.

          while ( nizIzabranihProizvoda.IndexOf("a")!=-1){
            var NadjeniProizvod=await Context.Proizvod.Where(p=>nizIzabranihProizvoda.Contains((p.ID).ToString()) && p.Prodavnica.ID==idProdavnice).ToListAsync();
          
            foreach(Proizvod Element in NadjeniProizvod)
               { 
                Element.kolicina--;
                if (Element.kolicina<=0)
                    Context.Proizvod.Remove(Element);
                else{
                    Context.Proizvod.Update(Element);
                }
               }
              int loc=nizIzabranihProizvoda.IndexOf("a");
              nizIzabranihProizvoda=nizIzabranihProizvoda.Remove(0, loc+1); //izbacuje deo stringa izmedju dva slova a
            }
          await Context.SaveChangesAsync();
          return Ok("uspesno pretrazeni proizvodi");
        }
    }
}


//

/*Jedino sto smo dodali u ovom Template-u je ,
  "ConnectionStrings": {
    "IspitCS": "Server=(localdb)\\MSSQLLocalDB;Database=TestBazaPodataka"   
  },
  "AllowedHosts": "*" i index.html */