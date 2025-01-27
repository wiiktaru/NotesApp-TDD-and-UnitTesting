
namespace NotesApp.UnitTests
{
    [TestClass]
    public class NoteRepositoryTests
    {
        NoteRepository noteRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            noteRepository = new NoteRepository();
        }

        [TestMethod]
        public void AddNewNote_ValidInput_AddsNewNoteToList()
        { 
            noteRepository.AddNewNote();
            int notesCount = noteRepository.Notes.Count;

            Assert.AreEqual(notesCount, 1);
        }
    }
}