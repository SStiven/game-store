namespace GameStore.Application.Common.Interfaces;

public interface IPlatformRepository
{
    Task<bool> AreAllPresentAsync(IEnumerable<Guid> platformIds);
}
