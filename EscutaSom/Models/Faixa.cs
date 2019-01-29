using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EscutaSom.Models
{
    public class Faixa
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public double DuracaoMusica { get; set; }
        public DateTime CriacaoMusica { get; set; }
        public byte Media { get; set; }

        public Album album{ get; set; }

        [Column("album_Id")]
        public int Id_Album { get; set; }

    }
}