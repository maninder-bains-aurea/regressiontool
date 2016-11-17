using System.IO;

namespace RegressionUI.Common
{
    public static class Utilities
    {
        public static string ReadFileContent(string fileNameWithPath)
        {
            string content = string.Empty;
            string filepath = string.Format(fileNameWithPath);

            if (File.Exists(filepath))
            {
                var reader = new StreamReader(File.OpenRead(filepath));

                while (!reader.EndOfStream)
                    content = reader.ReadToEnd();
            }

            return content;
        }
    }
}