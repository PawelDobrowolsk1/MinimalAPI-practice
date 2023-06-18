using FluentValidation;

namespace MinimalAPI;
public class ToDoValidator : AbstractValidator<ToDo>
{
    public ToDoValidator()
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        RuleFor(x => x.Value)
            .NotEmpty()
            .MinimumLength(5)
            .WithMessage("Value of a todo must be at least 5 characters");
    }
}
