namespace GameStore.Domain.Comments;

public class Comment
{
    private const int MaxNameLength = 100;
    private const int MaxBodyLength = 255;
    private const string DeletedCommentText = "A comment/quote was deleted";

    public Comment(string name, string body, Guid? parentId, Guid gameId, CommentType type)
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
        Type = type;
        IsDeleted = false;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Body { get; private set; }

    public Guid? ParentId { get; }

    public Comment ParentComment { get; set; }

    public Guid GameId { get; }

    public CommentType Type { get; }

    public List<Comment> Replies { get; }

    public bool IsDeleted { get; private set; }

    public void AddReply(Comment comment)
    {
        if (comment.ParentId != Id)
        {
            throw new ArgumentException("ParentId should be the same as the Id of the parent comment");
        }

        Replies.Add(comment);
    }

    public void Delete()
    {
        IsDeleted = true;
        Body = "A comment/quote was deleted";
    }

    public string GetDisplayText()
    {
        return IsDeleted
            ? Body
            : Type switch
            {
                CommentType.Reply => $"[{GetParentAuthorName()}], {Body}",
                CommentType.Quote => $"[{GetParentBodyText()}], {Body}",
                CommentType.New => Body,
                _ => throw new NotImplementedException(),
            };
    }

    private string GetParentAuthorName()
    {
        return ParentComment?.Name ?? "Unknown Author";
    }

    private string GetParentBodyText()
    {
        return ParentComment is null
            ? DeletedCommentText : ParentComment.IsDeleted
            ? DeletedCommentText : ParentComment.Body;
    }
}
