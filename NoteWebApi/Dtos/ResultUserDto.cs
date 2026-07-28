namespace NoteWebApi.Dtos
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ResultNoteDto> Notes { get; set; }
    }
}
