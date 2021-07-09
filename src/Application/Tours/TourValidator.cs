using Domain;
using FluentValidation;

namespace Application.Tours
{
    public class TourValidator : AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(x => x.TourCenterName).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.DateAdded).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.PackageId).NotEmpty();
        }
    }
}