using Microsoft.EntityFrameworkCore;
using QuestBoard.Core;
using Xunit;

namespace QuestBoard.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a User
    var testName = "name";
    var testLastName = "Lastname";
    var testEmail = "email@email.com";

    var repository = GetRepository();
    var User = new User(testName, testLastName, testEmail);
    var newGuid = Guid.NewGuid();
    User.Id = newGuid;

    await repository.AddAsync(User);

    // detach the item so we get a different instance
    _dbContext.Entry(User).State = EntityState.Detached;

    // fetch the item and update its title
    var newUser = (await repository.ListAsync())
        .FirstOrDefault(Contributor => Contributor.FirstName == testName);
    if (newUser == null)
    {
      Assert.NotNull(newUser);
      return;
    }
    Assert.NotSame(User, newUser);
    var newName = Guid.NewGuid().ToString();
    newUser.UpdateFirstName(newName);

    // Update the item
    await repository.UpdateAsync(newUser);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(Contributor => Contributor.FirstName == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(User.FirstName, updatedItem?.FirstName);
    Assert.Equal(User.Email, updatedItem?.Email);
    Assert.Equal(newUser.Id, updatedItem?.Id);
  }
}
