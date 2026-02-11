


using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace ProjectUtilityPaths
{
    public static class Paths
    {

        public static string DataXLSXPath(string XLName)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string localfilePath = Path.Combine(projectRoot, "Resources/TestData", $"{XLName}");

            return localfilePath;
        }

        public static string JSONConfigPath(string JsonName)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string localfilePath = Path.Combine(projectRoot, "Resources/Config", $"{JsonName}");

            return localfilePath;
        }

        public static string LoggerPath(string LogName)
        {
            string projectName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty;
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string localfilePath = Path.Combine(projectRoot, "Logs", $"{projectName}_{LogName}");

            return localfilePath;
        }


    }
}
