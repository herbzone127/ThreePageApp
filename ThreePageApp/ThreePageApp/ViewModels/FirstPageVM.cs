using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ThreePageApp.Interfaces;
using ThreePageApp.ViewModels.Base;
using ThreePageApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ThreePageApp.ViewModels
{
    public class FirstPageVM:BaseViewModel
	{
        private INetworkService _workService;
        private INetworkStore _workStore;
		public FirstPageVM(INetworkService networkService,INetworkStore networkStore)
		{
          
			FirstLabel = "4F6I";
            NextCommand = new Command(NextCommandExecute);
            _workService = networkService;
            _workStore = networkStore;
            Initialize().ConfigureAwait(false);
                
           
            
        }
        public async Task Initialize()
        {
           
                await RequestPermissionAsync().ContinueWith(async (Task t) => {
                    if (t.IsCompleted)
                    {

                        var result = await _workService.GetSSID();
                        //var result = await DependencyService.Get<INetworkService>().GetSSID();
                        SecondLabel = result;
                        var storedNetwork = await _workStore.GetNetworkByPwd(FirstLabel);
                        if (storedNetwork == null)
                        {
                            var isAdded = await _workStore.SaveNetwork(new Models.NetworkStore
                            {
                                Ssid = result,
                                Pwd = FirstLabel
                            });

                        }
                    }
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
        private async void NextCommandExecute(object obj)
        {
           await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new SecondPage()));
        }
        #endregion
    }
}

