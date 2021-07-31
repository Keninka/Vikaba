using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Vikaba.Models
{
    public class CreateThread
    {
        [DisplayName("Элекронная почта")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [DisplayName("Имя пользователя")] public string UserName { get; set; } = "";

        [DisplayName("Заголовок")] public string Headline { get; set; } = "";

        [Required] [DisplayName("Пост")] public string Content { get; set; } = "";

        [Required]
        [DisplayName("Изображение")]
        public IFormFile Image { get; set; } = null!;
    }
}