using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class PosDAO
    {
        public string connectionString { get; set; }

        public void getConnection()
        {
            string connection = @"Data Source=POS.db;Version=3";
            connectionString = connection;

        }
    }
}
