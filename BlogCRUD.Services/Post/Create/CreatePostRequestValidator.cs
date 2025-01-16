using FluentValidation;

namespace BlogCRUD.Services.Post.Create
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {

        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .NotNull().WithMessage("Title field can not be null")
                .Length(5, 30).WithMessage("Title can not be more than 30 characters");


            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .NotNull().WithMessage("Content field can not be null")
                .Length(5, 500).WithMessage("Content can not be more than 500 characters");
        }
    }
}
