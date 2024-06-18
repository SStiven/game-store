using GameStore.Domain.Games;

namespace GameStore.Domain.Publishers;

public class Publisher
{
    public Publisher(string companyName, string? homePage, string? description)
    {
        Id = Guid.NewGuid();
        CompanyName = companyName;
        HomePage = homePage;
        Description = description;
    }

    private Publisher()
    {
    }

    public Guid Id { get; private set; }

    public string CompanyName { get; private set; }

    public string? HomePage { get; private set; }

    public string? Description { get; private set; }

    public ICollection<Game> Games { get; private set; }
}
