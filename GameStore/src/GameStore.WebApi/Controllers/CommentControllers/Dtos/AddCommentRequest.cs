namespace GameStore.WebApi.Controllers.CommentControllers.Dtos;

public record AddCommentRequest(
    CommentDto Comment,
    Guid? ParentId,
    CommentActionDetail? Action);