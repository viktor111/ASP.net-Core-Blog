using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(555)]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string ApplicationUserId { get; set; }

        public int? ArticleId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public Article Article { get; set; }
    }
}
