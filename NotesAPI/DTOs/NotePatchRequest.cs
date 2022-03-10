using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.DTOs
{
    public class NotePatchRequest
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string Content { get; set; }

        [Required]
        [MaxLength(7)]
        public string ColorCode { get; set; }
    }
}
