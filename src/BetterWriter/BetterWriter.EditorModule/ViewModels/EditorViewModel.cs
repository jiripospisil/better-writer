using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterWriter.EditorModule.Services;

namespace BetterWriter.EditorModule.ViewModels {
    public class EditorViewModel {

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
                _text = value;
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
