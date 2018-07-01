using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ScoreAnalyser.Model;

namespace ScoreAnalyser.ConsoleApp
{
    class Program
    {
        public static string filePath = @"D:\Projects\ScoreAnalyser.Console\Football.csv";
        static void Main(string[] args)
        {
            ReadCSVFile();
            Console.ReadLine();
        }
        
        private static void ReadCSVFile()
        {
            //Read the contents of CSV file.
            string csvData = File.ReadAllText(filePath);
            ScoresListModel FinalscoresList = new ScoresListModel();
            bool HeaderRow = false;
            int rowIndex = 0;
            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
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

                 }).OrderBy(t => t.GoalDifference).First();

            Console.WriteLine("Team" + GoalDiffference.Team +"difference" + GoalDiffference.GoalDifference);
            Console.ReadLine();
        }
        private static bool ValidateColumn(string[] columnValues)
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
        private static void AssignColumnValues(string[] columnValues, ref ScoreModel scoreBoard)
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
