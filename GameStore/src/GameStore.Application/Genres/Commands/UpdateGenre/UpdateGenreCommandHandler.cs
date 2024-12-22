using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Commands.UpdateGenre;

public class UpdateGenreCommandHandler(
    IGenreRepository genreRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateGenreCommand, ErrorOr<Genre>>
{
    private readonly IGenreRepository _genreRepository = genreRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Genre>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.Id);
        if (genre == null)
        {
            return Error.NotFound($"The genre with id {request.Id} was not found");
        }

        if (request.ParentGenreId != null && request.ParentGenreId == request.Id)
        {
            return Error.Validation("A genre can't be its own parent");
        }

        Genre? newParentGenre = null;
        if (request.ParentGenreId != null)
        {
            newParentGenre = await _genreRepository.GetByIdAsync((Guid)request.ParentGenreId);
            if (newParentGenre == null)
            {
                return Error.NotFound($"The parent genre with id {request.ParentGenreId} was not found");
            }
        }

        genre.Update(request.Name, newParentGenre);

        await _genreRepository.Update(genre);
        await _unitOfWork.SaveChangesAsync();

        return genre;
    }
}