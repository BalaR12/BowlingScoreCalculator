using BowlingApp.Contracts;
using System.Collections.Generic;

namespace BowlingApp.Services
{
    public interface ICalculateScoreServices
    {
        List<PinsDown> CalculateScore(List<PinsDown> scores);
    }
}
