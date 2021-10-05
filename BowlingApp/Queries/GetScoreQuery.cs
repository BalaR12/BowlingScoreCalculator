//using BowlingApp.Models;

//namespace BowlingApp.Queries
//{
//    public class GetScoreQuery //: IRequest<Response>
//    {
//        public ScoreRequest _scores { get; }

//        public GetScoreQuery(ScoreRequest scores)
//        {
//            _scores = scores;
//        }
//    }

//    public class GetScoreQueryHandler : IRequestHandler<GetScoreQuery, Response>
//    {
//        private readonly DBRepository _repository;
//        public GetScoreQueryHandler(DBRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<Response> Handle(GetScoreQuery request, CancellationToken cancellationToken)
//        {
//            var data = _repository.Score.FirstOrDefault(_ => _.GameId == request._gameId);
//            return data == null ? null : new Response(data.GameId);
//        }
//    }

//    public record Response(int gameid);
//}
