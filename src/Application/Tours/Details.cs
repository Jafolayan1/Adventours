using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tours
{
    public class Details
    {
        public class Query : IRequest<Result<Tour>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Tour>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Tour>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tour = await _context.Tours.FindAsync(request.Id);

                return Result<Tour>.Success(tour);
            }
        }
    }
}