using FluentAssertions;

using GameStore.Domain.Platforms;

namespace GameStore.Domain.Tests.Platforms;

public class PlatformTests
{
    [Fact]
    public void CreatePlatformWithTooLongTypeShouldFail()
    {
        var exceedingByOneTheLength = 201;
        var tooLongType = new string('a', exceedingByOneTheLength);

        Action createPlatform = () => { var platform = new Platform(tooLongType); };

        createPlatform.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreatePlatformWithEmptyTypeShouldFail()
    {
        Action createPlatform = () => { var platform = new Platform(string.Empty); };

        createPlatform.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreatePlatformWithNullTypeShouldFail()
    {
        Action createPlatform = () => { var platform = new Platform(null); };

        createPlatform.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreatePlatformWithValidTypeShouldSucceed()
    {
        var validType = "PC";

        var platform = new Platform(validType);

        platform.Type.Should().Be(validType);
        platform.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void UpdatePlatformWithTooLongTypeShouldFail()
    {
        var platform = new Platform("PC");
        var exceedingByOneTheLength = 201;
        var tooLongType = new string('a', exceedingByOneTheLength);

        Action updatePlatform = () => platform.Update(tooLongType);

        updatePlatform.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdatePlatformWithEmptyTypeShouldFail()
    {
        var platform = new Platform("PC");

        Action updatePlatform = () => platform.Update(string.Empty);

        updatePlatform.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdatePlatformWithNullTypeShouldFail()
    {
        var platform = new Platform("PC");

        Action updatePlatform = () => platform.Update(null);

        updatePlatform.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdatePlatformWithValidTypeShouldSucceed()
    {
        var platform = new Platform("PC");
        var newValidType = "Console";

        platform.Update(newValidType);

        platform.Type.Should().Be(newValidType);
    }
}
