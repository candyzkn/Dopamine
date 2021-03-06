﻿using Digimezzo.Utilities.Settings;
using Dopamine.CollectionModule.ViewModels;
using Dopamine.CollectionModule.Views;
using Dopamine.Common.Enums;
using Dopamine.ControlsModule.Views;
using Dopamine.Common.Prism;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Dopamine.CollectionModule
{
    public class CollectionModule : IModule
    {
        #region Variables
        private readonly IRegionManager regionManager;
        private IUnityContainer container;
        #endregion

        #region Construction
        public CollectionModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }
        #endregion

        #region IModule
        public void Initialize()
        {
            // Register Views and ViewModels with UnityContainer
            this.container.RegisterType<object, CollectionViewModel>(typeof(CollectionViewModel).FullName);
            this.container.RegisterType<object, Collection>(typeof(Collection).FullName);
            this.container.RegisterType<object, CollectionSubMenu>(typeof(CollectionSubMenu).FullName);
            this.container.RegisterType<object, CollectionAlbumsViewModel>(typeof(CollectionAlbumsViewModel).FullName);
            this.container.RegisterType<object, CollectionAlbums>(typeof(CollectionAlbums).FullName);
            this.container.RegisterType<object, CollectionArtistsViewModel>(typeof(CollectionArtistsViewModel).FullName);
            this.container.RegisterType<object, CollectionArtists>(typeof(CollectionArtists).FullName);
            this.container.RegisterType<object, CollectionGenresViewModel>(typeof(CollectionGenresViewModel).FullName);
            this.container.RegisterType<object, CollectionGenres>(typeof(CollectionGenres).FullName);
            this.container.RegisterType<object, CollectionPlaylistsViewModel>(typeof(CollectionPlaylistsViewModel).FullName);
            this.container.RegisterType<object, CollectionPlaylists>(typeof(CollectionPlaylists).FullName);
            this.container.RegisterType<object, CollectionTracksViewModel>(typeof(CollectionTracksViewModel).FullName);
            this.container.RegisterType<object, CollectionTracks>(typeof(CollectionTracks).FullName);
            this.container.RegisterType<object, CollectionFrequentViewModel>(typeof(CollectionFrequentViewModel).FullName);
            this.container.RegisterType<object, CollectionFrequent>(typeof(CollectionFrequent).FullName);
            this.container.RegisterType<object, CollectionTracksColumnsViewModel>(typeof(CollectionTracksColumnsViewModel).FullName);
            this.container.RegisterType<object, CollectionTracksColumns>(typeof(CollectionTracksColumns).FullName);

            // Default View for dynamic Regions
            this.regionManager.RegisterViewWithRegion(RegionNames.SubMenuRegion, typeof(CollectionSubMenu));
            this.regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Collection));

            if (SettingsClient.Get<bool>("Startup", "ShowLastSelectedPage"))
            {
                SelectedPage page = (SelectedPage)SettingsClient.Get<int>("FullPlayer", "SelectedPage");

                switch (page)
                {
                    case SelectedPage.Artists:
                        this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionArtists));
                        break;
                    case SelectedPage.Genres:
                        this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionGenres));
                        break;
                    case SelectedPage.Albums:
                        this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionAlbums));
                        break;
                    case SelectedPage.Tracks:
                        this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionTracks));
                        break;
                    case SelectedPage.Playlists:
                        this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionPlaylists));
                        break;
                    case SelectedPage.Recent:
                        this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionFrequent));
                        break;
                    default:
                        this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionArtists));
                        break;
                }
            }
            else
            {
                this.regionManager.RegisterViewWithRegion(RegionNames.CollectionRegion, typeof(CollectionArtists));
            }
        }
        #endregion
    }
}
