using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    public class UserInteraction
    {
        public int ValidateNoteId(string noteId)
        {
            if (!int.TryParse(noteId, out int result))
            {
                throw new ArgumentException("Virhe, syötä kelvollinen kokonaisluku.");
            }

            if (result < 0)
            {
                throw new ArgumentException("Virhe, syötä positiivinen kokonaisluku.");
            }

            return result;    
        }
    }
}
