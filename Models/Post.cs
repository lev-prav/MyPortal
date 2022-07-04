namespace Models;

public class Post
{
    public string Body  { get; set; }
    public ICollection<Comment> Comments  { get; set; }
    public DateTime CreatedDate  { get; set; }
    public string Hader  { get; set; }
    public int PostId  { get; set; }
    public ICollection<Tag> Tags  { get; set; }
}