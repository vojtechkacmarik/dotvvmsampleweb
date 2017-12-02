using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotVVM.SampleWeb.Model
{
    public class ForumThread
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; } = new List<ForumPost>();
    }
}