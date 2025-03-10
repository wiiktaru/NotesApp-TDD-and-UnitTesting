using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    /// <summary>
    /// Handles userinteraction 
    /// </summary>
    public class UserInteraction
    {

        /// <summary>
        /// Validates a given note ID by checking if it is a valid positive integer 
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public bool ValidateNoteId(string noteId)
        {
            if (!int.TryParse(noteId, out int result))
            {
              Console.WriteLine("Virhe, syötä kelvollinen kokonaisluku.");
                return false;
            }

            if (result <= 0)
            {
                Console.WriteLine("Virhe, syötä positiivinen kokonaisluku.");
                return false;
            }

            return true;    
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
