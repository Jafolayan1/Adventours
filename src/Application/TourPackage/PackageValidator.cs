using Domain;
using FluentValidation;

namespace Application.TourPackage
{
    public class PackageValidator : AbstractValidator<Package>
    {
        public PackageValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Review).NotEmpty();
            RuleFor(x => x.Tour).NotEmpty();
        }
    }
}