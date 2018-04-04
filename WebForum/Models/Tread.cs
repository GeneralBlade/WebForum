using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models
{
    public class Tread
    {
        public int ID { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Author { get; set; }

        [StringLength(1000, MinimumLength = 1)]
        [Required]
        public string Text { get; set; }
    }
}
