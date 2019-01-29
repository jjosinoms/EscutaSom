using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscutaSom.Models
{
    public class Gravadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CNPJ { get; set; }

        public ICollection<Banda> Bandas { get; set; } 




    }
}