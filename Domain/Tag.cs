using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Tag
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string TagId { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
