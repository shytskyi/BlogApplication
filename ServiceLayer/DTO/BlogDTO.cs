using System.Text;

namespace ServiceLayer.DTO
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
       // public DateTime PublishedOn { get; set; }
        //public string Author { get; set; }
        public string[] TagStrings { get; set; }
    }
}
