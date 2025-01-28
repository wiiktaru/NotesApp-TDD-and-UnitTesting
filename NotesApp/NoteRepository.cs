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

        public bool ValidateNote(Note note)
        {
            if (note == null)
            {
                return false;
            }
            return true;
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

        //TODO simplify this method 
        public void DeleteNote(Note note)
        {
            bool noteDeleted = false;

            if (note == null)
            {
                Console.WriteLine("Virhe, merkintä ei voi olla tyhjä.");
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
                Console.WriteLine("Virhe, poistettavaksi tarkoitettu merkintä ei ollut listassa.");
            }
        }

        //TODO Simplify this method 
        public void EditNoteTitle(Note note, string title)
        {
            bool isOnList = false; 

            if(note == null)
            {
                Console.WriteLine("Virhe, merkintä ei voi olla tyhjä.");
                return;
            }

            foreach (var item in Notes)
            {
                if (item.Id == note.Id)
                {
                    isOnList = true;
                    break;
                }
            }

            if (!isOnList)
            {
                Console.WriteLine("Virhe, merkintää ei ole listalla");
                return;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Virhe, otsikko ei voi olla tyhjä tai sisältää vain välilyöntejä");
                return;
            }

            note.Title = title;
        }
    }
}
