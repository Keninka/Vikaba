using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vikaba.Data;
using Vikaba.Data.Database;

namespace Vikaba.Controllers
{
    public class NewsController : Controller
    {
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
    }
}