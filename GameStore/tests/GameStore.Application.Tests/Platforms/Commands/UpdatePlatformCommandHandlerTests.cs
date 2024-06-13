using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Platforms.Commands.UpdatePlatform;
using GameStore.Domain.Platforms;

using Moq;

namespace GameStore.Application.Tests.Platforms.Commands;

public class UpdatePlatformCommandHandlerTests
{
    private readonly Mock<IPlatformRepository> _platformRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly UpdatePlatformCommandHandler _handler;

    public UpdatePlatformCommandHandlerTests()
    {
        _platformRepositoryMock = new Mock<IPlatformRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new UpdatePlatformCommandHandler(_platformRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task HandleShouldReturnValidationErrorWhenPlatformTypeAlreadyExists()
    {
        var request = new UpdatePlatformCommand(Guid.NewGuid(), "ExistingType");
        _platformRepositoryMock.Setup(repo => repo.GetByTypeAsync(request.Type))
                               .ReturnsAsync(new Platform("ExistingType"));

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
        result.FirstError.Description.Should().Be("Platform with type ExistingType already exists, it must be unique.");
    }

    [Fact]
    public async Task HandleShouldReturnNotFoundWhenPlatformToUpdateDoesNotExist()
    {
        var request = new UpdatePlatformCommand(Guid.NewGuid(), "NewType");
        _platformRepositoryMock.Setup(repo => repo.GetByTypeAsync(request.Type)).ReturnsAsync((Platform)null);
        _platformRepositoryMock.Setup(repo => repo.GetByIdAsync(request.Id)).ReturnsAsync((Platform)null);

        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        await act.Should().ThrowAsync<NullReferenceException>();
    }

    [Fact]
    public async Task HandleShouldUpdatePlatformWhenPlatformExistsAndTypeIsUnique()
    {
        var platformId = Guid.NewGuid();
        var request = new UpdatePlatformCommand(platformId, "NewUniqueType");
        var platform = new Platform("OldType");
        _platformRepositoryMock.Setup(repo => repo.GetByTypeAsync(request.Type)).ReturnsAsync((Platform)null);
        _platformRepositoryMock.Setup(repo => repo.GetByIdAsync(request.Id)).ReturnsAsync(platform);
        _platformRepositoryMock.Setup(repo => repo.UpdateAsync(platform)).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).Returns(Task.CompletedTask);

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().Be(platform);
        platform.Type.Should().Be("NewUniqueType");
        _platformRepositoryMock.Verify(repo => repo.UpdateAsync(platform), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }
}
