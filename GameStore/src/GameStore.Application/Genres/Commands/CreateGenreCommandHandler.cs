using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Commands;

public class CreateGenreCommandHandler(
    IGenreRepository genreRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateGenreCommand, ErrorOr<Genre>>
{
    private readonly IGenreRepository _genreRepository = genreRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Genre>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        if (request.ParentGenreId != null)
        {
            var subgenre = await _genreRepository.GetByIdAsync(request.ParentGenreId.Value);
            if (subgenre is null)
            {
                return Error.Validation("Parent genre not found");
            }
        }

        var genre = new Genre(request.Name, request.ParentGenreId);
        await _genreRepository.AddAsync(genre);
        await _unitOfWork.SaveChangesAsync();
        return genre;
    }
}