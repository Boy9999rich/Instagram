namespace Instagram.Bll.Dto;

public class CommentCreateDto
{
    public string body { get; set; }
    public long AccountId { get; set; }
    public long PostId { get; set; }
    public long? ParentCommentId { get; set; }
}
