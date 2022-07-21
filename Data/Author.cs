using System;
using System.Collections.Generic;

namespace NoticiasApi.Data
{
    public partial class Author
    {
        public Author()
        {
            NewsBlogs = new HashSet<NewsBlog>();
        }

        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<NewsBlog> NewsBlogs { get; set; }
    }
}
