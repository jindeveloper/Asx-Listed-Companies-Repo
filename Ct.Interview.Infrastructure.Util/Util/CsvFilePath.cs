using System.Reflection;

namespace Ct.Interview.Infrastructure.Util
{
    public class CsvFilePath
    {
        private static string filePath = @"data/ASXListedCompanies.csv";
        private static string assemblyLocation = Assembly.GetExecutingAssembly().Location;

        public static string GetFilePath()
        {

            string assemblyDirectoryPath = Path.GetDirectoryName(assemblyLocation) ?? "";

            if (!Directory.Exists(assemblyDirectoryPath) || string.IsNullOrEmpty(assemblyDirectoryPath))
                throw new DirectoryNotFoundException(assemblyDirectoryPath);

            string fullPath = Path.Combine(assemblyDirectoryPath, filePath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException(assemblyDirectoryPath);

            return fullPath;
        }

    }
}
