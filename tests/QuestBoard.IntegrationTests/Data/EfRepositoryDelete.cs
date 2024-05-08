using QuestBoard.Core;
using Xunit;

namespace QuestBoard.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    var testName = "name";
    var testLastName = "Lastname";
    var testEmail = "email@email.com";

    var repository = GetRepository();
    var User = new User(testName, testLastName, testEmail);
    var newGuid = Guid.NewGuid();
    User.Id = newGuid;

    await repository.AddAsync(User);

    // delete the item
    await repository.DeleteAsync(User);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        Contributor => Contributor.Id == newGuid);
  }
}
