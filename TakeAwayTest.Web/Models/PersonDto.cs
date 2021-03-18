using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeAwayTest.Web.Models
{
    public class PersonDto
    {
        [Required(ErrorMessage ="Person Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Person number is required")]

        [Range(double.MinValue,double.MaxValue)]
        public Decimal Number { get; set; }
    }
}
