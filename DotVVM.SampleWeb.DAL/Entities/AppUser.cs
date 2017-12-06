using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DotVVM.SampleWeb.DAL.Entities
{
    public partial class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            ForumPosts = new HashSet<ForumPost>();
        }

        public virtual ICollection<ForumPost> ForumPosts { get; }
    }
}