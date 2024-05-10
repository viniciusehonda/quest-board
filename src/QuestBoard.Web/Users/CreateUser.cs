using FastEndpoints;
using MediatR;
using QuestBoard.UseCases;

namespace QuestBoard.Web.Users;

public class CreateUser(IMediator _mediator) : Endpoint<CreateUserRequest, CreateUserResponse>
{
  public override void Configure()
  {
    Post(CreateUserRequest.Route);
    AllowAnonymous();
    Summary(s => {
        s.ExampleRequest = new CreateUserRequest { FirstName = "John", LastName = "Doe", Email = "john_doe@email.com" };
    });
  }

  public override async Task HandleAsync(
    CreateUserRequest request,
    CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateUserCommand(request.FirstName!,
         request.LastName!, request.Email!, request.Password!), cancellationToken);

         if (result.IsSuccess)
         {
            Response = new CreateUserResponse(result.Value, request.FirstName!, request.LastName!, request.Email!);
            return;
         }
    }
}
