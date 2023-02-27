using System;
using System.Threading.Tasks;
using CoreLocation;
using Foundation;
using NetworkExtension;
using SystemConfiguration;
using ThreePageApp.Interfaces;
using ThreePageApp.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkService))]
namespace ThreePageApp.iOS.Services
{
    public class NetworkService:INetworkService
	{
        

        public async Task<string> GetSSID(bool withMacAddress = true)
        {
            GetLocationConsent();

         
       


            try{
                /*This code is only working with physical devices*/
                
               var result= await NEHotspotNetwork.FetchCurrentAsync() ;

                /*This method is depricated and it only work in IOS 12*/
                // To use CaptiveNetwork, enable the provisioning profile and "Access WiFi Information" in "Entitlements.plist"
                //string[] interfaces;
                //CaptiveNetwork.TryGetSupportedInterfaces(out interfaces);
                //if ((interfaces == null) || (interfaces.Length <= 0))
                //{
                //    return null;
                //}

                //try
                //{
                //    NSDictionary networkInfo;
                //    CaptiveNetwork.TryCopyCurrentNetworkInfo(interfaces[0], out networkInfo);
                //    if (networkInfo == null)
                //    {
                //        return null;
                //    }

                //    string ssid = networkInfo[CaptiveNetwork.NetworkInfoKeySSID].ToString();
                #if DEBUG
                return "Test WIFI";
                #else
                return result.Ssid;
                #endif
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void NetworkResult(NEHotspotNetwork obj)
        {
            var result = obj.Ssid;
        }

        private void GetLocationConsent()
        {
            try
            {
                var manager = new CLLocationManager();
                manager.DesiredAccuracy = CLLocation.AccuracyKilometer;
                manager.RequestAlwaysAuthorization();
                manager.StartUpdatingLocation();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}


