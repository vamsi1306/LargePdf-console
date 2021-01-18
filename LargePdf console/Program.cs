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
                if (ShouldContinue(!converter.ConvertImageToPdf()))
                    return;
            } while (ShouldContinue());
        }

        private static bool ShouldContinue(bool? value = null)
        {
            Console.Clear();
            Console.WriteLine("\nWant to convert another pdf. (Y)");
            return value ?? IsYes(Console.ReadKey().KeyChar);
        }

        private static bool IsYes(char value) => value == 'Y' || value == 'y';

    }
}
