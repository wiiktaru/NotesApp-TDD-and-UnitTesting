using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.UnitTests
{
    [TestClass]
    public class UserInteractionTests
    {
        private UserInteraction userInteraction; 

        [TestInitialize]
        public void TestInitialization()
        {
            userInteraction = new UserInteraction();
        }

        [TestMethod]
        public void ValidateNoteId_ValidInput_ReturnsTrue()
        {
            bool result = userInteraction.ValidateNoteId();

            Assert.AreEqual(true, result);
        }
    }
}
