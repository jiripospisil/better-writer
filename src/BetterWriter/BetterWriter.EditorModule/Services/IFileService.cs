using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterWriter.EditorModule.Services {
    public interface IFileService {
        string ReadAllFromFile(string filename);
    }
}
