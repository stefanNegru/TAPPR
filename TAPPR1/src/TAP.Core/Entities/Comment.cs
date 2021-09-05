using System;
using System.Collections.Generic;
using System.Text;

namespace TAP.Core.Entities
{
    public class Comment:IEntityBase
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Guid BlogId { get; set; }
    }
}
