using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace NutriApp.Model
{
    public class Paciente
    {
        [Key]
        public int idPaciente { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public DateTime datanascimento { get; set; }
        public string sexo { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string email { get; set; }



        public virtual Endereco Endereco { get; set; }


        protected Paciente()
        {

        }

    }
}
