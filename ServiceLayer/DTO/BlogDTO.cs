using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public StringBuilder content { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Author { get; set; }
        public int ReviewsCount { get; set; }
        public double? ReviewsAverageStars { get; set; }
        public string[] TagStrings { get; set; }
    }
}
