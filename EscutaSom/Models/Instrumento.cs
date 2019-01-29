using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscutaSom.Models
{
    public class Instrumento
    {

        public int Id  { get; set; }
        public string Nome { get; set; }
        public string TipoInstrumento { get; set; }

        public Musico musico { get; set; }
    
    }
}