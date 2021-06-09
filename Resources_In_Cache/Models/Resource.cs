using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resources_In_Cache.Models
{
    public class Resource
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
