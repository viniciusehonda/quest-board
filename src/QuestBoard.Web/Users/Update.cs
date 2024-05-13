using FastEndpoints;
using MediatR;
using QuestBoard.UseCases;

namespace QuestBoard.Web.Users;

public class Update(IMediator _mediator)
    : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
    public override void Configure()
    {
        Put(UpdateUserRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateUserRequest request,
     CancellationToken cancellationToken)
    {
        Ardalis.Result.Result<UserDTO> result = await _mediator.Send(new UpdateUserCommand(request.Id, request.FirstName!, request.LastName!, request.Email!), cancellationToken);

        if (result.Status == Ardalis.Result.ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var query = new GetUserQuery(request.UserId);

        Ardalis.Result.Result<UserDTO> queryResult = await _mediator.Send(query, cancellationToken);

        if (queryResult.Status == Ardalis.Result.ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (queryResult.IsSuccess)
        {
            var dto = queryResult.Value;
            Response = new UpdateUserResponse(new UserRecord(dto.id, dto.FirstName, dto.LastName, dto.Email));
            return;
        }
    }
}
