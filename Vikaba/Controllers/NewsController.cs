using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Vikaba.Data;
using Vikaba.Models;

namespace Vikaba.Controllers
{
    public class NewsController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;

        public NewsController(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        [HttpGet("/news")]
        public ActionResult News()
        {
            var news = _db.News
                .OrderByDescending(n => n.PublishedAt)
                .ToList();

            return View(news);
        }

        [HttpGet("/news/tag/{tagId}")]
        public ActionResult TagsToNews(string tagId)
        {
            var news = _db.News
                .Where(n => n.Tags
                    .Any(tag => tag.Title == tagId))
                .OrderByDescending(n => n.PublishedAt)
                .ToList();

            return View("News", news);
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
            };
            
            foreach (var tag in news.Tags.Split())
            {
                var dbTag = _db.Tags
                    .FirstOrDefault(t => t.Title == tag);

                if (dbTag == null)
                {
                    dbTag = new Tag
                    {
                        Title = tag
                    };
                }
                
                entity.Tags.Add(dbTag);
            }
            
            if (news.Image != null)
            {
                var imageRelativePath = Path.Join("uploads", news.Image.FileName);
                var uploadPath = Path.Join(_environment.WebRootPath, imageRelativePath);
                using var uploadedFile = System.IO.File.Create(uploadPath);
                news.Image.CopyTo(uploadedFile);
                entity.Image = imageRelativePath;
            }

            _db.News.Add(entity);
            _db.SaveChanges();

            return RedirectToAction("News");
        }
    }
}