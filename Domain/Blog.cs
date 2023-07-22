namespace Domain
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
        public DateTime PublishedOn { get; set; } 
        public Author Author { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
