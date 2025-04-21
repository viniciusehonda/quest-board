using QuestBoard.Domain;
using Xunit;

namespace QuestBoard.UnitTests.Domain;

public class QuestTests
{
    [Fact]
    public void GivenParameters_ShouldReturnAQuestWithGivenParameters()
    {
        //Arrange
        Guid sutId = Guid.NewGuid();
        string sutTitle = "New Quest";
        string sutDescription = "This is a new quest for the test";
        QuestDifficulty sutDifficulty = QuestDifficulty.Medium;
        string sutPublisherId = Guid.NewGuid().ToString();
        //Act
        var actual = Quest.Factory.Create(sutId,
         sutTitle,
          sutDescription,
           sutDifficulty,
            sutPublisherId);
        //Assert
        Assert.Equal(sutId, actual.Id);
        Assert.Equal(sutTitle, actual.Title);
        Assert.Equal(sutDescription, actual.Description);
        Assert.Equal(sutDifficulty, actual.Difficulty);
        Assert.Equal(sutPublisherId, actual.PublisherId);
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
            sutPublisherId);
        string sutUpdatedTitle = "Quest XYZ";
        string sutUpdatedDescription = "This is the epic quest XYZ";

        //Act
        sut.Update(sutUpdatedTitle, sutUpdatedDescription);

        //Assert
        Assert.Equal(sutUpdatedTitle, sut.Title);
        Assert.Equal(sutUpdatedDescription, sut.Description);
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
            sutPublisherId);
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
            sutPublisherId);
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
            sutPublisherId);
        var newStatus = QuestStatus.Cancelled;
        //Act
        sut.Cancel();
        //Assert
        Assert.Equal(newStatus, sut.Status);
    }
}