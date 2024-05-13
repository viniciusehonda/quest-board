using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;

namespace QuestBoard.Web.Users;

public class GetUserValidator : Validator<GetUserByIdRequest>
{
    public GetUserValidator()
    {
        RuleFor(x => x.UserId)
        .NotNull();
    }
}
