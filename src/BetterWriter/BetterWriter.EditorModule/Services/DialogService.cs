using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace BetterWriter.EditorModule.Services {
    public class DialogService : IDialogService {
        public string ShowOpenFileDialog() {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            
            Nullable<bool> result = dialog.ShowDialog();

            if(result == true) {
                return dialog.FileName;
            }

            return null;
        }
    }
}
