using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganiserACS
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connection { get; private set; } = new List<IDataConnection>();
        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.TextFile)
            {
                
                TextConnector text = new TextConnector();
                Connection.Add(text);

            }
        }
    }
}
