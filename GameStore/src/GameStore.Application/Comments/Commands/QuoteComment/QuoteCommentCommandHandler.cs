﻿using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Comments;
using MediatR;

namespace GameStore.Application.Comments.Commands.QuoteComment;

public class QuoteCommentCommandHandler(
    ICommentRepository commentsRepository,
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<QuoteCommentCommand, ErrorOr<Comment>>
{
    private readonly ICommentRepository _commentsRepository = commentsRepository;
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Comment>> Handle(QuoteCommentCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        if (game is null)
        {
            return Error.NotFound(description: "Game not found.");
        }

        if (!request.ParentId.HasValue)
        {
            return Error.Validation(description: "ParentId is required for quote action.");
        }

        if (!request.QuoteId.HasValue)
        {
            return Error.Validation(description: "QuoteId is required for quote action.");
        }

        var parentComment = await _commentsRepository.GetByIdAsync(request.ParentId.Value);
        if (parentComment is null)
        {
            return Error.NotFound(description: "Parent comment not found.");
        }

        var quotedComment = await _commentsRepository.GetByIdAsync(request.QuoteId.Value);
        if (quotedComment is null)
        {
            return Error.NotFound(description: "Quoted comment not found.");
        }

        var comment = new Comment(
            request.Name,
            $"[{quotedComment.Body}], {request.Body}",
            request.ParentId,
            game.Id);

        await _commentsRepository.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return comment;
    }
}