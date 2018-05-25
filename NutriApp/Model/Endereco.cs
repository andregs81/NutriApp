using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Model
{
    public class Endereco
    {
        [Key]
        public int? idPaciente { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }

        public virtual Paciente Paciente { get; set; }

        protected Endereco()
        {

        }
    }
}
