using System;

namespace DotVVM.SampleWeb.Dto
{
    public class ForumThreadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string FirstPostMessage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostsCount { get; internal set; }
        public string LastPostUserName { get; internal set; }
        public DateTime LastPostDate { get; internal set; }
    }
}