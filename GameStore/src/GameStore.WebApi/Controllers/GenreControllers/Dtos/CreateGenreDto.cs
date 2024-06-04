namespace GameStore.WebApi.Controllers.GenreControllers.Dtos;

public record CreateGenreDto(string Name, Guid? ParentGenreId);