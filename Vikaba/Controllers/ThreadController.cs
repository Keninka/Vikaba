using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vikaba.Data;
using Vikaba.Models;

namespace Vikaba.Controllers
{
    public class ThreadController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;

        public ThreadController(IWebHostEnvironment environment,
            ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        [HttpGet("/{board}/")]
        public ActionResult BoardThreads(string board)
        {
            ViewBag.Board = board;

            var threads = _db.Threads
                .Include(thread => thread.Board)
                .Where(thread => thread.Board.Link == board)
                .ToList();

            return View(threads);
        }


        // /cg/res/2066095.html
        // /{board}/res/{threadId}.html
        [HttpGet("{board}/res/{threadId:int}.html")]
        public ActionResult ThreadComments(string board, int threadId)
        {
            var thread = _db.Threads
                .Where(thread => thread.Board.Link == board)
                .Where(thread => threadId == thread.Id)
                .FirstOrDefault();

            if (thread != null)
            {
                return View(thread);
            }

            return Content("Тред не найден");
        }

        [HttpGet("{board}/thread/new")]
        public ActionResult PostThread(string board)
        {
            ViewBag.Board = board;
            return View("CreateThread");
        }

        [HttpPost("{board}/create")]
        public ActionResult CreateThread(string board, CreateThread thread)
        {
            ViewBag.Board = board;

            if (!ModelState.IsValid)
            {
                return View(thread);
            }

            var imageRelativePath = Path.Join("uploads", thread.Image.FileName);
            var uploadPath = Path.Join(_environment.WebRootPath, imageRelativePath);
            using var uploadedFile = System.IO.File.Create(uploadPath);
            thread.Image.CopyTo(uploadedFile);

            var entity = new BoardThread()
            {
                Headline = thread.Headline,
                Content = thread.Content,
                Board = _db.Boards.First(b => b.Link == board),
                Image = imageRelativePath
            };

            _db.Threads.Add(entity);
            _db.SaveChanges();

            return RedirectToAction("ThreadComments", new {board = board, threadId = entity.Id});
        }
    }
}