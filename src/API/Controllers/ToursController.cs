using Application.Tours;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class ToursController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetTours()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTour(Guid id)

        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTour(Tour tour)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Tour = tour }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTour(Guid id, Tour tour)
        {
            tour.TourId = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Tour = tour }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}