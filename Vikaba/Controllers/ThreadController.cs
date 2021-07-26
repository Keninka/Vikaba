﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vikaba.Data;

namespace Vikaba.Controllers
{
    public class ThreadController : Controller
    {
        // /au/
        [HttpGet("/{board}/")]
        public ActionResult BoardThreads(string board)
        {
            if (board == "vg")
            {
                var threads = new BoardThread[]
                {
                    new BoardThread
                    {
                        Subject = "vg thread #1",
                        
                        Board = new Board()
                        {
                            Link = "vg"  
                        }
                    },
                    new BoardThread
                    {
                        Subject = "vg thread #2",
                        
                        Board = new Board()
                        {
                            Link = "vg"  
                        }
                    },
                };
                return View(threads);
            }

            if (board == "b")
            {
                var threads = new BoardThread[]
                {
                    new BoardThread()
                    {
                        CreatedAt = new DateTime(),
                        Id = 1,
                        Subject = "Кенинка",
                        UserText = "Lorem ipsum dolor sit amet",
                        Comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                UserText =
                                    "Сап двач. На днях заказал Тигуан за 2.875кк, 2.0 TSI 180, Эксклюзив на коже и 19-х колёсах (На Р-лайн не хватило денях). Сумма для меня пиздец большая. Ждать месяца три. Несколько раз на дню решаю отменить, потом решаю оставить. Анон, скажи, нормальная тачка? Пацаны на раёне не засмеют? Или тупая покупка, так как 2022 выйдет рестайл (или нет) и вообще Фольцваген говно ебаное, в 2021 надо гонять на электромобиле. Постоянно думаю о том, какой говяный там салон, сейчас езжу на Киа Сид и у тачки в более чем два раза дешевле салон ничем не хуже, а может даже лучше. Отменить? Или нет?\n(б/у для куколдов)",
                                Id = 1,
                                CreatedAt = new DateTime()
                            }
                        },

                        Board = new Board()
                        {
                            Link = "b"
                        }
                    },

                    new BoardThread()
                    {
                        CreatedAt = new DateTime(),
                        Id = 2,
                        Subject = "Новые похождения Кенинки",
                        UserText = "Самая соленая река в России",
                        Comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                UserText =
                                    "Не слушай блядь этих умников, делай то что хочешь. Хочется тебе ездить на новой тачке - купи и езди, один раз живём. Завтра ебнет тебя коронавируса осложнения, толку тебе с твоих рублей в носке, если желаемых удовольствий от своего труда и жизни не получил. Можно купить мороженое и жрать его причмокивая от удовольствия, а кому-то важнее рубалек в копилку и дрочить на свои бохатства.\nУ меня одногруппник Саша был, он до болезни рачительный был, ходил в одной рубашке годами, с одним пожухлым пэт пакетом целый учебный год, ел экономно, жил экономно, о машине не мечтал - это слишком дорого, под подушку откладывал. Нахуй так жить",
                                Id = 2,
                                CreatedAt = new DateTime()
                            },

                            new Comment()
                            {
                                UserText =
                                    "А, понятно. Какая-то хуета, существующая для электовыставок и в виде рендера от школоты. Держи в курсе, когда он появится, как реальная машина. Пиздец. Ты как плешивая мразь со своим су57, лол.",
                                Id = 3,
                                CreatedAt = new DateTime()
                            }
                        },
                        
                        Board = new Board()
                        {
                            Link = "c"
                        }
                    }
                };

                return View(threads);
            }

            return Content("Сасай))))");
        }


        // /cg/res/2066095.html
        // /{board}/res/{threadId}.html
        [HttpGet("{board}/res/{threadId:int}.html")]
        public ActionResult ThreadComments(string board, int threadId)
        {
            var comment1 = new Comment()
            {
                UserText =
                    "Не слушай блядь этих умников, делай то что хочешь. Хочется тебе ездить на новой тачке - купи и езди, один раз живём. Завтра ебнет тебя коронавируса осложнения, толку тебе с твоих рублей в носке, если желаемых удовольствий от своего труда и жизни не получил. Можно купить мороженое и жрать его причмокивая от удовольствия, а кому-то важнее рубалек в копилку и дрочить на свои бохатства.\nУ меня одногруппник Саша был, он до болезни рачительный был, ходил в одной рубашке годами, с одним пожухлым пэт пакетом целый учебный год, ел экономно, жил экономно, о машине не мечтал - это слишком дорого, под подушку откладывал. Нахуй так жить",
                Id = 2,
                CreatedAt = new DateTime()
            };

            var comment2 = new Comment()
            {
                UserText =
                    "А, понятно. Какая-то хуета, существующая для электовыставок и в виде рендера от школоты. Держи в курсе, когда он появится, как реальная машина. Пиздец. Ты как плешивая мразь со своим су57, лол.",
                Id = 3,
                CreatedAt = new DateTime()
            };

            var thread1 = new BoardThread
            {
                UserText = "Oh, shit. I'm sorry.",
                Id = 4,
                CreatedAt = new DateTime(),

                Comments = new List<Comment>
                {
                    comment1, comment2
                }
            };

            return View(thread1);
        }
    }
}