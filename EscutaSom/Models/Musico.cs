using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscutaSom.Models
{
    public class Musico
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }

        public Banda banda { get; set; }
        public ICollection<Instrumento> Instrumentos { get; set; } 

    }
}