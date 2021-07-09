using Application.TourPackage;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class PackagesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPackages()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackages(Guid id)

        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage(Package package)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Package = package }));
        }
    }
}