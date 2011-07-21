using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BetterWriter.EditorModule.Services {
    public class MessageService : IMessageService {
        public void ShowMessage(string message) {
            MessageBox.Show(message);
        }


        public void ShowMessage(string message, string caption) {
            MessageBox.Show(message,caption);
        }
    }
}
