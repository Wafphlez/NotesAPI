using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Data;
using NotesAPI.DTOs;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepo _repository;
        private readonly IMapper _mapper;

        public NotesController(INotesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/notes/
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            var notes = _repository.GetAllNotes();

            return Ok(notes);
        }

        //GET api/notes/short
        [HttpGet("short")]
        public ActionResult<IEnumerable<NoteGetShortRequest>> GetAllShortNotes()
        {
            var notes = _repository.GetAllNotes();

            return Ok(_mapper.Map<IEnumerable<NoteGetShortRequest>>(notes));
        }

        //GET api/notes/5
        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteById(int id)
        {
            var note = _repository.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        //GET api/notes/short/5
        [HttpGet("short/{id}")]
        public ActionResult<NoteGetShortRequest> GetShortNoteById(int id)
        {
            var note = _repository.GetNoteById(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NoteGetShortRequest>(note));
        }

        //POST api/notes/
        [HttpPost()]
        public ActionResult<NotePostRequest> PostNote(NotePostRequest noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);

            note.DateCreated = DateTime.Now;
            note.DateModified = DateTime.Now;

            _repository.PostNote(note);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetNoteById), new { Id = note.Id }, note);
        }

        //PUT api/notes/5
        [HttpPut("{id}")]
        public ActionResult<NotePutRequest> PutNote(int id, NotePutRequest noteDto)
        {
            var note = _repository.GetNoteById(id);

            if (note == null)
            {
                return NotFound();
            }

            note.DateCreated = DateTime.Now;
            note.DateModified = DateTime.Now;

            _mapper.Map(noteDto, note);

            _repository.PutNote(note);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/notes/5
        [HttpPatch("{id}")]
        public ActionResult PatchNote(int id, JsonPatchDocument<NotePatchRequest> patchDocument)
        {
            var note = _repository.GetNoteById(id);

            if (note == null)
            {
                return NotFound();
            }

            var noteToPatch = _mapper.Map<NotePatchRequest>(note);

            patchDocument.ApplyTo(noteToPatch, ModelState);

            if (!TryValidateModel(noteToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(noteToPatch, note);

            _repository.PatchNote(note);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/notes/5
        [HttpDelete("{id}")]
        public ActionResult<Note> DeleteNote(int id)
        {
            var note = _repository.GetNoteById(id);

            if (note == null)
            {
                return NotFound();
            }

            _repository.DeleteNote(note);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
