using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Net.Wifi;
using ThreePageApp.Droid.Services;
using ThreePageApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkService))]
namespace ThreePageApp.Droid.Services
{
    public class NetworkService:INetworkService
	{
		public NetworkService()
		{
		}

        public async Task<string> GetSSID(bool withMacAddress = true)
        {
           await Task.Delay(TimeSpan.FromSeconds(1));
           WifiManager wifiManager = (WifiManager)Android.App.Application.Context
                        .GetSystemService(Context.WifiService);
            var wifiInfo = wifiManager.ConnectionInfo;
            return wifiInfo.SSID.ToString();

        }
    }
}

