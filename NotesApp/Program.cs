namespace NotesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            NoteRepository repo = new NoteRepository();
            Note note = new Note { Id = 1 };

            repo.AddNewNote(note);

        }
    }
}
