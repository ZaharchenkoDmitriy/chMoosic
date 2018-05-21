using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Music
{
    class Song
    {
        public Song(String name, String filePath)
        {
            this.Name = name;
            this.FilePath = filePath;
        }

        public String Name { get; set; }
        public String FilePath { get; set; }

        public Stream getStream()
        {
            var stream = File.OpenRead(FilePath);

            return stream;
        }
    }
}
