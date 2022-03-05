using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.DTOs
{
    public class NoteGetShortRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ColorCode { get; set; }
        public DateTime DateModified { get; set; }
    }
}
