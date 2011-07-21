using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using BetterWriter.EditorModule.Views;
using BetterWriter.EditorModule.Services;

namespace BetterWriter.EditorModule {
    public class EditorModule : IModule {

        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public EditorModule(IRegionManager regionManager, IUnityContainer container) {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize() {
            container.RegisterType<IFileService, FileService>();

            regionManager.RegisterViewWithRegion("EditorModule", typeof(EditorView));
        }
    }
}
