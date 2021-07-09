using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;

using System.Threading.Tasks;

namespace Application.Tours
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Tour Tour { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Tour).SetValidator(new TourValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Tours.Add(request.Tour);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Tour");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}