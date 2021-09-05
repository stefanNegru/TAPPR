using System;
using System.Collections.Generic;
using TAP.Core.Entities;

namespace TAP.Web.Areas.exemplu.Models
{
    public class UserBlogsViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
