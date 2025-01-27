
namespace NotesApp.UnitTests
{
    [TestClass]
    public class NoteRepositoryTests
    {
        [TestMethod]
        public void AddNewNote_ValidInput_AddsNewNoteToList()
        {
            NotesApp.NoteRepository noteRepo = new NotesApp.NoteRepository();
            noteRepo.AddNewNote();
            int notesCount = noteRepo.Notes.Count;

            Assert.AreEqual(notesCount, 1);
        }
    }
}