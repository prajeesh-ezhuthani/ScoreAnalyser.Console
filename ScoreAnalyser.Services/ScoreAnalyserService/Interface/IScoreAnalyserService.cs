using ScoreAnalyser.Model;
namespace ScoreAnalyser.Services.Interface
{
    public interface IScoreAnalyserService
    {
        string TeamWithSmallestGoalDifferecence(string fileContent);
        ScoresListModel GetPointsTable(string fileContent);
    }
}
