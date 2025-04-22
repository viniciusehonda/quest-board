using System;
using QuestBoard.Domain;
using QuestBoard.Domain.DTO;
using QuestBoard.Domain.Interfaces;
using QuestBoard.Infrastructure.Providers;

namespace QuestBoard.Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UserService(IUserRepository repository, IDateTimeProvider dateTimeProvider)
    {
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task AddAsync(UserDTO user)
    {
        await _repository.AddAsync(User.Factory.Create(
            user.Id,
            user.Name,
            user.Email,
            _dateTimeProvider.Now
        ));
    }

    public async Task<UserDTO?> GetUserByIdAsync(string id)
    {
        return await _repository.GetUserByIdAsync(id);
    }
}
