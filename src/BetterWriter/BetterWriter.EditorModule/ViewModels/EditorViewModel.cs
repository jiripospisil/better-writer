using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterWriter.EditorModule.Services;
using BetterWriter.Common.BaseClasses;

namespace BetterWriter.EditorModule.ViewModels {
    public class EditorViewModel : ViewModelBase {

        #region Fields

        private readonly IFileService fileService;

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


        #region Constructor

        public EditorViewModel(IFileService fileService) {
            this.fileService = fileService;
        }

        #endregion




    }
}
