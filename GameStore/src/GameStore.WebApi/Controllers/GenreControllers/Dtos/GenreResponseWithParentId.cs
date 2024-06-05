namespace GameStore.WebApi.Controllers.GenreControllers.Dtos;

public record GenreResponseWithParentId(Guid Id, string Name, Guid? ParentGenreId);