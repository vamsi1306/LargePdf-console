using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargePdf_console
{
    class Program
    {
        private const string ImagesToPdf = "Images to PDF";
        private const string DefaultDirectory = ""; //TODO: Need to decide on a directory name, no need to enter the path every time. 
        private static string EnterTheNewDirectory = "Enter the new directory: ";

        // Also, should give an option to change the default directory. Use a json file for storing the data/ settings.


        static void Main(string[] args)
        {
            Console.WriteLine(ImagesToPdf);
            Console.WriteLine($"The default path is {DefaultDirectory}. Want to change the default one: (Y)");
            var ChangeDirectory = Console.ReadKey().KeyChar;
            if (Equals(ChangeDirectory, 'Y') || Equals(ChangeDirectory, 'y'))
            {
                Console.WriteLine(EnterTheNewDirectory);
                EnterTheNewDirectory = Console.ReadLine();
            }

            
        }
    }
}
