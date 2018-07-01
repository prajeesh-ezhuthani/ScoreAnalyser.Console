using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreAnalyser.Model;
using ScoreAnalyser.Services.Interface;


namespace ScoreAnalser.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScoreAnalyserService scoreAnalyserService;
        //inject the dependant service as parameter depensancy
        public HomeController(IScoreAnalyserService _scoreAnalyserService)
        {
            scoreAnalyserService = _scoreAnalyserService;
        }
        public ActionResult Index()
        {
            string filepth = Server.MapPath(@"~/"+Heplers.FileManager.FilePath);
            string infoMessage = string.Empty;
            if (Heplers.FileManager.ValidateFile(filepth))
            {
                string fileContent = Heplers.FileManager.ReadCSVFile(filepth);
                string TeamName = scoreAnalyserService.TeamWithSmallestGoalDifferecence(fileContent);
                var model = scoreAnalyserService.GetPointsTable(fileContent);
                ViewBag.TeamName = TeamName.Substring(TeamName.IndexOf('.') + 1);
                ViewBag.OriginalTeamName = TeamName;
                return View(model);
            }
            else
            {
                infoMessage = "File doesnt exists";
                ViewBag.Information = infoMessage;
            }
                
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}