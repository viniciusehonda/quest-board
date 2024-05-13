using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;
using QuestBoard.Infrastructure.Data.Config;

namespace QuestBoard.Web.Users;

public class UpdateUserValidator : Validator<UpdateUserRequest>
{
    public UpdateUserValidator()
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
    }
}
