using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThreePageApp.Interfaces;

namespace ThreePageApp.Models
{
    public class Database:INetworkStore
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<NetworkStore>();
        }

        public async Task<List<NetworkStore>> GetNetworkStores()
        {
            return await _database.Table<NetworkStore>().ToListAsync();
        }
        public async Task<NetworkStore> GetNetworkByPwd(string pwd)
        {
            return await _database.Table<NetworkStore>().FirstOrDefaultAsync(u => u.Pwd == pwd); ;
        }
        public async Task<int> SaveNetwork(NetworkStore model)
        {
            
            return await _database.InsertAsync(model); ;
        }
        public async Task<int> RemoveAllNetwork()
        {
            var result = await _database.DeleteAllAsync<NetworkStore>();
            return result;
        }
    }
}
