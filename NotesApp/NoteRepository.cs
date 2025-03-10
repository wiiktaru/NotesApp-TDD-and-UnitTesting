using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    /// <summary>
    /// Serves as a repository for storing and managing notes 
    /// </summary>
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

        /// <summary>
        /// Validates a given note by checking if it is null or if it exists in the list of notes. 
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Chechks if a given note has a duplicate in the list of notes
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a give note to the list of notes if the note is valid and not a duplicate
        /// </summary>
        /// <param name="note"></param>
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

        /// <summary>
        /// Deletes a given note from the list of notes if the note is valid and in the list of notes
        /// </summary>
        /// <param name="note"></param>
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
        public void EditNoteTitle(int noteId)
        {

            //noteValidation = ValidateNote(note);
            foreach (var item in Notes)
            {
                if (item.Id == noteId)
                {
                  string title = AskUserForNewTitle();
                  item.Title = title;
                  Console.WriteLine("Otsikko muutettu onnistuneesti. Uusi otsikko: " + item.Title);
                }
            }
        }

      public string AskUserForNewTitle()
        {
            string title = Console.ReadLine(); 

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Virhe, otsikko ei voi olla tyhjä tai sisältää vain välilyöntejä");
            }

            return title;
        }
    }
}
