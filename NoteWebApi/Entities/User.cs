namespace NoteWebApi.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Note> Notes { get; set; }

    }
}
