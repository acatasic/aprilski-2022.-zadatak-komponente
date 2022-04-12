﻿using System;
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
   

        [Route("PrijemPodataka/{duzina}/{sirina}/{idBrenda}/{idTipa}/{idProd}")]
        [HttpGet]
        public async Task<List<Proizvod>> PrijemPodataka(float duzina, float sirina, int idBrenda, int idTipa,int idProd)
        {
          var nadjeniPodaci = await Context.Proizvod.Where(p=>p.Prodavnica.ID==idProd && p.Brend.ID==idBrenda && p.Tip.ID==idTipa  && p.cena>=duzina  && p.cena<=sirina).ToListAsync(); ///moras tamo gde je await da imas i async
          if (nadjeniPodaci!=null){
                       
              return nadjeniPodaci;
              }
          else 
          {
            return nadjeniPodaci=null;
          }
        }
    }
}
//

/*Jedino sto smo dodali u ovom obrascu je ,
  "ConnectionStrings": {
    "IspitCS": "Server=(localdb)\\MSSQLLocalDB;Database=TestBazaPodataka"   
  },
  "AllowedHosts": "*" i index.html */