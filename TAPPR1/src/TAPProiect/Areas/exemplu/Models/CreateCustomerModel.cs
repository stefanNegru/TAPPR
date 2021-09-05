using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAP.Web.Models
{
    public class CreateCustomerModel
    {
        [Required(ErrorMessage = "First name is required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "IdNo is required")]
        public string IdNc { get; set; }
    }
}
