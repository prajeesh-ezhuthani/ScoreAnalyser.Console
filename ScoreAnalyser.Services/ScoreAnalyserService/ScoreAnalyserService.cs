using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreAnalyser.Model;
using ScoreAnalyser.Services.Interface;
namespace ScoreAnalyser.Services
{
    public class ScoreAnalyserService : IScoreAnalyserService
    {
        public ScoreAnalyserService()
            {
            }
        public string TeamWithSmallestGoalDifferecence(string fileContent)
        {
            int rowIndex = 0;
            ScoresListModel FinalscoresList = new ScoresListModel();
            foreach (string row in fileContent.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    ScoreModel scoreBoard = new ScoreModel();
                    string[] columnValues = row.Split(',');

                    if (rowIndex == 0)
                    {
                        ValidateColumn(columnValues);
                    }
                    else
                    {
                        AssignColumnValues(columnValues, ref scoreBoard);
                        FinalscoresList.ScoreList.Add(scoreBoard);
                    }

                    rowIndex++; //Increment the row count
                }
            }
            var GoalDiffference = FinalscoresList.ScoreList
                 .Select(t => new
                 {
                     Team = t.TeamName,
                     GoalDifference = t.GoalsFor - t.GoalsAgainst

                 }).OrderBy(t => t.GoalDifference)
                 .Where(team=> team.GoalDifference > 0)
                 .First();

            return GoalDiffference.Team;

        }
        /// <summary>
        /// Construct the data model based on the entries in the CSV file
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
       
        public ScoresListModel GetPointsTable(string fileContent)
        {
            int rowIndex = 0;
            ScoresListModel FinalscoresList = new ScoresListModel();
            foreach (string row in fileContent.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    ScoreModel scoreBoard = new ScoreModel();
                    string[] columnValues = row.Split(',');

                    if (rowIndex == 0)
                    {
                        ValidateColumn(columnValues);
                    }
                    else
                    {
                        AssignColumnValues(columnValues, ref scoreBoard);
                        FinalscoresList.ScoreList.Add(scoreBoard);
                    }

                    rowIndex++; //Increment the row count
                }
            }

            return FinalscoresList;

        }
        private bool ValidateColumn(string[] columnValues)
        {
            bool isValid = false;
            //If number columns are not 9 then the csv file is invalid.
            if (columnValues.Count() != 9)
                return false;
            else if (string.IsNullOrEmpty(columnValues[0]))
                return false;
            else
                isValid = true;
            return isValid;

        }
        private  void AssignColumnValues(string[] columnValues, ref ScoreModel scoreBoard)
        {
            scoreBoard.TeamName = columnValues[0];
            if (!scoreBoard.TeamName.StartsWith("--"))
            {
                scoreBoard.MatchesPlayed = string.IsNullOrEmpty(columnValues[1]) ? 0 : Convert.ToInt32(columnValues[1]);
                scoreBoard.MatchesWon = string.IsNullOrEmpty(columnValues[2]) ? 0 : Convert.ToInt32(columnValues[2]);
                scoreBoard.MatchesLost = string.IsNullOrEmpty(columnValues[3]) ? 0 : Convert.ToInt32(columnValues[3]);
                scoreBoard.MatchesDrawn = string.IsNullOrEmpty(columnValues[4]) ? 0 : Convert.ToInt32(columnValues[4]);
                scoreBoard.GoalsFor = string.IsNullOrEmpty(columnValues[5]) ? 0 : Convert.ToInt32(columnValues[5]);
                scoreBoard.GoalsAgainst = string.IsNullOrEmpty(columnValues[7]) ? 0 : Convert.ToInt32(columnValues[7]);
                scoreBoard.Points = string.IsNullOrEmpty(columnValues[8]) ? 0 : Convert.ToInt32(columnValues[8]);
                scoreBoard.GoalDifference = scoreBoard.GoalsFor - scoreBoard.GoalsAgainst;
            }

        }
    }
}
