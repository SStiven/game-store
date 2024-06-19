using FluentValidation;

namespace GameStore.Application.Publishers.Commands.CreatePublisher;

public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
{
    private const int MaxCompanyNameLength = 100;
    private const int MaxDescriptionLength = 500;
    private const int MaxHomePageLength = 200;

    public CreatePublisherCommandValidator()
    {
        RuleFor(pr => pr)
            .NotNull();

        RuleFor(pr => pr.CompanyName)
            .NotEmpty()
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Company name cannot be empty or consist only of white spaces.")
            .MaximumLength(MaxCompanyNameLength);

        RuleFor(pr => pr.Description)
            .MaximumLength(MaxDescriptionLength);

        RuleFor(pr => pr.HomePage)
            .MaximumLength(MaxHomePageLength)
            .Must(homePage => homePage == null || IsValidUrl(homePage))
            .WithMessage("HomePage must be a valid URL if provided.");
    }

    private static bool IsValidUrl(string homePage)
    {
        return Uri.TryCreate(homePage, UriKind.Absolute, out Uri? uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
