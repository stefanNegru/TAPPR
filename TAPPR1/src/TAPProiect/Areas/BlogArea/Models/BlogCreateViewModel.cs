using System.ComponentModel.DataAnnotations;

namespace TAP.Web.Areas.BlogArea.Models
{
    public class BlogCreateViewModel
    {
        [Required(ErrorMessage = "Please Enter A Title")]
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string AuthorName { get; set; }
    }
}