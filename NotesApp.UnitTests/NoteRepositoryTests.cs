
namespace NotesApp.UnitTests
{
    [TestClass]
    public class NoteRepositoryTests
    {
        NoteRepository noteRepository;
        int notesCount;

        [TestInitialize]
        public void TestInitialize()
        {
            noteRepository = new NoteRepository();
        }

        [TestMethod]
        public void AddNewNote_ValidInput_AddsNewNoteToList()
        { 
            noteRepository.AddNewNote();
            notesCount = noteRepository.Notes.Count;

            Assert.AreEqual(notesCount, 1);
        }

        [TestMethod]
        public void AddNewNote_NoNote_DoesNotAddANoteToList()
        {
            Assert.AreEqual(notesCount, 1);
        }
    }
}