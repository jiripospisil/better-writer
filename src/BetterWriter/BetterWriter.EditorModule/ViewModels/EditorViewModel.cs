using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterWriter.EditorModule.Services;
using BetterWriter.Common.BaseClasses;
using System.IO;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using Microsoft.Practices.Prism.Events;
using BetterWriter.Common.Events;

namespace BetterWriter.EditorModule.ViewModels {
    public class EditorViewModel : ViewModelBase {

        #region Fields

        private readonly IFileService fileService;
        private readonly IMessageService messageService;
        private readonly IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Properties

        private string _text = string.Empty;
        public string Text {
            get {
                return _text;
            }
            set {
                if(_text != value) {
                    _text = value;
                    RaisePropertyChanged("Text");
                }
            }
        }

        private string FileName {
            get;
            set;
        }

        #endregion

        #region Constructor

        public EditorViewModel(IFileService fileService, IMessageService messageService, IDialogService dialogService, IEventAggregator eventAggregator) {
            this.fileService = fileService;
            this.messageService = messageService;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;

            var evt = this.eventAggregator.GetEvent<ShortcutPressedEvent>();
            evt.Subscribe(HandleShortcutPressedEvent);
        }

        #endregion

        #region Methods

        private void HandleShortcutPressedEvent(Shortcut shortcut) {
            switch(shortcut) {
                case Shortcut.CTRL_O:
                    HandleControlOShortcut();
                    break;
                case Shortcut.CTRL_S:
                    HandleControlSShortcut();
                    break;
            }
        }

        private void HandleControlOShortcut() {
            string fileName = dialogService.ShowOpenFileDialog();

            if(fileName != null) {
                try {
                    Text = this.fileService.ReadAllFromFile(fileName);
                    FileName = fileName;

                    var evt = this.eventAggregator.GetEvent<OpenedFileChangedEvent>();
                    evt.Publish(fileName);
                } catch(Exception) {
                    this.messageService.ShowMessage("Unable to open the specified file.", "Error");
                }
            }
        }

        private void HandleControlSShortcut() {
            try {
                if(FileName != null) {
                    WriteToFile();
                } else {
                    AskForFileNameAndWriteToFile();
                }
            } catch(Exception) {
                this.messageService.ShowMessage("Unable to save to the specified file.", "Error");
            }
        }

        private void AskForFileNameAndWriteToFile() {
            string fileName = dialogService.ShowSaveFileDialog();

            if(fileName != null) {
                this.fileService.WriteAllToFile(fileName, Text);
                FileName = fileName;

                var evt = this.eventAggregator.GetEvent<OpenedFileChangedEvent>();
                evt.Publish(fileName);
            }
        }

        private void WriteToFile() {
            this.fileService.WriteAllToFile(FileName, Text);
        }

        #endregion
    }
}
