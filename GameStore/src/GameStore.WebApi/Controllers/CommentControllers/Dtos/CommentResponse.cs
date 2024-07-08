namespace GameStore.WebApi.Controllers.CommentControllers.Dtos;

public record CommentResponse(
    Guid Id,
    string Name,
    string Body,
    Guid? ParentId,
    Guid GameId);
