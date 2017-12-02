using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DotVVM.SampleWeb.Model
{
    public class AppUser : IdentityUser<int>
    {
        public virtual ICollection<ForumPost> ForumPosts { get; } = new List<ForumPost>();
    }
}