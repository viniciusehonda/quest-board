using System.Windows.Input;
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace QuestBoard.UseCases;

public record UpdateUserCommand(Guid userId, string newFirstName, string newLastName, string newEmail) : ICommand<Result<UserDTO>>;
