using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EscutaSom.Models
{
    public class Banda
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public DateTime DataCriacao{ get; set; }
        public int QuantIntegrantes { get; set; }
        public Gravadora gravadora{ get; set; }

        [Column("gravadora_Id")]
        public int Id_Gravadora { get; set; }

        

        public ICollection<Musico> Musicos{ get; set; }
        public ICollection<Album> Albuns { get; set; } 

    }
}