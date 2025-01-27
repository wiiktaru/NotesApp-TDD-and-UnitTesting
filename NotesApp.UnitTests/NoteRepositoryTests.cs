
namespace NotesApp.UnitTests
{
    [TestClass]
    public class NoteRepositoryTests
    {
        NoteRepository noteRepository;
        int notesCount;
        Note note; 

        [TestInitialize]
        public void TestInitialize()
        {
            noteRepository = new NoteRepository();
            note = new Note();
        }

        [TestMethod]
        public void AddNewNote_ValidNote_AddsNewNoteToList()
        { 
            noteRepository.AddNewNote(note);
            notesCount = noteRepository.Notes.Count;

            Assert.AreEqual(notesCount, 1);
        }

        [TestMethod]
        public void AddNewNote_NullNote_DoesNotAddANoteToList()
        {
            noteRepository.AddNewNote(null);
            notesCount = noteRepository.Notes.Count;
            Assert.AreEqual(notesCount, 0);
        }

        [TestMethod]
        public void AddNewNote_DuplicateNote_DoesNotAddNoteToList()
        {
            note.Id = 1;
            noteRepository.AddNewNote(note);
            notesCount = noteRepository.Notes.Count;

            Note note1 = new Note();
            note1.Id = 1;
            noteRepository.AddNewNote(note1);
            int newCount = noteRepository.Notes.Count;
            Assert.AreEqual(notesCount, newCount);
        }
    }
}