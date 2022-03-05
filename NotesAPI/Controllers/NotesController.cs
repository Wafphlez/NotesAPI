using AutoMapper;
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
        public ActionResult<Note> PostNote(Note note)
        {
            _repository.PostNote(note);

            return Ok(note);
        }

    }
}
