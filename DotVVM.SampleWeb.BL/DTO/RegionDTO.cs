using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Riganti.Utils.Infrastructure.Core;

namespace DotVVM.SampleWeb.BL.DTO
{
    public class RegionDTO : IEntity<int>
    {

        public int Id { get; set; }

        [Required]
        public string RegionDescription { get; set; }

    }
}
