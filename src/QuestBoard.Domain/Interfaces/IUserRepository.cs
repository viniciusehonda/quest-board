using System;
using QuestBoard.Domain.DTO;

namespace QuestBoard.Domain.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<UserDTO?> GetUserByIdAsync(string id);
}
