﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterWriter.EditorModule.Services;
using BetterWriter.Common.BaseClasses;
using System.IO;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;

namespace BetterWriter.EditorModule.ViewModels {
    public class EditorViewModel : ViewModelBase {

        #region Fields

        private readonly IFileService fileService;
        private readonly IMessageService messageService;
        private readonly IDialogService dialogService;

        #endregion

        #region Properties with backing fields

        private string _text;
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

        #endregion

        #region Commands with actions

        private ICommand _openFileCommand;

        public ICommand OpenFileCommand {
            get {
                if(_openFileCommand == null) {
                    _openFileCommand = new DelegateCommand(DoOpenFile);
                }
                return _openFileCommand;
            }
        }

        private void DoOpenFile() {
            string fileName = dialogService.ShowOpenFileDialog();

            try {
                Text = this.fileService.ReadAllFromFile(fileName);
            } catch(Exception) {
                this.messageService.ShowMessage("Unable to open the specified file.", "Error");
            }
        }

        #endregion

        #region Constructor

        public EditorViewModel(IFileService fileService, IMessageService messageService, IDialogService dialogService) {
            this.fileService = fileService;
            this.messageService = messageService;
            this.dialogService = dialogService;
        }

        #endregion
    }
}
