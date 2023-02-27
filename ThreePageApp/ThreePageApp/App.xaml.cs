using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.IO;
using ThreePageApp.Interfaces;
using ThreePageApp.Models;
using ThreePageApp.ViewModels;
using ThreePageApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreePageApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public App (Action<IServiceCollection> addPlatformServices = null)
        {
            InitializeComponent();
     SetupServices(addPlatformServices);
            MainPage = new NavigationPage(new FirstPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
        void SetupServices(Action<IServiceCollection> addPlatformServices = null)
        {
            var services = new ServiceCollection();
            addPlatformServices?.Invoke(services);
            // TODO: Add core services here
            services.AddTransient<FirstPageVM>();
            services.AddTransient<SecondPageVM>();
            services.AddSingleton<INetworkStore>(x =>
    ActivatorUtilities.CreateInstance<Database>(x, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "networkstore.db3")));
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}

