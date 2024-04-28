using Ardalis.Result;
using Ardalis.SharedKernel;
using QuestBoard.Core.ContributorAggregate;

namespace QuestBoard.UseCases.Contributors.Create;

public class CreateContributorHandler(IRepository<Contributor> _repository)
  : ICommandHandler<CreateContributorCommand, Result<Guid>>
{
  public async Task<Result<Guid>> Handle(CreateContributorCommand request,
    CancellationToken cancellationToken)
  {
    var newContributor = new Contributor(request.Name, request.Email);
    if (!string.IsNullOrEmpty(request.PhoneNumber))
    {
      newContributor.SetPhoneNumber(request.PhoneNumber);
    }
    var createdItem = await _repository.AddAsync(newContributor, cancellationToken);

    return createdItem.Id;
  }
}
