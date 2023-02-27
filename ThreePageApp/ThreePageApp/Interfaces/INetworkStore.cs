using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThreePageApp.Models;

namespace ThreePageApp.Interfaces
{
    public interface INetworkStore
    {
        Task<List<NetworkStore>> GetNetworkStores();
        Task<NetworkStore> GetNetworkByPwd(string pwd);
        Task<int> SaveNetwork(NetworkStore model);
        Task<int> RemoveAllNetwork();
    }
}
