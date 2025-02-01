using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.UnitTests
{
    internal class UserInteractionTests
    {
        [TestMethod]
        public void ValidateNoteId_ValidInput_ReturnsTrue()
        {
            bool result = UserInteraction.ValidateNoteId();

            Assert.AreEqual(true, result );
        }
    }
}
