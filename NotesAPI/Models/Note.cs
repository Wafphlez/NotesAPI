using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace NotesAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string Content { get; set; }

        [Required]
        [MaxLength(7)]
        public string ColorCode { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }
    }
}
