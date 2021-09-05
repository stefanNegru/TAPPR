using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAP.Core.Entities;

namespace TAP.Web.Areas.BlogArea.Models
{
    public class AllBlogsViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Guid UserId { get; set; }
    }
}
