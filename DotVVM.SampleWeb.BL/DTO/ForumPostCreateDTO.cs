using System.ComponentModel.DataAnnotations;

namespace DotVVM.SampleWeb.BL.DTO
{
    public class ForumPostCreateDTO
    {
        [Required(ErrorMessage = "The Message is required!")]
        public string Message { get; set; }
    }
}