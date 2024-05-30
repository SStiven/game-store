namespace GameStore.Application.Common.Interfaces;

public interface IGenreRepository
{
    Task<bool> AreAllPresentAsync(IEnumerable<Guid> genreIds);
}
