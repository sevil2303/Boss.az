using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    public class WriteAllText
    {
        public void WriteToText(string text)
        {
            string newFolder = "files";
            string path = System.IO.Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newFolder
            );
            string mypath = path + "\\newtxt.txt";
            if (!System.IO.Directory.Exists(path))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (IOException ie)
                {
                    Console.WriteLine("IO Error: " + ie.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("General Error: " + e.Message);
                }
            }
            if (!File.Exists(mypath))
            {
                string createText = "" + Environment.NewLine;
                File.WriteAllText(mypath, createText);
            }
            string appendText = text + Environment.NewLine;
            File.AppendAllText(mypath, appendText);
        }
    }
}
