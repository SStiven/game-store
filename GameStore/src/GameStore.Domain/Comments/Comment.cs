namespace GameStore.Domain.Comments;

public class Comment
{
    private const int MaxNameLength = 100;
    private const int MaxBodyLength = 255;

    public Comment(string name, string body, Guid? parentId, Guid gameId)
    {
        Id = Guid.NewGuid();

        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

        if (name.Length > MaxNameLength)
        {
            throw new ArgumentException($"Name length should be less than {MaxNameLength}");
        }

        Name = name;

        ArgumentException.ThrowIfNullOrEmpty(body, nameof(body));
        if (body.Length > MaxBodyLength)
        {
            throw new ArgumentException($"Body length should be less than {MaxBodyLength}");
        }

        Body = body;

        ParentId = parentId;
        GameId = gameId;

        var newList = new List<Comment>();
        Replies = newList;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Body { get; }

    public Guid? ParentId { get; }

    public Guid GameId { get; }

    public List<Comment> Replies { get; }

    public void AddReply(Comment comment)
    {
        if (comment.ParentId != Id)
        {
            throw new ArgumentException("ParentId should be the same as the Id of the parent comment");
        }

        Replies.Add(comment);
    }
}
