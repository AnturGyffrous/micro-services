using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftApi.MediatRRequests;
using GiftApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GiftController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public Task<IActionResult> CreateNewGift()
        //{
        //    var response = Created("/api/gift/1", "Hello, World!");
        //    return Task.FromResult((IActionResult)response);
        //}

        public Task<Gift> GetGift(Guid id) => _mediator.Send(new GetGift { Id = id });
    }
}