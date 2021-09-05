using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TAP.Web.Areas.exemplu.Models
{
    public class CreateBlogViewModel
    {
        [Required(ErrorMessage = "Please Enter A Title")]
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string AuthorName { get; set; }
        //public string UserId { get; set; }
    }
}
