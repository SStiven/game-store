namespace GameStore.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}