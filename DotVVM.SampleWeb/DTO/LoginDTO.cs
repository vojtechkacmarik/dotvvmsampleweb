using System.ComponentModel.DataAnnotations;

namespace DotVVM.SampleWeb.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "The User Name is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is required!")]
        public string Password { get; set; }
    }
}