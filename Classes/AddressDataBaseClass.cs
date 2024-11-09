using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace BitCraft.Classes
{
    public class AddressDataBaseClass : IDisposable
    {
 
        bool disposed = false;

        public string LastError { get; private set; }

        public SQLiteConnection Connection { get; internal set; }

        public AddressDataBaseClass()
        {

        }

        public AddressDataBaseClass(string file)
        {
            Connection = new SQLiteConnection($"Data Source={file};Version=3;PRAGMA journal_mode=WAL;");
        
            Connection.Open();//сразу открываю

        }

        ~AddressDataBaseClass() 
        {
            Dispose(false);
        }

        //https://docs.microsoft.com/ru-ru/dotnet/standard/garbage-collection/implementing-dispose
        public void Dispose() 
        {
            try
            {
                // Dispose of unmanaged resources.
                Dispose(true);
                if (Connection != null)
                {
                    Connection.Close();
                    Connection.Dispose();
                    Connection = null;
                }
            }
            catch (Exception)
            {
            
            }

            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing) 
        {
            if (disposed)
                return;

            if (disposing)
            {
                // handle.Dispose();
                // Free any other managed objects here.
            }

            disposed = true;
        }

        public bool ExecuteNonQuerySql(string sql, out int affected)
        {
            affected = 0;
            LastError =String.Empty;

            try
            {

                var command = new SQLiteCommand(sql, Connection);
                affected = command.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                LastError = "ExecuteNonQuerySql: " + ex.Message;
                return false;
            }
        }

        public async Task<long> GetAddressesCountAsync()
        {
            LastError = String.Empty;

            try
            {
                string sql = "SELECT MAX(_ROWID_) FROM " + Constants.AddressTableName + " LIMIT 1"; 
                var command = new SQLiteCommand(sql, Connection);
                var obj = await command.ExecuteScalarAsync();

                return Convert.ToInt64(obj);

            }
            catch (Exception ex)
            {
                LastError = "GetAddressesCountAsync: " + ex.Message;

                return -1;
            }
        }
        public long GetAddressesCount()
        {
            LastError = String.Empty;

            try
            {
                string sql = "SELECT MAX(_ROWID_) FROM " + Constants.AddressTableName + " LIMIT 1"; 
                var command = new SQLiteCommand(sql, Connection);
                var obj = command.ExecuteScalar();

                return Convert.ToInt64(obj);

            }
            catch (Exception ex)
            {
                LastError = "GetAddressesCount: " + ex.Message;

                return -1;
            }
        }


        internal bool AddressExists(string address)
        {
            LastError = String.Empty;
            try
            {
                string sql = $"SELECT {Constants.AddressFieldName} FROM {Constants.AddressTableName} WHERE {Constants.AddressFieldName}='{address}'";
                var command = new SQLiteCommand(sql, Connection);

                var exists = command.ExecuteScalar();
                if (exists != null)
                {
                    return true; 
                }

                return false;

            }
            catch (Exception ex)
            {
                LastError = "AddressExists: " + ex.Message;

                return false;
            }
        }

        internal IEnumerable<string> GetAllAddresses(int limit = 0)
        {
            string sql = $"SELECT {Constants.AddressFieldName} FROM {Constants.AddressTableName}";
            if (limit > 0)
            {
                sql += $" LIMIT {limit}";
            }

            var command = new SQLiteCommand(sql, Connection);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                         string address = reader.GetString(0);
                         yield return address;
                        }
                    }
   
        }
    }
}
