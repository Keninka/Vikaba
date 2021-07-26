using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vikaba.Data;
using Vikaba.Data.Database;

namespace Vikaba.Controllers
{
    public class ThreadController : Controller
    {
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
    }
}