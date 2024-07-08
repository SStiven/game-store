namespace GameStore.WebApi.Controllers.CommentControllers.Dtos;

public record CommentWithReply(
    Guid Id,
    string Name,
    string Body,
    IEnumerable<CommentWithReply> ChildComments);