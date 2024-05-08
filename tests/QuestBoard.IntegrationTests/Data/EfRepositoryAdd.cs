using QuestBoard.Core;
using QuestBoard.Core.ContributorAggregate;
using Xunit;

namespace QuestBoard.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsContributorAndSetsId()
  {
    var testName = "name";
    var testLastName = "Lastname";
    var testEmail = "email@email.com";

    var repository = GetRepository();
    var User = new User(testName, testLastName, testEmail);

    await repository.AddAsync(User);

    var newUser = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(testName, newUser?.FirstName);
    Assert.Equal(testLastName, newUser?.LastName);
    Assert.Equal(testEmail, newUser?.Email);
    Assert.NotEqual(newUser?.Id, Guid.Empty);
  }
}
