using BowlingApp.Contracts;
using System;
using System.Collections.Generic;

namespace BowlingApp.Services
{
    public class CalculateScoreServices : ICalculateScoreServices
    {
        public int position = 0; // Position of the cursor 1 to n
        public int round = 1; // If score is 10, then round is 1
        public int TotalScore = 0; // Position of the game 1 to 10
        
        public List<PinsDown> CalculateScore(List<PinsDown> scores)
        {
            try
            {
                List<PinsDown> result = new();

                foreach (var scr in scores)
                {
                    position++;
                    if (position == scores.Count && scr.PinScore == 10)
                    {
                        round = 0;
                    }
                    else
                    if (position != scores.Count && scr.PinScore == 10)
                    {
                        if (position == 1)
                        {
                            TotalScore += scr.PinScore * round;
                        }

                        if (round > 0 && position > 2)
                        {
                            if (round > 2) 
                                round = 2;

                            TotalScore += scr.PinScore* round;
                            result.RemoveAt(result.Count - round);
                            result.Insert(result.Count, new PinsDown { PinScore = TotalScore });
                        }

                        TotalScore += scr.PinScore;
                        result.Add(new PinsDown { PinScore = TotalScore });
                        
                        round++;
                    }
                    else
                    {
                        round = 0;
                        TotalScore += scr.PinScore;
                        result.Add(new PinsDown { PinScore = TotalScore });
                    }
                    
                }
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<PinsDown>();
            }
        }
    }
}
