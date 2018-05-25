using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Model
{
    public class DC
    {
        [Key]
        public int? idAvaliacao { get; set; }
        public decimal triceps { get; set; }
        public decimal escapular { get; set; }
        public decimal suprailiaca { get; set; }
        public decimal abdominal { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }


        protected DC()
        {

        }
    }
}
