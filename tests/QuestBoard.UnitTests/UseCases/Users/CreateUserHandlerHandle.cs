using Ardalis.SharedKernel;
using NSubstitute;
using QuestBoard.Core;
using QuestBoard.UseCases;
using Xunit;

namespace QuestBoard.UnitTests;

public class CreateUserHandlerHandle
{
    private readonly IRepository<User> _repository = Substitute.For<IRepository<User>>();
    private CreateUserHandler _handler;

    public CreateUserHandlerHandle()
    {
        _handler = new CreateUserHandler(_repository);
    }

    private User CreateUser()
    {
        return new User("John", "Doe", "john_doe@email.com");
    }

    [Fact]
    public async Task ReturnSuccessGivenUser()
    {
        _repository.AddAsync(Arg.Any<User>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(CreateUser()));
        var result = await _handler.Handle(new CreateUserCommand("John", "Doe", "john_doe@email.com", "testPassword"), CancellationToken.None);

        Assert.True(result.IsSuccess);
    }
}
