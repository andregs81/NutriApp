using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Model
{
    public class Avaliacao
    {
        [Key]
        public int idAvaliacao { get; set; }
        public int idPaciente { get; set; }
        public DateTime dataAvaliacao { get; set; }
        public decimal peso { get; set; }
        public decimal estatura { get; set; }
        public string pressaoArterial { get; set; }
        public decimal bioimpedancia { get; set; }
        public decimal batimentoCardiaco { get; set; }
        public decimal iimc { get; set; }
        public decimal percRealizadoDieta { get; set; }
        public decimal percRealizadoTreino { get; set; }
        public virtual DC DC { get; set; }
        public virtual Perimetros Perimetros { get; set; }

        //EF
        protected Avaliacao()
        {

        }

    }

}
