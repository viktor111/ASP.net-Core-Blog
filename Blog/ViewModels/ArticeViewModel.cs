using Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class ArticeViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(60)]
        public string Author { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [Required]
        [MaxLength(555)]
        public string CommentContent { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        public string ApplicationUserId { get; set; }

        public int? ArticleId { get; set; }
    }
}
