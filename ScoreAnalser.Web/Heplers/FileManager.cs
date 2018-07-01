using System.IO;
using Common;
namespace ScoreAnalser.Web.Heplers
{
    public static class FileManager
    {
        public static string FilePath
        {
            get
            {
                return Common.ConfigSettingsReader.GetConfigurationValues(Constants.FilePath);
            }
        }

        public static string ReadCSVFile(string filepath)
        {
            string fileContent = string.Empty;
            if (File.Exists(filepath))
            {
                fileContent = File.ReadAllText(filepath);
            }
            else
                fileContent = "File does not exists";
            return fileContent;
        }
        public static bool ValidateFile(string filepath)
        {
            return File.Exists(filepath);
        }
    }
}