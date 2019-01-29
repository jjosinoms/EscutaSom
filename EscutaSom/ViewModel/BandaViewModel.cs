using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EscutaSom.Models;

namespace EscutaSom.ViewModel
{
    public class BandaViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantIntegrantes { get; set; }

        public List<Gravadora> Gravadoras { get; set; }


    }
}