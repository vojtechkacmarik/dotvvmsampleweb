using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DotVVM.SampleWeb.DAL.Entities
{
    public class ForumThread : IEntity<int>
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; } = new List<ForumPost>();
    }
}