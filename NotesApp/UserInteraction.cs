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
          
            return int.Parse(noteId);
            
        }
    }
}
