using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BetterWriter.EditorModule.Services {
    public class FileService : IFileService {
        public string ReadAllFromFile(string filename) {
            return File.ReadAllText(filename, Encoding.UTF8);
        }

        public void WriteAllToFile(string path, string text) {
            File.WriteAllText(path, text, Encoding.UTF8);
        }
    }
}
