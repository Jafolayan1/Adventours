using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TourPackage
{
    public class Details
    {
        public class Query : IRequest<Result<Package>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Package>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Package>> Handle(Query request, CancellationToken cancellationToken)
            {
                var package = await _context.Packages.FindAsync(request.Id);

                return Result<Package>.Success(package);
            }
        }
    }
}