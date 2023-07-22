using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int AuthorId { get; set; }
        public int BlogId { get; set; }
        public string Name { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }
        public Blog Blog { get; set; }
        public Author Author { get; set; }
    }
}
