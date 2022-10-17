using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManager.Models
{
    public class New
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        [Required]
        [MaxLength(256)]
        public string Slug { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [MaxLength(256)]
        public string? Summary { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Content { get; set; }
        [Required]
        [MaxLength(512)]
        public string Avatar { get; set; }
    }
}