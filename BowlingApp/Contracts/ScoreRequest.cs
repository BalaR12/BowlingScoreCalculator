using System.Collections.Generic;

namespace BowlingApp.Contracts
{
    public class ScoreRequest
    {
        public IEnumerable<PinsDown> PinsDown { get; set; }
    }
}
