using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            bool result = userInteraction.ValidateNoteId("1");

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("!")]
        [DataRow("1.2")]
        [DataRow("-1")]
        [DataRow("0")]
        public void ValidateNoteId_InvalidInput_ThrowsArgumentException(string input)
        {
            bool result = userInteraction.ValidateNoteId(input);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateNoteId_NullInput_ThrowsArgumentException()
        {
            bool result = userInteraction.ValidateNoteId(null);

            Assert.AreEqual(false, result);
        }
    }
}
