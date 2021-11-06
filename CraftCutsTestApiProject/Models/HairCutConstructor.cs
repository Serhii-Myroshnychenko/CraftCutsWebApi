using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Models
{
    public class HairCutConstructor
    {
        [Required]
        public IFormFile Data { get; set; }

        public string Name { get; set; }
    }
}
