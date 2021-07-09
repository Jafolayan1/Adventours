using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tours
{
    public class Edit
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
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var tour = await _context.Tours.FindAsync(request.Tour.TourId);

                if (tour is null) return null;

                _mapper.Map(request.Tour, tour);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update the tour");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}