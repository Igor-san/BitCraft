using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BitCraft.Classes
{
    public class FoundHistoryDataBase : IDisposable
    {

        bool disposed = false;

        public string LastError { get; private set; }

        public SQLiteConnection Connection { get; }

        public FoundHistoryDataBase(string file)
        {
            Connection = new SQLiteConnection($"Data Source={file};Version=3;PRAGMA journal_mode=WAL;PRAGMA encoding = 'ASCII'");
         
            Connection.Open();//сразу открываю


        }

        ~FoundHistoryDataBase()
        {
            Dispose(false);
        }

        //https://docs.microsoft.com/ru-ru/dotnet/standard/garbage-collection/implementing-dispose
        public void Dispose() //1) вначале это вызывается при выходе из USING
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing) //2) это вызывается из Dispose() или ~SqliteDatabase()
        {
            if (disposed)
                return;

            if (disposing)
            {
                // handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        public bool CreateTables()
        {
            LastError=String.Empty;
            try
            {
                CreateMainTable();
                return true;
            }

            catch (Exception ex)
            {
                LastError = "CreateTables: " + ex.Message;

                return false;
            }
        }

        private void CreateMainTable()
        {
            /*   According to BIP 173:
[Segwit] addresses are always between 14 and 74 characters long.
Version 0 witness addresses are always 42 or 62 characters.
          ...
I found this source from Trezor's wiki that says that a Bech32 "string" can be up to 90 characters long. This is what it says:
     */
            string sql = @"CREATE TABLE [Main] (
                [PrivateKey] nvarchar(64) NOT NULL PRIMARY KEY,
	            [Address] nvarchar(74) NOT NULL
            )";
            //PrivateKey - 16-ричный код в виде строки, Address - найденный адрес в блокчейне

            var command = new SQLiteCommand(sql, Connection);
            command.ExecuteNonQuery();


        }

        #region Utils
        SQLiteTransaction Transaction;

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Flush()
        {
   
            Transaction.Commit();
            Transaction = Connection.BeginTransaction();
        }
        public void Rollback()
        {
            Transaction.Rollback(); 
        }
        public long GetLastRowId()
        {
            return Connection.LastInsertRowId;
        }
        #endregion Utils

        /// <summary>
        /// Получить все адреса
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(string,string)> GetAll()
        {
            string sql = $"SELECT PrivateKey, Address FROM Main";

            using (var cmd = new SQLiteCommand(sql, Connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string privateKey = reader.GetString(0);
                        string address = reader.GetString(1);
                        yield return (privateKey, address);
                    }
                }
            }
        }


        public bool AddOne(string privateKey, string address)
        {
            LastError = (String.Empty);

            try
            {
                string sql = $"INSERT INTO Main (PrivateKey, Address)" +
                    $" VALUES ({privateKey},'{address}')";

                var command = new SQLiteCommand(sql, Connection);
                command.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                LastError = "AddOne: " + ex.Message;

                return false;
            }
        }

    }
}