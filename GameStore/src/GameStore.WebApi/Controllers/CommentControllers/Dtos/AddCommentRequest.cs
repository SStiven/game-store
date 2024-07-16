using GameStore.Domain.Comments;

namespace GameStore.WebApi.Controllers.CommentControllers.Dtos;

public record AddCommentRequest(
    CommentDto Comment,
    Guid? ParentId,
    CommentType ActionType);