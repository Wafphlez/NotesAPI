using AutoMapper;
using NotesAPI.DTOs;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Profiles
{
    public class NotesProfile : Profile
    {
        public NotesProfile()
        {
            CreateMap<Note, NoteGetShortRequest>();
            CreateMap<NotePostRequest, Note>();
            CreateMap<NotePutRequest, Note>();
            CreateMap<Note, NotePatchRequest>();
            CreateMap<NotePatchRequest, Note>();
        }
    }
}
