using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DotVVM.SampleWeb.BL.DTO
{
    public class CategoryDetailDTO : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }


        public bool HasPicture { get; set; }

    }
}