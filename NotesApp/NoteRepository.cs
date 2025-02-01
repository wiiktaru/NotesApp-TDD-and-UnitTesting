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
        private bool noteValidation = false; 
        private bool duplicateNote = false;

        private UserInteraction userInteraction;
        private bool validateNoteId = false;

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

            if (Notes.Count == 0)
            {
                return true; 
            }

            foreach (var item in Notes)
            {
                if (item.Id == note.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckDuplicateNotes(Note note)
        { 
            noteValidation = ValidateNote(note);

            if (noteValidation)
            {
                foreach (var item in Notes)
                {
                    if (item.Id == note.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddNewNote(Note note)
        {
            noteValidation = ValidateNote(note);
            duplicateNote = CheckDuplicateNotes(note);

            if (noteValidation && !duplicateNote)
            {
                Notes.Add(note);
                return;
            }

            Console.WriteLine("Virhe, merkintä on tyhjä tai ei listalla");
        }

        public void DeleteNote(Note note)
        {
            noteValidation = ValidateNote(note);

            if (noteValidation)
            {
                foreach (var item in Notes)
                {
                    if (item.Id == note.Id)
                    {
                        Notes.Remove(item);
                        return;
                    }
                }
            }

            Console.WriteLine("Virhe, merkintä on tyhjä, ei listalla tai lista on tyhjä");
        }

        //TODO fix this methood 
        public void EditNoteTitle(Note note, string title)
        {
            noteValidation = ValidateNote(note);
            validateNoteId = userInteraction.ValidateNoteId(note.Id.ToString());

           if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Virhe, otsikko ei voi olla tyhjä tai sisältää vain välilyöntejä");
                return;
            }

            if (noteValidation && validateNoteId)
            {
                note.Title = title;
                return;
            }

            Console.WriteLine("Virhe, merkintä on tyhjä tai ei listalla");
        } 
    }
}
