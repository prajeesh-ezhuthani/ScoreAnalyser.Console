using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ScoreAnalyser.Model
{
    public class ScoresListModel
    {
        public ScoresListModel()
        {
            ScoreList = new List<ScoreModel>();
        }
        public List<ScoreModel> ScoreList { get; set; }
    }
}
