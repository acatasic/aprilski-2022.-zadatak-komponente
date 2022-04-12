using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Template.Models{
    [Table("Tip")]
    public class Tip
    {
        [Key]
        public int ID{get;set;}

        public string Naziv{get;set;}

        public List<Prodavnica> Prodavnica{get;set;}

        public List<Proizvod> Proizvod{get;set;}
     
        public Tip()
        {
           this.Prodavnica=new List<Prodavnica>();
           this.Proizvod=new List<Proizvod>();
        }
    }
}
