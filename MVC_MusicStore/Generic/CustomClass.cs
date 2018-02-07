using MVC_MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_MusicStore.Generic
{
    public class CustomClass
    {

        public bool TestConnectionEF()
        {
            using (var db = new MusicStoreContext())
            {
                try
                {
                    db.Database.Connection.Open();
                    if (db.Database.Connection.State == ConnectionState.Open)
                    {
                        Console.WriteLine(@"INFO: ConnectionString: " + db.Database.Connection.ConnectionString
                            + "\n DataBase: " + db.Database.Connection.Database
                            + "\n DataSource: " + db.Database.Connection.DataSource
                            + "\n ServerVersion: " + db.Database.Connection.ServerVersion
                            + "\n TimeOut: " + db.Database.Connection.ConnectionTimeout);
                        db.Database.Connection.Close();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " \n PING: " + TryPing(db.Database.Connection.DataSource).ToString());
                }
            }
        }

        private object TryPing(string dataSource)
        {
            throw new NotImplementedException();
        }
    }
}