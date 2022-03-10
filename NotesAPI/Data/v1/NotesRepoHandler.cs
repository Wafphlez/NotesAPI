using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Data
{
    public class NotesRepoHandler : INotesRepo
    {
        private NotesContext _context;

        public NotesRepoHandler(NotesContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public Note GetNoteById(int id)
        {
            // return _context.Notes.Where(x => x.Id == id).FirstOrDefault();

            return _context.Notes.FirstOrDefault(x => x.Id == id);
        }

        public void PostNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Notes.Add(note);
        }

        public void PutNote(Note note)
        {

        }

        public void PatchNote(Note note)
        {
            
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Notes.Remove(note);
        }
    }
}
