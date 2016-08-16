using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using _connectMySQL;

namespace CliniQ.LOCAL_CLASS
{
    class CMisc
    {
        readonly CConnection _connect = new CConnection();
        public int RowsCounter(string query, MySqlConnection connection, ref string errMsg)
        {
            int result = 0;
            MySqlDataReader reader = _connect.Reading(query, connection, ref errMsg);
            if (reader.HasRows)
            {
                reader.Read();
                result = Convert.ToInt16(reader[0]);
                reader.Close();
            }
            return result;
        }
    }
}
