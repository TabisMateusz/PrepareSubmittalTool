using PrepareSubmittalTool.DB.Context;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.DB.Data
{
    public static class ClientData
    {
        public static void AddClient(Client client)
        {
            using(var db = new DataBaseContext())
            {
                db.Add(client);
                db.SaveChanges();
            }
        }

        public static bool ClientExist(string clientName)
        {
            using (var db = new DataBaseContext())
            {
                return db.CLIENTS.Any(x => x.Client_name == clientName);
            }
        }
    }
}
