using BowlingApp.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BowlingApp.Commands
{
    public class GetScoreCommand : IRequest<ScoreResponse>
    {
        public List<PinsDown> _scores { get; }
        
        public GetScoreCommand(List<PinsDown> scores)
        {
            _scores = scores;
        }
    }

    public class GetScoreCommandHandler : IRequestHandler<GetScoreCommand, ScoreResponse>
    {
        private readonly ILogger<GetScoreCommandHandler> _logger;

        public GetScoreCommandHandler(ILogger<GetScoreCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<ScoreResponse> Handle(GetScoreCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Request Received", command._scores.Count);

            var data = new ScoreResponse
            {
                FrameProgressScores = command._scores,
                GameCompleted = true
            };

            return command?._scores.Count > 0 ? data : null;
        }
    }

}
