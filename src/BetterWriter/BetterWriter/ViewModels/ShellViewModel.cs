using Microsoft.Practices.Prism.Events;
using BetterWriter.Common.Events;
using BetterWriter.Common.BaseClasses;

namespace BetterWriter.ViewModels {
    public class ShellViewModel : ViewModelBase {

        #region Fields

        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Properties

        private string _fileName;
        public string FileName {
            get {
                if(_fileName == null) {
                    return "Untitled";
                }
                return _fileName;
            }
            set {
                if(_fileName != value) {
                    _fileName = value;
                    RaisePropertyChanged("FileName");
                }
            }
        }

        #endregion

        #region Constructor

        public ShellViewModel(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;

            var evt = this.eventAggregator.GetEvent<NewFileOpenedEvent>();
            evt.Subscribe(OnNewFileOpened);
        }

        #endregion

        #region Methods

        public void OnNewFileOpened(string fileName) {
            FileName = fileName;
        }
        
        #endregion
    }
}
