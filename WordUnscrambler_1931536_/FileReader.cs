using System.Collections.Generic;
using System.IO;
namespace WordUnscrambler_1931536_
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            string[] filein;
            if (File.Exists(filename))
            {
                filein = File.ReadAllLines(filename);
               
            }
            else
            {
                throw new FileNotFoundException("The file \""+filename+"\" cannot be found");
            }
            return filein;
        }
    }
}
