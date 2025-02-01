using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    public class UserInteraction
    {
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
    }
}
