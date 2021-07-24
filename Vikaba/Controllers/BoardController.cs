using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vikaba.Data;

namespace Vikaba.Controllers
{
    public class BoardController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var categoryRandom = new BoardCategory
            {
                Title = "Тематика",
                Id = 1,
                Boards = new List<Board>
                {
                    new Board
                    {
                        Link = "a",
                        Title = "Аниме",
                        Id = 1
                    },

                    new Board
                    {
                        Link = "b",
                        Title = "Бред",
                        Id = 2
                    },

                    new Board
                    {
                        Link = "c",
                        Title = "Скрепоносцы",
                        Id = 3
                    }
                }
            };

            var categoryGames = new BoardCategory
            {
                Title = "Игры",
                Id = 2,
                Boards = new List<Board>
                {
                    new Board
                    {
                        Link = "vg",
                        Title = "Видеоигры",
                        Id = 4
                    }
                }
            };

            var categories = new BoardCategory[]
            {
                categoryGames, categoryRandom
            };

            return View(categories);
        }
    }
}