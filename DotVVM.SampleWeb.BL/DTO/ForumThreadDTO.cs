using System;

namespace DotVVM.SampleWeb.BL.DTO
{
    public class ForumThreadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string FirstPostMessage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostsCount { get; set; }
        public string LastPostUserName { get; set; }
        public DateTime LastPostDate { get; set; }
    }
}