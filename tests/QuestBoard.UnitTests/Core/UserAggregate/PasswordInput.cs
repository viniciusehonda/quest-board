using QuestBoard.Core;
using Xunit;

namespace QuestBoard.UnitTests;

public class PasswordInput
{
    public PasswordInput()
    {
        
    }
    
    [Fact]
    public void PasswordHashShouldGenerateHashAndSalt()
    {
        string testInput = "!password$";
        Password password = new Password("", "");
        password.HashPassword(testInput);

        Assert.NotEmpty(password.PasswordHash);
        Assert.NotEmpty(password.PasswordSalt);
    }

  [Fact]
  public void InputPasswordShouldVerifyIfPasswordIsValid()
  {
    string correctInput = "!password$";
    string wrongInput = "abcd132";
    Password password = new Password("YCVVyNVpajOx2PKPHI3onBwnFP1enEHLI5h/ZWWkrfI=", "0aB364CX3nqe5H3O0Y4GUg==");

    Assert.False(password.Verify(wrongInput));
    Assert.True(password.Verify(correctInput));
  }
}
