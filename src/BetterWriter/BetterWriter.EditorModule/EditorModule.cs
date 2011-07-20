using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using BetterWriter.EditorModule.Views;

namespace BetterWriter.EditorModule {
    public class EditorModule : IModule {

        private readonly IRegionManager regionManager;

        public EditorModule(IRegionManager regionManager) {
            this.regionManager = regionManager;
        }

        public void Initialize() {
            regionManager.RegisterViewWithRegion("EditorModule", typeof(EditorView));
        }
    }
}
