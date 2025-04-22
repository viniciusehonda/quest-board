using System;
using QuestBoard.Domain;
using QuestBoard.Domain.DTO;
using QuestBoard.Domain.Interfaces;
using QuestBoard.Infrastructure.Providers;

namespace QuestBoard.Application.Services;

public class QuestService
{
    private readonly IQuestRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public QuestService(IQuestRepository repository, IDateTimeProvider dateTimeProvider)
    {
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Quest> AddAync(QuestDTO user)
    {
        Quest domain = Quest.Factory.Create(user.Id, user.Title, user.Description, user.Difficulty, user.PublisherId, _dateTimeProvider.Now);
        await _repository.AddAsync(domain);
        return domain;
    }

    public async Task<QuestDTO?> GetQuestByIdAsync(Guid id)
    {
        return await _repository.GetQuestByIdAsync(id);
    }

    public async Task<IEnumerable<QuestDTO>> GetPublisherQuestsAsync(string publisherId)
    {
        return await _repository.GetPublisherQuestsAsync(publisherId);
    }
}
