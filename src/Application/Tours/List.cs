using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tours
{
    public class List
    {
        public class Query : IRequest<Result<List<Tour>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Tour>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Tour>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Tour>>.Success(await _context.Tours.ToListAsync(cancellationToken));
            }
        }
    }
}