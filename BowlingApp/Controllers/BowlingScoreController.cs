using BowlingApp.Commands;
using BowlingApp.Contracts;
using BowlingApp.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BowlingApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingScoreController : Controller
    {
        private readonly ILogger<BowlingScoreController> _logger;
        private readonly IMediator _mediator;
        private readonly ICalculateScoreServices _services;

        public BowlingScoreController(ILogger<BowlingScoreController> logger, 
            IMediator mediator, 
            ICalculateScoreServices services)
        {
            _logger = logger;
            _mediator = mediator;
            _services = services;
        }

        [HttpPost]
        [Route("ShowScoreCard")]
        public async Task<IActionResult> ShowScoreCard([FromBody] ScoreRequest request)
        {
            try
            {
                _logger.LogInformation("Retrieving Bowling Score", request);

                if (IsBadRequest(request))
                {
                    return BadRequest();
                }

                var requestValues = new List<PinsDown>();

                foreach (var s in request.PinsDown)
                {
                    requestValues.Add(s);
                }

                var data = _services.CalculateScore(requestValues);

                var command = new GetScoreCommand(data);

                var result = await _mediator.Send(command);

                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        private bool IsBadRequest(ScoreRequest request)
        {
            return (request.PinsDown.Count() > 12 || request?.PinsDown == null);
        }
    }
}
