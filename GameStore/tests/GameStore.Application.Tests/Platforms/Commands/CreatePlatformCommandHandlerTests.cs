using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Platforms.Commands.CreatePlatform;
using GameStore.Domain.Platforms;

using Moq;

namespace GameStore.Application.Tests.Platforms.Commands;

public class CreatePlatformCommandHandlerTests
{
    private readonly Mock<IPlatformRepository> _platformRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly CreatePlatformCommandHandler _handler;

    public CreatePlatformCommandHandlerTests()
    {
        _platformRepositoryMock = new Mock<IPlatformRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new CreatePlatformCommandHandler(_platformRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task HandleShouldReturnValidationErrorWhenPlatformTypeAlreadyExists()
    {
        var request = new CreatePlatformCommand("ExistingType");
        _platformRepositoryMock
            .Setup(repo => repo.GetByTypeAsync(request.Type))
            .ReturnsAsync(new Platform("ExistingType"));

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task HandleShouldCreatePlatformWhenPlatformTypeIsUnique()
    {
        var uniqueType = "UniqueType";
        var request = new CreatePlatformCommand(uniqueType);
        _platformRepositoryMock
            .Setup(repo => repo.GetByTypeAsync(request.Type))
            .ReturnsAsync((Platform)null);

        _platformRepositoryMock
            .Setup(repo => repo.AddAsync(It.IsAny<Platform>()))
            .ReturnsAsync(new Platform(uniqueType));

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Type.Should().Be(uniqueType);
        _platformRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Platform>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }
}
