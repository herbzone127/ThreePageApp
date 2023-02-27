using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreePageApp.Models
{
    public class NetworkStore
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Ssid { get; set; }
        public string Pwd { get; set; }
      
    }
}
