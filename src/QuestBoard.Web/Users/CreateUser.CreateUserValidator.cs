using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;
using QuestBoard.Infrastructure.Data.Config;
using QuestBoard.Web.Users;

namespace QuestBoard.Web.Users;

public class CreateUserValidator : Validator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
        .NotEmpty()
        .WithMessage("First Name is required.")
        .MinimumLength(2)
        .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

        RuleFor(x => x.LastName)
        .NotEmpty()
        .WithMessage("Last Name is required.")
        .MinimumLength(2)
        .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

        RuleFor(x => x.Email)
        .NotEmpty()
        .WithMessage("Email is required.")
        .MinimumLength(2)
        .MaximumLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH);

        RuleFor(x => x.Password)
        .NotEmpty()
        .WithMessage("Password is required.")
        .MinimumLength(2);
    }
}
