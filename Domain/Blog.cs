using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public StringBuilder content { get; set; }
        public DateTime PublishedOn { get; set; }
        public string ImageUrl { get; set; }
        public Author Author { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
