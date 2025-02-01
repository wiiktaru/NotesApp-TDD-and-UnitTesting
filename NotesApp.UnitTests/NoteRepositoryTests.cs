

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
            note = new Note { Id = 1, Title = "AA" };
            noteRepository.Notes.Add(note);
        }


        [TestMethod]
        public void ValidateNote_ValidNote_ReturnsTrue()
        {
            var result = noteRepository.ValidateNote(note);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateNote_InvalidNote_ReturnsFalse()
        {
            Note note2 = new Note { Id = 2 };
            var result = noteRepository.ValidateNote(note2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckDuplicateNotes_NotDuplicate_ReturnsFalse()
        {
            Note note1 = new Note { Id = 2 };
            var result = noteRepository.CheckDuplicateNotes(note1);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckDuplicateNotes_IsDuplicate_ReturnsTrue()
        {
            Note note1 = new Note { Id = 1 };
            var result = noteRepository.CheckDuplicateNotes(note1);

            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void AddNewNote_ValidNote_AddsNewNoteToList()
        { 
            Assert.AreEqual(1, noteRepository.Notes.Count);
        }

        [TestMethod]
        public void AddNewNote_NullNote_DoesNotAddANoteToList()
        {
            noteRepository.AddNewNote(null);
            notesCount = noteRepository.Notes.Count;
            Assert.AreEqual(notesCount, 1);
        }

        [TestMethod]
        public void DeleteNote_ValidNote_DeletesNoteFromList()
        {
            noteRepository.DeleteNote(note);
            notesCount = noteRepository.Notes.Count;

            Assert.AreEqual(notesCount, 0);
        }

        [TestMethod]
        public void DeleteNote_NullNote_DoesNotDeleteNoteFromList()
        {
            noteRepository.DeleteNote(null);

            Assert.AreEqual(noteRepository.Notes.Count, 1);
        }

        [TestMethod]
       public void DeleteNote_InvalidNote_DoesNotDeleteNoteFromList()
        {
            Note invalidNote = new Note { Id = 2 }; 

            noteRepository.DeleteNote(invalidNote);

            Assert.AreEqual(1, noteRepository.Notes.Count);
        }

        [TestMethod]
        public void DeleteNote_EmptyNotesList_DoesNotDeleteNoteFromList()
        {
            //delete initialized note from Notes list
            noteRepository.DeleteNote(note);

            noteRepository.DeleteNote(note);

            Assert.AreEqual(0, noteRepository.Notes.Count);
        }

        [TestMethod]
        public void EditNoteTitle_ValidNote_EditsTitle()
        {
            noteRepository.EditNoteTitle(note, "BB");

            Assert.AreEqual(note.Title, "BB");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void EditNoteTitle_InvalidTitle_DoesNotEditTitle(string invalidTitle)
        {
            noteRepository.EditNoteTitle(note, invalidTitle);

            Assert.AreEqual(note.Title, "AA");
        }

        [TestMethod]
        public void EditNoteTitle_NullTitle_EditsTitle()
        {
            Note note1 = new Note { Id = 2, Title = null };
            noteRepository.Notes.Add(note1);

            Assert.AreEqual("AA", note1.Title);

        }

        [TestMethod]
        public void EditNoteTitle_NullNote_DoesNotEditTitle()
        {
            noteRepository.EditNoteTitle(null, "BB");
  
            Assert.AreEqual(note.Title, "AA");
        }

        [TestMethod]
        [DataRow (2)]
        [DataRow(null)]
        [DataRow(2.1)]
        public void EditNoteTitle_InvalidNoteId_DoesNotEditTitle(int invalidNoteId)
        {
            Note note1 = new Note { Id = invalidNoteId };
            noteRepository.EditNoteTitle(note1, "BB");
            ;
            Assert.AreEqual(note.Title, "AA");
        }

    }
}