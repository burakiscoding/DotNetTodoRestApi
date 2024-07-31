namespace DotNetTodoRestApi.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateadOn { get; set; }
        public int? TodoId { get; set; }
    }
}
