using System;
using System.Collections.Generic;

namespace BowlingApp.Contracts
{
    public record ScoreResponse
    {
        public List<PinsDown> FrameProgressScores { get; set; }
        
        public bool GameCompleted { get; set; }

        public void SetCompleted()
        {
            GameCompleted = true;
        }
    }
}
