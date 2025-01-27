using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    public class NoteRepository
    {
        public List<Note> Notes;

        public NoteRepository() 
        {
            Notes = new List<Note>();
        }
        public void AddNewNote()
        {
            Note note = new Note();
            Notes.Add(note);
        }
    }

    public class Note
    {

    }
}
