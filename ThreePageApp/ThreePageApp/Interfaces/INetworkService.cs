using System;
using System.Threading.Tasks;

namespace ThreePageApp.Interfaces
{
    public interface INetworkService
    {
        Task<string> GetSSID(bool withMacAddress = true);

    }
}

