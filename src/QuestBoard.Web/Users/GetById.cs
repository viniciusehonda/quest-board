using FastEndpoints;
using MediatR;
using QuestBoard.UseCases;

namespace QuestBoard.Web.Users;

public class GetById(IMediator _mediator) : Endpoint<GetUserByIdRequest, UserRecord>
{
  public override void Configure()
  {
    Get(GetUserByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetUserByIdRequest request,
  CancellationToken cancellationToken)
  {
    var command = new GetUserQuery(request.UserId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == Ardalis.Result.ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new UserRecord(result.Value.id,
       result.Value.FirstName, result.Value.LastName, result.Value.Email);
    }
  }
}
