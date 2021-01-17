using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LargePdf_console
{
    public class ImageToPdf
    {
        private const string ImagesToPdf = "Images to PDF";
        private static readonly string DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public ImageToPdf() { }

        public void ConvertImageToPdf()
        {
            Console.WriteLine(ImagesToPdf);
            Console.WriteLine("FolderSelect:");

            var filesInPath = FolderSelect();
            if (filesInPath == null)
            {
                Console.WriteLine("No files found in the given directory.");
                return;
            }
            Document doc = new Document();
            Page page = doc.Pages.Add();


            Console.WriteLine();
            foreach (var file in filesInPath)
            {
                Image image = new Image
                {
                    File = file
                };
                page.PageInfo = Pages.A4;
                page.Paragraphs.Add(image);
            }
            var DirectoryName = Path.GetDirectoryName(filesInPath.FirstOrDefault());
            var FileName = Path.GetFileName(DirectoryName);
            doc.Save($"{DirectoryName}\\{FileName}.pdf"); 
            Process.Start("explorer.exe", DirectoryName);
        }

        private IEnumerable<string> FolderSelect()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                SelectedPath = Program.SelectedDirectory ?? DefaultDirectory
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                List<string> filePaths = new List<string>();
                foreach (var path in Directory.GetFiles(fbd.SelectedPath))
                {
                    filePaths.Add(path);
                }
                Program.SelectedDirectory = fbd.SelectedPath;
                return filePaths;
            }
            return null;
        }
    }
}
