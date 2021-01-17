using System;

namespace LargePdf_console
{
    public class Program
    {
        public static string SelectedDirectory;

        [STAThread]
        public static void Main(string[] args)
        {
            do
            {
                ImageToPdf converter = new ImageToPdf();
                converter.ConvertImageToPdf();
            } while (ShouldContinue());
        }

        private static bool ShouldContinue()
        {
            Console.Clear();
            Console.WriteLine("\nWant to convert another pdf. (Y)");
            return IsYes(Console.ReadKey().KeyChar);
        }

        private static bool IsYes(char value) => value == 'Y' || value == 'y';

    }
}
