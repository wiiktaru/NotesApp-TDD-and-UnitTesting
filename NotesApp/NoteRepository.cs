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

        public void AddNewNote(Note note)
        {
            if (note == null)
            {
                Console.WriteLine("Virhe, merkintä ei voi olla tyhjä");
                return;
            }
            foreach (var item in Notes) 
            {
                if (item.Id == note.Id)
                {
                    Console.WriteLine("Virhe, merkintä on jo olemassa");
                    return;
                }
            }  
            Notes.Add(note);
        }

        public void DeleteNote(Note note)
        {
            Notes.Remove(note);
        }
    }
}
