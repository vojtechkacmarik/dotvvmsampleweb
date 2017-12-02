using System.ComponentModel.DataAnnotations;

namespace DotVVM.SampleWeb.DTO
{
    public class ForumPostCreateDTO
    {
        [Required(ErrorMessage = "The Message is required!")]
        public string Message { get; set; }
    }
}