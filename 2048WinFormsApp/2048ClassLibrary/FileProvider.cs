using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048ClassLibrary
{
    public class FileProvider
    {       
        public static void Replace(string path, string data)
        {
            using (StreamWriter writeData = new StreamWriter(path, false))
            {
                writeData.WriteLine(data);
            }
        }

        internal static bool Exists(string path)
        {
            return File.Exists(path);
        }

        public static string Get(string path)
        {
            using (StreamReader readData = new StreamReader(path))
            {
                return readData.ReadToEnd();
            }
        }
    }
}
