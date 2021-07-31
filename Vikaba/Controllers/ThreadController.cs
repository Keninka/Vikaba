using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Vikaba.Data;
using Vikaba.Data.Database;
using Vikaba.Models;

namespace Vikaba.Controllers
{
    public class ThreadController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public ThreadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // /au/
        [HttpGet("/{board}/")]
        public ActionResult BoardThreads(string board)
        {
            List<BoardThread> threads = Threads.ThreadList;

            List<BoardThread> filteredList = threads.FindAll(thread => thread.Board.Link == board);

            return View(filteredList);
        }


        // /cg/res/2066095.html
        // /{board}/res/{threadId}.html
        [HttpGet("{board}/res/{threadId:int}.html")]
        public ActionResult ThreadComments(string board, int threadId)
        {
            foreach (BoardThread? thread in Threads.ThreadList)
            {
                if (thread.Board.Link == board && threadId == thread.Id)
                {
                    return View(thread);
                }
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

            var entity = new BoardThread()
            {
                Id = new Random().Next(),

                Headline = thread.Headline,

                Content = thread.Content,

                Board = Boards.BoardMap[board]
            };

            var imageRelativePath = Path.Join("uploads", thread.Image.FileName);
            var uploadPath = Path.Join(_environment.WebRootPath, imageRelativePath);
            using var uploadedFile = System.IO.File.Create(uploadPath);
            thread.Image.CopyTo(uploadedFile);
            entity.Image = imageRelativePath;


            Threads.ThreadList.Add(entity);

            return RedirectToAction("ThreadComments", new {board = board, threadId = entity.Id});
        }
    }
}