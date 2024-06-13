using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Platforms.Commands.DeletePlatform;
using GameStore.Domain.Platforms;

using Moq;

namespace GameStore.Application.Tests.Platforms.Commands;

public class DeletePlatformCommandHandlerTests
{
    private readonly Mock<IPlatformRepository> _mockPlatformRepository;
    private readonly Mock<IGameRepository> _mockGameRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly DeletePlatformCommandHandler _handler;

    public DeletePlatformCommandHandlerTests()
    {
        _mockPlatformRepository = new Mock<IPlatformRepository>();
        _mockGameRepository = new Mock<IGameRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new DeletePlatformCommandHandler(
            _mockPlatformRepository.Object,
            _mockGameRepository.Object,
            _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task WhenPlatformDoesNotExistShouldReturnNotFoundError()
    {
        var platformId = Guid.NewGuid();
        var command = new DeletePlatformCommand(platformId);

        _mockPlatformRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync((Platform)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.NotFound);

        _mockPlatformRepository.Verify(r => r.RemoveAsync(It.IsAny<Platform>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenPlatformIsUsedInGamesShouldReturnValidationError()
    {
        var platform = new Platform("Platform");
        var command = new DeletePlatformCommand(platform.Id);

        _mockPlatformRepository
            .Setup(r => r.GetByIdAsync(command.Id))
            .ReturnsAsync(platform);

        _mockGameRepository
            .Setup(r => r.HasGamesWithPlatformIdAsync(command.Id))
            .ReturnsAsync(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);

        _mockPlatformRepository.Verify(r => r.RemoveAsync(It.IsAny<Platform>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenPlatformCanBeDeletedShouldRemovePlatform()
    {
        var platform = new Platform("Platform");
        var command = new DeletePlatformCommand(platform.Id);

        _mockPlatformRepository
            .Setup(r => r.GetByIdAsync(command.Id))
            .ReturnsAsync(platform);

        _mockGameRepository
            .Setup(r => r.HasGamesWithPlatformIdAsync(command.Id))
            .ReturnsAsync(false);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();

        _mockPlatformRepository.Verify(r => r.RemoveAsync(platform), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
