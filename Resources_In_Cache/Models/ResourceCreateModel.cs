using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resources_In_Cache.Models
{
    public class ResourceCreateModel
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
    }
}
