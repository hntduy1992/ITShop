using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITShop.Models.Requests
{
    public class CategoryFormRequest
    {
        [Required(ErrorMessage ="Vui lòng không để trống")]
        public string Name { get; set; }
        [AllowNull]
        public int ParentId { get; set; }
    }
}
