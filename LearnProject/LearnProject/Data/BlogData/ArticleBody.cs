using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnProject.Data.BlogData
{
    public class ArticleBody
    {
        public int ArticleBodyId { get; set; }
        [Required]
        public string Text { get; set; }
        public ICollection<ImageBlog> Images { get; set; }
    }
}
