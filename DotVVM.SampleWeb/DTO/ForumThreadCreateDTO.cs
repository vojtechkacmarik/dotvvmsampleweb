﻿using System.ComponentModel.DataAnnotations;

namespace DotVVM.SampleWeb.Dto
{
    public class ForumThreadCreateDTO
    {
        [Required(ErrorMessage = "The Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Message is required!")]
        public string Message { get; set; }
    }
}