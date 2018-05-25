using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Model
{
    public class Perimetros
    {
        [Key]
        public int? idAvaliacao { get; set; }
        public decimal bracoDireito { get; set; }
        public decimal cintura { get; set; }
        public decimal abdominal { get; set; }
        public decimal quadril { get; set; }
        public decimal coxaDireita { get; set; }
        public decimal panturrilhaDireita { get; set; }
        public decimal torax { get; set; }
        public decimal bracoEsquerdo { get; set; }
        public decimal pulso { get; set; }
        public decimal coxaEsquerda { get; set; }
        public decimal panturrilhaEsquerda { get; set; }

        public virtual Avaliacao Avaliacao { get; set; }

        protected Perimetros()
        {

        }
    }
}
