using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Tag
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public int TagId { get; set; } 
        public string TagName { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }

        //public ICollection<Blog> Blogs { get; set; }
    }
}
