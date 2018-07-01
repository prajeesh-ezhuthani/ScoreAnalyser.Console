using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreAnalyser.Model
{
    public class ScoreModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int MatchesDrawn { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
        public int GoalDifference { get; set; }

    }
}
