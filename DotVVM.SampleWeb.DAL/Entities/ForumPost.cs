using System;
using Riganti.Utils.Infrastructure.Core;

namespace DotVVM.SampleWeb.DAL.Entities
{
    public class ForumPost : IEntity<int>
    {
        public int Id { get; set; }

        public int ForumThreadId { get; set; }

        public virtual ForumThread ForumThread { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}