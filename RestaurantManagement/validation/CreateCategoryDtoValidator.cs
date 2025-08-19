using FluentValidation;
using RestaurantManagement.Models.Dtos;

namespace RestaurantManagement.validation
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateEmailWithMilkitDto>
    {
        public CreateCategoryDtoValidator()
        {
           
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(10).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.dishids)
                .NotEmpty().WithMessage("At least one dish ID is required.")
                .Must(dishIds => dishIds.All(id => id > 0)).WithMessage("Dish IDs must be positive integers.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User ID must be a positive integer.");
        }

    }
}
