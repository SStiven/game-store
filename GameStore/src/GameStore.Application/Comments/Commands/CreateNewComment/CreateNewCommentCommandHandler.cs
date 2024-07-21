using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Comments;

using MediatR;

namespace GameStore.Application.Comments.Commands.CreateNewComment;

public class CreateNewCommentCommandHandler(
    IUserBanRepository userBanRepository,
    ICommentRepository commentsRepository,
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateNewCommentCommand, ErrorOr<Comment>>
{
    private readonly IUserBanRepository _userBanRepository = userBanRepository;
    private readonly ICommentRepository _commentsRepository = commentsRepository;
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Comment>> Handle(CreateNewCommentCommand request, CancellationToken cancellationToken)
    {
        var userBan = await _userBanRepository.GetByUserNameAsync(request.Name);
        if (userBan is not null && !userBan.HasExpired(DateTime.Now))
        {
            return Error.Forbidden(description: "User is banned.");
        }

        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        if (game is null)
        {
            return Error.NotFound(description: "Game not found.");
        }

        if (request.ParentId is not null)
        {
            var parentComment = await _commentsRepository.GetByIdAsync((Guid)request.ParentId);
            if (parentComment is null)
            {
                return Error.NotFound(description: "Parent comment doesn't exist.");
            }
        }

        var comment = new Comment(
            request.Name,
            request.Body,
            request.ParentId,
            game.Id,
            CommentType.New);

        await _commentsRepository.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return comment;
    }
}