using System;
using System.Linq;
using DotVVM.Framework.Controls;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.DAL;
using DotVVM.SampleWeb.DAL.Entities;

namespace DotVVM.SampleWeb.Web.Services
{
    public class ForumService
    {
        private AppDbContext dc;

        public ForumService(AppDbContext dc)
        {
            this.dc = dc;
        }

        public void LoadForumThreads(GridViewDataSet<ForumThreadDTO> dataSet)
        {
            var query = dc.ForumThreads
                .OrderByDescending(t => t.CreatedDate)
                .Select(t => new ForumThreadDTO()
                {
                    Id = t.Id,
                    Title = t.Title,

                    FirstPostMessage = t.ForumPosts
                        .OrderBy(p => p.Id)
                        .FirstOrDefault().Message,

                    CreatedDate = t.CreatedDate,
                    PostsCount = t.ForumPosts.Count,

                    LastPostUserName = t.ForumPosts
                        .OrderByDescending(p => p.Id)
                        .Select(p => p.AppUser.UserName)
                        .FirstOrDefault(),

                    LastPostDate = t.ForumPosts
                        .OrderByDescending(p => p.Id)
                        .FirstOrDefault()
                        .CreatedDate,
                });

            dataSet.LoadFromQueryable(query);
        }

        public void LoadForumPosts(int forumThreadId, GridViewDataSet<ForumPostDTO> dataSet)
        {
            var query = dc.ForumPosts
                .Where(p => p.ForumThreadId == forumThreadId)
                .OrderBy(p => p.CreatedDate)
                .Select(p => new ForumPostDTO()
                {
                    Id = p.Id,
                    CreatedDate = p.CreatedDate,
                    Message = p.Message,
                    AppUserId = p.AppUserId,
                    AppUserName = p.AppUser.UserName,
                    AppUserNumberOfPosts = p.AppUser.ForumPosts.Count
                });

            dataSet.LoadFromQueryable(query);
        }

        public void CreateThread(ForumThreadCreateDTO data, int userId)
        {
            dc.ForumThreads.Add(new ForumThread()
            {
                Title = data.Title,
                CreatedDate = DateTime.Now,
                ForumPosts =
                {
                    new ForumPost()
                    {
                        AppUserId = userId,
                        Message = data.Message,
                        CreatedDate = DateTime.Now
                    }
                }
            });
            dc.SaveChanges();
        }

        public void CreatePost(ForumPostCreateDTO data, int forumThreadId, int userId)
        {
            dc.ForumPosts.Add(new ForumPost()
            {
                Message = data.Message,
                CreatedDate = DateTime.Now,
                ForumThreadId = forumThreadId,
                AppUserId = userId
            });
            dc.SaveChanges();
        }
    }
}