using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ThreePageApp.Services;
using ThreePageApp.ViewModels.Base;
using ThreePageApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ThreePageApp.ViewModels
{
	public class FirstPageVM:BaseViewModel
	{
		public FirstPageVM()
		{
			FirstLabel = "4F6I";
            NextCommand = new Command(NextCommandExecute);
            Task.Run(async() => {
                await RequestPermissionAsync().ContinueWith(async(Task t)=>{
                    if (t.IsCompleted)
                    {
                        var result = await DependencyService.Get<INetworkService>().GetSSID();
                        SecondLabel = result;
                    }
                });
               
            });
                
           
            
        }

        async Task RequestPermissionAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            var locationAlways = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            var network = await Permissions.CheckStatusAsync<Permissions.NetworkState>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
            if (locationAlways != PermissionStatus.Granted)
            {
                locationAlways = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }
            if (network != PermissionStatus.Granted)
            {
                network = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }
        }
        #region Properties
        private string _firstLabel;
		public string FirstLabel
		{
			get { return _firstLabel; }
			set {
                _firstLabel = value;
				OnPropertyChanged(nameof(FirstLabel));
			}
		}
        private string _secondLabel;
        public string SecondLabel
        {
            get { return _secondLabel; }
            set
            {
                _secondLabel = value;
                OnPropertyChanged(nameof(SecondLabel));
            }
        }
        #endregion
        #region Commands
        public ICommand NextCommand { get; set; }
        #endregion
        #region Methods
        private void NextCommandExecute(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new SecondPage());
        }
        #endregion
    }
}

