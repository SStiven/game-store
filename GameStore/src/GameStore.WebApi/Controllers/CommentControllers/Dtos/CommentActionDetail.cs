using GameStore.Domain.Comments;

namespace GameStore.WebApi.Controllers.CommentControllers.Dtos;

public record CommentActionDetail(CommentAction ActionType, Guid? QuoteId);
