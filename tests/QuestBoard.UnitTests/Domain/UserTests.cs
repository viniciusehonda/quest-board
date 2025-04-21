using System;
using QuestBoard.Domain;
using Xunit;

namespace QuestBoard.UnitTests.Domain;

public class UserTests
{
    [Fact]
    public void GivenParameters_ShouldReturnAUserWithGivenParameters()
    {
        //Arrange
        string sutId = Guid.NewGuid().ToString();
        string sutName = "Name";
        string sutEmail = "user@email.com";

        //Act
        var actual = User.Factory.Create(sutId, sutName, sutEmail);

        //Assert
        Assert.Equal(sutId, actual.Id);
        Assert.Equal(sutName, actual.Name);
        Assert.Equal(sutEmail, actual.Email);
    }
}
