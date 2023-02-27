using System;
using System.Threading.Tasks;

namespace ThreePageApp.Services
{
	public interface INetworkService
	{
        Task<string> GetSSID(bool withMacAddress = true);

    }
}

