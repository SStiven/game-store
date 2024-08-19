using GameStore.Domain.Games;

namespace GameStore.Domain.Publishers;

public class Publisher
{
    public Publisher(string companyName, string? homePage, string? description, string? contactName = null)
    {
        Id = Guid.NewGuid();
        CompanyName = companyName;
        HomePage = homePage;
        Description = description;
        ContactName = contactName;
    }

    private Publisher()
    {
    }

    public Guid Id { get; private set; }

    public string CompanyName { get; private set; }

    public string? ContactName { get; private set; }

    public string? HomePage { get; private set; }

    public string? Description { get; private set; }

    public ICollection<Game> Games { get; private set; }

    public void Update(string companyName, string? homePage, string? description, string? contactName = null)
    {
        CompanyName = companyName;
        HomePage = homePage;
        Description = description;

        if (contactName is not null)
        {
            ContactName = contactName;
        }
    }
}
