using System;
using QuestBoard.Domain.DTO;

namespace QuestBoard.Domain.Interfaces;

public interface IQuestRepository
{
    Task AddAsync(Quest quest);
    Task<QuestDTO?> GetQuestByIdAsync(Guid id);
    Task<IEnumerable<QuestDTO>> GetPublisherQuestsAsync(string publisherId);
}
