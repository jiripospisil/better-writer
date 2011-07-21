using Microsoft.Practices.Prism.Events;
using BetterWriter.Common.Events;
using BetterWriter.Common.BaseClasses;

namespace BetterWriter.ViewModels {
    public class ShellViewModel : ViewModelBase {

        private readonly IEventAggregator eventAggregator;

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

        public ShellViewModel(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;

            var evt = this.eventAggregator.GetEvent<NewFileOpenedEvent>();
            evt.Subscribe(OnNewFileOpened);
        }

        public void OnNewFileOpened(string fileName) {
            FileName = fileName;
        }
    }
}
