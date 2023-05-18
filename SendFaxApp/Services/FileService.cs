using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Services
{
    public class FileService
    {
        public Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public void saveFile(string filePath,string fileName,Stream stream)
        {
            string fileToWriteTo = String.Format("{0}\\{1}", filePath, fileName);
            using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
            {
                streamToWriteTo.Position = 0;
                stream.CopyTo(streamToWriteTo);
            }
           
        }

        

    }
}
