using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ThreePageApp.Interfaces;
using ThreePageApp.ViewModels.Base;
using ThreePageApp.Views;
using Xamarin.Forms;

namespace ThreePageApp.ViewModels
{
    public class SecondPageVM:BaseViewModel
    {
		INetworkStore _networkStore;
        public SecondPageVM(INetworkStore networkStore) { 
		_networkStore = networkStore;
			Submit = new Command(SubmitCommandExecute);
		}

      

        private string _search;

		public string Search
		{
			get { return _search; }
			set { _search = value;
			OnPropertyChanged(nameof(Search));
			
			}
		}
        public ICommand Submit { get; set; }
        private async void SubmitCommandExecute(object obj)
        {
			var result =await _networkStore.GetNetworkByPwd(Search);
			if (result != null)
			{
				Application.Current.MainPage = new NavigationPage(new ThirdPage());
            }
		
        }

    }
}
