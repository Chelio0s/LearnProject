using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LearnProject.Data.BlogData
{
    public class ArticleHeader
    {
        public int ArticleHeaderId { get; set; }
        public byte[] PreviewImage { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public ApplicationUser Author { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public ArticleBody Body { get; set; }
        public int BodyId { get; set; }
    }
}
