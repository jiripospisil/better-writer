using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterWriter.EditorModule.Services {
    public interface IDialogService {
        string ShowOpenFileDialog();
        string ShowSaveFileDialog();
    }
}
