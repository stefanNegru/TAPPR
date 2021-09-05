using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAP.Web.Areas.CommentsArea.Models
{
    public class CommentCreateViewModel
    {
        public string CommentContent { get; set; }
        public Guid blogID { get; set; }

    }
}
