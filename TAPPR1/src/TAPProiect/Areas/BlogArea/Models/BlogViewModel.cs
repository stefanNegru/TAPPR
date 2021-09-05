using System;
using System.Collections.Generic;
using TAP.Core.Entities;

namespace TAP.Web.Areas.BlogArea.Models
{
    public class BlogViewModel
    {
        public Blog blog2 { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}