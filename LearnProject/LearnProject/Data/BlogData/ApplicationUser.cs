using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LearnProject.Data.BlogData
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }
        [Required]
        public override string UserName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public virtual ICollection<ArticleHeader> Articles { get; set; }
    }
}
