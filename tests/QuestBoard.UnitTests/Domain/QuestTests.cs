using QuestBoard.Domain;
using QuestBoard.UnitTests.Mocks;
using Xunit;

namespace QuestBoard.UnitTests.Domain;

public class QuestTests
{
    private readonly MockDateTimeProvider _dateTimeProvider;
    public QuestTests()
    {
        _dateTimeProvider = new MockDateTimeProvider();
    }

    [Fact]
    public void GivenParameters_ShouldReturnAQuestWithGivenParameters()
    {
        //Arrange
        Guid sutId = Guid.NewGuid();
        string sutTitle = "New Quest";
        string sutDescription = "This is a new quest for the test";
        QuestDifficulty sutDifficulty = QuestDifficulty.Medium;
        string sutPublisherId = Guid.NewGuid().ToString();
        DateTime sutCreatedAt = _dateTimeProvider.Now;
        //Act
        var actual = Quest.Factory.Create(sutId,
         sutTitle,
          sutDescription,
           sutDifficulty,
            sutPublisherId,
            sutCreatedAt);
        //Assert
        Assert.Equal(sutId, actual.Id);
        Assert.Equal(sutTitle, actual.Title);
        Assert.Equal(sutDescription, actual.Description);
        Assert.Equal(sutDifficulty, actual.Difficulty);
        Assert.Equal(sutPublisherId, actual.PublisherId);
        Assert.Equal(sutCreatedAt, actual.CreatedAt);
    }

    [Fact]
    public void GivenParameters_ShouldReturnUpdatedQuest()
    {
        //Arrange
        Guid sutId = Guid.NewGuid();
        string sutTitle = "New Quest";
        string sutDescription = "This is a new quest for the test";
        QuestDifficulty sutDifficulty = QuestDifficulty.Medium;
        string sutPublisherId = Guid.NewGuid().ToString();
        var sut = Quest.Factory.Create(sutId,
         sutTitle,
          sutDescription,
           sutDifficulty,
            sutPublisherId,
            _dateTimeProvider.Now);
        string sutUpdatedTitle = "Quest XYZ";
        string sutUpdatedDescription = "This is the epic quest XYZ";
        DateTime sutUpdatedAt = DateTime.Now;

        //Act
        sut.Update(sutUpdatedTitle, sutUpdatedDescription, sutUpdatedAt);

        //Assert
        Assert.Equal(sutUpdatedTitle, sut.Title);
        Assert.Equal(sutUpdatedDescription, sut.Description);
        Assert.Equal(sutUpdatedAt, sut.UpdatedAt);
    }

    [Fact]
    public void QuestPublish_ShouldChangeStatusToPublished()
    {
        //Arrange
        Guid sutId = Guid.NewGuid();
        string sutTitle = "New Quest";
        string sutDescription = "This is a new quest for the test";
        QuestDifficulty sutDifficulty = QuestDifficulty.Medium;
        string sutPublisherId = Guid.NewGuid().ToString();
        var sut = Quest.Factory.Create(sutId,
         sutTitle,
          sutDescription,
           sutDifficulty,
            sutPublisherId,
            _dateTimeProvider.Now);
        var newStatus = QuestStatus.Published;
        //Act
        sut.Publish();
        //Assert
        Assert.Equal(newStatus, sut.Status);
    }

    [Fact]
    public void QuestFinish_ShouldChangeStatusToFinished()
    {
        //Arrange
        Guid sutId = Guid.NewGuid();
        string sutTitle = "New Quest";
        string sutDescription = "This is a new quest for the test";
        QuestDifficulty sutDifficulty = QuestDifficulty.Medium;
        string sutPublisherId = Guid.NewGuid().ToString();
        var sut = Quest.Factory.Create(sutId,
         sutTitle,
          sutDescription,
           sutDifficulty,
            sutPublisherId,
            _dateTimeProvider.Now);
        var newStatus = QuestStatus.Finished;
        //Act
        sut.Finish();
        //Assert
        Assert.Equal(newStatus, sut.Status);
    }

    [Fact]
    public void QuestCancel_ShouldChangeStatusToCancelled()
    {
        //Arrange
        Guid sutId = Guid.NewGuid();
        string sutTitle = "New Quest";
        string sutDescription = "This is a new quest for the test";
        QuestDifficulty sutDifficulty = QuestDifficulty.Medium;
        string sutPublisherId = Guid.NewGuid().ToString();
        var sut = Quest.Factory.Create(sutId,
         sutTitle,
          sutDescription,
           sutDifficulty,
            sutPublisherId,
            _dateTimeProvider.Now);
        var newStatus = QuestStatus.Cancelled;
        //Act
        sut.Cancel();
        //Assert
        Assert.Equal(newStatus, sut.Status);
    }
}