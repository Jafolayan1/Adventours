using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TourPackage
{
    public class List
    {
        public class Query : IRequest<Result<List<Package>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Package>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Package>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Package>>.Success(await _context.Packages.ToListAsync(cancellationToken));
            }
        }
    }
}