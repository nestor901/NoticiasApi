using System;
using System.Collections.Generic;

namespace NoticiasApi.Data
{
    public partial class NewsBlog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author? Author { get; set; }
    }
}
