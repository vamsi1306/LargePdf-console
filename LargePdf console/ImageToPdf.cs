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
        //private static readonly string DefaultDirectory = Program.CurrentDirectory ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string PdfFileName;

        public ImageToPdf() { }

        public bool ConvertImageToPdf()
        {
            Console.WriteLine(ImagesToPdf);
            Console.WriteLine("FolderSelect:");

            Console.WriteLine("1. File to PDF(Select a file.)");
            Console.WriteLine("2. Files to PDF(Select a folder.)");

            IEnumerable<string> filesInPath;
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    filesInPath = FileSelect();
                    break;
                case '2':
                    filesInPath = FolderSelect();
                    break;
                default:
                    return true;
            }

            if (filesInPath == null)
            {
                Console.WriteLine("No files found in the given directory.");
                return false;
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
            doc.Save(StringExtensions.CreatePdfSaveDirectory(PdfFileName)); 
            Process.Start("explorer.exe", StringExtensions.CurrentDirectory);
            return true;
        }

        private IEnumerable<string> FileSelect()
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                InitialDirectory = StringExtensions.CurrentDirectory,
                Title = "Open an image",
                DefaultExt = "jpg",
                Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*",
                FilterIndex = 2,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> filePaths = new List<string>();
                foreach (var path in fileDialog.FileNames)
                {
                    filePaths.Add(path);
                }
                Console.WriteLine("Select file name from the selected file name?(Y). Recomended: If you have multiple files selected, enter a file name");
                if (Program.IsYes(Console.ReadKey().KeyChar))
                    PdfFileName = StringExtensions.GetFileName(fileDialog.FileNames.FirstOrDefault());
                else
                    PdfFileName = StringExtensions.GetFileName(Console.ReadLine());
                StringExtensions.SetCurrentDirectory(Path.GetDirectoryName(fileDialog.FileNames.FirstOrDefault()));
                return filePaths;
            }
            return null;

        }

        private IEnumerable<string> FolderSelect()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                SelectedPath = StringExtensions.CurrentDirectory
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                List<string> filePaths = new List<string>();
                foreach (var path in Directory.GetFiles(fbd.SelectedPath))
                {
                    filePaths.Add(path);
                }
                StringExtensions.SetCurrentDirectory(fbd.SelectedPath);
                PdfFileName = StringExtensions.GetFileName(fbd.SelectedPath);
                return filePaths;
            }
            return null;
        }

        
    }
}
