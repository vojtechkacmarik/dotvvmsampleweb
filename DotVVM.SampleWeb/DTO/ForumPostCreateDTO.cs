using System.ComponentModel.DataAnnotations;

namespace DotVVM.SampleWeb.Dto
{
    public class ForumPostCreateDTO
    {
        [Required(ErrorMessage = "The Message is required!")]
        public string Message { get; set; }
    }
}