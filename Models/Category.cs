using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManager.Models
{
    public class Category
    {
        public Category()
        {
            News = new List<New>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public int Name { get; set; }
        public List<New> News { get; set; }
    }
}