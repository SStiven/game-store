using GameStore.Application.Comments.Commands.CreateNewComment;
using GameStore.Application.Comments.Commands.QuoteComment;
using GameStore.Application.Comments.Commands.ReplyToComment;
using GameStore.Application.Comments.Queries;
using GameStore.Domain.Bans;
using GameStore.Domain.Comments;
using GameStore.WebApi.Controllers.CommentControllers.Dtos;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.CommentControllers;

[Route("games")]
public class CommentsController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpPost("{key}/comments")]
    public async Task<IActionResult> AddComment(string key, [FromBody] AddCommentRequest request)
    {
        var result = request.ActionType switch
        {
            CommentType.Reply => await _mediator.Send(new ReplyToCommentCommand(
                                key,
                                request.Comment.Name,
                                request.Comment.Body,
                                request.ParentId)),
            CommentType.Quote => await _mediator.Send(new QuoteCommentCommand(
                                key,
                                request.Comment.Name,
                                request.Comment.Body,
                                request.ParentId)),
            CommentType.New => await _mediator.Send(new CreateNewCommentCommand(
                                            key,
                                            request.Comment.Name,
                                            request.Comment.Body,
                                            request.ParentId)),
            _ => throw new NotImplementedException(),
        };

        return result.Match(
            comment => CreatedAtAction(nameof(AddComment), new CommentResponse(
                comment.Id,
                comment.Name,
                comment.Body,
                comment.ParentId,
                comment.GameId)),
            Problem);
    }

    [HttpGet("{key}/comments")]
    public async Task<IActionResult> GetComments(string key)
    {
        var comments = await _mediator.Send(new ListCommentWithReplies(key));

        return Ok(comments.Select(MapToDto));
    }

    [HttpGet("/comments/ban/durations")]
    public async Task<IActionResult> GetBanDurations()
    {
        var banDurations = await _mediator.Send(new GetBanDurationsQuery());
        return Ok(banDurations.Select(bd => bd.ToDisplayString()));
    }

    private CommentWithReply MapToDto(Comment comment)
    {
        return new CommentWithReply(
            comment.Id,
            comment.Name,
            comment.GetDisplayText(),
            comment.Replies.Select(MapToDto));
    }
}
