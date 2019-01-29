using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EscutaSom.Models
{
    public class Album
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public Banda banda { get; set; }

        [Column("banda_Id")]
        public int Id_Banda { get; set; }

        public ICollection<Faixa> Faixas { get; set; } 

    }
}