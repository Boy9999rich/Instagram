namespace Instagram.Dal.Entity;

public class Post
{
    public long PostId { get; set; }
    public string PostType { get; set; }
    public DateTime CreatedTime { get; set; }
    public long AccountId { get; set; }
    public Account Account { get; set; }

    public List<Comment> Comments { get; set; }
}
