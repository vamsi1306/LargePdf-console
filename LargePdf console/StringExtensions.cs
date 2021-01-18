using System.IO;

namespace LargePdf_console
{
    public static class StringExtensions
    {

        public static string CurrentDirectory
        {
            get
            {
                return Program.CurrentDirectory;
            }
            set
            {
                Program.CurrentDirectory = value;
            }
        }


        public static string GetFileName(string value)
        {
            if (Path.GetExtension(value).Equals(string.Empty))
                return Path.GetFileName(value).ExtensionAsPdf();
            return Path.GetFileNameWithoutExtension(value).ExtensionAsPdf();
        }

        public static string CreatePdfSaveDirectory(string fileName) => $"{Program.CurrentDirectory}\\{fileName}";

        static string ExtensionAsPdf(this string name) => $"{name}.pdf";

        public static string GetCurrentDirectory() => Program.CurrentDirectory;

        public static void SetCurrentDirectory(string newDirectory) => Program.CurrentDirectory = newDirectory;
    }
}
