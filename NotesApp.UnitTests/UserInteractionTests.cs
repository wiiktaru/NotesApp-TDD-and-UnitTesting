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
        public void ValidateNoteId_ValidInput_ReturnsInt()
        {
            int result = userInteraction.ValidateNoteId("1");

            Assert.AreEqual(1, result);
        }
    }
}
