using System;

namespace LargePdf_console
{
    public class Program
    {
        public static string CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        [STAThread]
        public static void Main(string[] args)
        {
            do
            {
                ImageToPdf converter = new ImageToPdf();
                if (!converter.ConvertImageToPdf())
                    return;
            } while (ShouldContinue());
        }

        private static bool ShouldContinue(bool? value = null)
        {
            Console.Clear();
            Console.WriteLine("\nWant to convert another pdf. (Y)");
            return value ?? IsYes(Console.ReadKey().KeyChar);
        }

        public static bool IsYes(char value) => value == 'Y' || value == 'y';

    }
}
