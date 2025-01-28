
namespace NotesApp.UnitTests
{
    [TestClass]
    public class NoteRepositoryTests
    {
        private NoteRepository noteRepository;
        private int notesCount;
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

        [TestMethod]
        public void DeleteNote_ValidNote_DeletesNoteFromList()
        {
            note.Id = 1;
            noteRepository.AddNewNote(note);
            noteRepository.DeleteNote(note);
            notesCount = noteRepository.Notes.Count;

            Assert.AreEqual(notesCount, 0);
        }

        [TestMethod]
        public void DeleteNote_NullNote_DoesNotDeleteNoteFromList()
        {
            noteRepository.AddNewNote(note);
            
            noteRepository.DeleteNote(null);

            Assert.AreEqual(noteRepository.Notes.Count, 1);
        }

        [TestMethod]
       public void DeleteNote_InvalidNote_DoesNotDeleteNoteFromList()
        {
            note.Id = 1;
            noteRepository.AddNewNote(note);

            Note invalidNote = new Note { Id = 2 }; 

            noteRepository.DeleteNote(invalidNote);

            Assert.AreEqual(1, noteRepository.Notes.Count);
        }

        [TestMethod]
        public void EditNoteTitle_ValidNote_EditsTitle()
        {
            note.Title = "AA";
            noteRepository.EditNoteTitle(note, "BB");

            Assert.AreEqual(note.Title, "BB");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void EditNoteTitle_InvalidTitle_DoesNotEditTitle(string invalidTitle)
        {
            note.Title = "AA";
            noteRepository.EditNoteTitle(note, invalidTitle);

            Assert.AreEqual(note.Title, "AA");
        }

        [TestMethod]
        public void EditNoteTitle_InvalidNote_DoesNotEditTitle()
        {
            note.Title = "AA";
            noteRepository.EditNoteTitle(null, "BB");

            Assert.AreEqual(note.Title, "AA");
        }
    }
}