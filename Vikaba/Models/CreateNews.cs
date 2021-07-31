using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Vikaba.Data;

namespace Vikaba.Models
{
    public class CreateNews
    {
        [Required]
        [DisplayName("Дата публикации")]
        public DateTime PublishedAt { get; set; }

        [Required]
        [MinLength(10)]
        [DisplayName("Заголовок")]
        public string Headline { get; set; } = "";
        
        [Required]
        [MinLength(10)]
        [DisplayName("Подзаголовок")]
        public string SubHeadline { get; set; } = "";
        
        [Required]
        [MinLength(20)]
        [DisplayName("Новость")]
        public string Content { get; set; } = "";
        
        [Required]
        [MinLength(5)]
        [DisplayName("Теги")]
        public string Tags { get; set; } = "";

        public IFormFile? Image { get; set; }
    }
}