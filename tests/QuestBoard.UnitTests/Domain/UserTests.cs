using System;
using QuestBoard.Domain;
using QuestBoard.UnitTests.Mocks;
using Xunit;

namespace QuestBoard.UnitTests.Domain;

public class UserTests
{
    private readonly MockDateTimeProvider _dateTimeProvider;
    public UserTests()
    {
        _dateTimeProvider = new MockDateTimeProvider();
    }

    [Fact]
    public void GivenParameters_ShouldReturnAUserWithGivenParameters()
    {
        //Arrange
        string sutId = Guid.NewGuid().ToString();
        string sutName = "Name";
        string sutEmail = "user@email.com";
        DateTime sutCreatedAt = _dateTimeProvider.Now;
        //Act
        var actual = User.Factory.Create(sutId, sutName, sutEmail, sutCreatedAt);

        //Assert
        Assert.Equal(sutId, actual.Id);
        Assert.Equal(sutName, actual.Name);
        Assert.Equal(sutEmail, actual.Email);
        Assert.Equal(sutCreatedAt, actual.CreatedAt);
    }
}
