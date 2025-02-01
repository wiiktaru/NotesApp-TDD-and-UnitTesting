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
        public void ValidateNoteId_ValidInput_ReturnsInt()
        {
            int result = userInteraction.ValidateNoteId("1");

            Assert.AreEqual(1, result);
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
            Assert.ThrowsException<ArgumentException>(() => 
            userInteraction.ValidateNoteId(input));
        }

        [TestMethod]
        public void ValidateNoteId_NullInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            userInteraction.ValidateNoteId(null));
        }
    }
}
