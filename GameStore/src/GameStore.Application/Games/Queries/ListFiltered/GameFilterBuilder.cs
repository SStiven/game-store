using System.Linq.Expressions;

using GameStore.Application.Games.Queries.ListPaginationOptions;
using GameStore.Application.Games.Queries.ListSortingOptions;
using GameStore.Domain.Games;

using LinqKit;

namespace GameStore.Application.Games.Queries.ListFiltered;

public class GameFilterBuilder
{
    private readonly FilterParameters _filterParameters = new();

    public SortingOptions? SortingOption => _filterParameters.Sort;

    public int? Page => _filterParameters.Page?.ToInt();

    public int? PageCount => _filterParameters.PageCount;

    public GameFilterBuilder ByName(string? name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            _filterParameters.Name = name;
        }

        return this;
    }

    public GameFilterBuilder ByMaxPrice(double? maxPrice)
    {
        if (maxPrice.HasValue)
        {
            _filterParameters.MaxPrice = maxPrice;
        }

        return this;
    }

    public GameFilterBuilder ByMinPrice(double? minPrice)
    {
        if (minPrice.HasValue)
        {
            _filterParameters.MinPrice = minPrice;
        }

        return this;
    }

    public GameFilterBuilder ByPlatforms(IReadOnlyList<Guid>? platformIds)
    {
        if (platformIds is null)
        {
            return this;
        }

        _filterParameters.Platforms = platformIds;
        return this;
    }

    public GameFilterBuilder ByGenres(IReadOnlyList<Guid>? genreIds)
    {
        if (genreIds is null)
        {
            return this;
        }

        _filterParameters.Genres = genreIds;
        return this;
    }

    public GameFilterBuilder ByPublishers(IReadOnlyList<Guid>? publisherIds)
    {
        if (publisherIds is null)
        {
            return this;
        }

        _filterParameters.Publishers = publisherIds;
        return this;
    }

    public GameFilterBuilder WithPage(int page)
    {
        _filterParameters.Page = PaginationOptionExtensions.FromInt(page);
        return this;
    }

    public GameFilterBuilder WithPageCount(int pageCount)
    {
        _filterParameters.PageCount = pageCount;
        return this;
    }

    public GameFilterBuilder Sort(string? sortType)
    {
        if (string.IsNullOrEmpty(sortType))
        {
            return this;
        }

        var sortingOption = SortingOptionsExtensions.FromString(sortType);
        _filterParameters.Sort = sortingOption;
        return this;
    }

    public Expression<Func<Game, bool>> Build()
    {
        var predicate = PredicateBuilder.New<Game>(true);
        if (!string.IsNullOrEmpty(_filterParameters.Name))
        {
            predicate = predicate.And(g => g.Name.Contains(_filterParameters.Name));
        }

        if (_filterParameters.MaxPrice.HasValue)
        {
            predicate = predicate.And(g => g.Price <= _filterParameters.MaxPrice);
        }

        if (_filterParameters.MinPrice.HasValue)
        {
            predicate = predicate.And(g => g.Price >= _filterParameters.MinPrice);
        }

        if (_filterParameters.Platforms?.Count > 0)
        {
            var platformsPredicate = PredicateBuilder.New<Game>();
            foreach (Guid platformGuid in _filterParameters.Platforms)
            {
                platformsPredicate = platformsPredicate.Or(g => g.GamePlatforms.Any(gp => gp.PlatformId == platformGuid));
            }

            predicate = predicate.And(platformsPredicate);
        }

        if (_filterParameters.Genres?.Count > 0)
        {
            var genresPredicate = PredicateBuilder.New<Game>();
            foreach (Guid genreGuid in _filterParameters.Genres)
            {
                genresPredicate = genresPredicate.Or(g => g.GameGenres.Any(gg => gg.GenreId == genreGuid));
            }

            predicate = predicate.And(genresPredicate);
        }

        if (_filterParameters.Publishers?.Count > 0)
        {
            var publishersPredicate = PredicateBuilder.New<Game>();
            foreach (Guid publisherGuid in _filterParameters.Publishers)
            {
                publishersPredicate = publishersPredicate.Or(g => g.PublisherId == publisherGuid);
            }

            predicate = predicate.And(publishersPredicate);
        }

        return predicate;
    }
}
