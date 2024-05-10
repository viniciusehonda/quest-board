﻿using Ardalis.Result;
using Ardalis.SharedKernel;
using QuestBoard.Core;

namespace QuestBoard.UseCases;

public class CreateUserHandler(IRepository<User> _repository)
  : ICommandHandler<CreateUserCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(CreateUserCommand request,
    CancellationToken cancellationToken)
  {
    var newUser = new User(request.FirstName, request.LastName, request.Email);
    if (!string.IsNullOrEmpty(request.Password))
    {
      newUser.UpdatePassword(request.Password);
    }
    var createdItem = await _repository.AddAsync(newUser, cancellationToken);

    return createdItem.Id;
  }
}