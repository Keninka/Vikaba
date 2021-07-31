using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Vikaba.Data;
using Vikaba.Data.Database;
using Vikaba.Models;

namespace Vikaba.Controllers
{
    public class NewsController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public NewsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("/news")]
        public ActionResult News()
        {
            var news = new List<News>(NewsDB.NewsList);

            news.Sort((left, right) =>
                left.PublishedAt.CompareTo(right.PublishedAt));

            return View(news);
        }

        [HttpGet("/news/tag/{tagId}")]
        public ActionResult TagsToNews(string tagId)
        {
            var tagNews = new List<News>();

            foreach (News news in NewsDB.NewsList)
            {
                foreach (Tag tag in news.Tags)
                {
                    if (tag.Title == tagId)
                    {
                        tagNews.Add(news);
                        break;
                    }
                }
            }

            tagNews.Sort((left, right) => left.PublishedAt.CompareTo(right.PublishedAt));

            return View("News", tagNews);
        }

        [HttpGet("/news/new")]
        public ActionResult PostNews()
        {
            return View();
        }

        [HttpPost("/news/new")]
        public ActionResult SaveNews(CreateNews news)
        {
            if (!ModelState.IsValid)
            {
                return View("PostNews", news);
            }

            var entity = new News
            {
                Headline = news.Headline,
                SubHeadline = news.SubHeadline,
                Content = news.Content,
                PublishedAt = news.PublishedAt,
                Tags = news.Tags.Split().Select(word => new Tag
                {
                    Title = word
                }).ToList()
            };

            if (news.Image != null)
            {
                var imageRelativePath = Path.Join("uploads", news.Image.FileName);
                var uploadPath = Path.Join(_environment.WebRootPath, imageRelativePath);
                using var uploadedFile = System.IO.File.Create(uploadPath);
                news.Image.CopyTo(uploadedFile);
                entity.Image = imageRelativePath;
            }

            NewsDB.NewsList.Add(entity);

            return RedirectToAction("News");
        }
    }
}