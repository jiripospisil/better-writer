using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterWriter.EditorModule.Services {
    public interface IDialogService {
        void ShowMessage(string message);
        void ShowMessage(string message, string caption);
    }
}
