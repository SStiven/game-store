namespace GameStore.WebApi.Controllers.GenreControllers.Dtos;

public record UpdateGenreDto(Guid Id, string Name, Guid? ParentGenreId);
