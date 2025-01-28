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
                WriteErrorMessage("Virhe, merkintä ei voi olla tyhjä");
                return;
            }
            foreach (var item in Notes) 
            {
                if (item.Id == note.Id)
                {
                    WriteErrorMessage("Virhe, merkintä on jo olemassa");
                    return;
                }
            }  
            Notes.Add(note);
        }

        //TODO simplify this method 
        public void DeleteNote(Note note)
        {
            bool noteDeleted = false;

            if (note == null)
            {
                WriteErrorMessage("Virhe, merkintä ei voi olla tyhjä.");
                return;
            }

            foreach (var item in Notes)
            {
                if (item.Id == note.Id)
                {
                    Notes.Remove(item);
                    noteDeleted = true;
                    break;
                }
            }

            if(!noteDeleted)
            {
                WriteErrorMessage("Virhe, poistettavaksi tarkoitettu merkintä ei ollut listassa.");
            }
        }

        public void WriteErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
