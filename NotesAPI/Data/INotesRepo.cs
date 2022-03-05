using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Data
{
    public interface INotesRepo
    {
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(int id);
        void PostNote(Note note);
    }
}
