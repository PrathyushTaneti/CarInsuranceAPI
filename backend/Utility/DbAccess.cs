using Microsoft.EntityFrameworkCore.Storage;
using Database = PetaPoco.Database;
using IDatabase = PetaPoco.IDatabase;

namespace BeenFieldAPI.Utility
{
    public class DbAccess
    {
        internal readonly IDatabase dbConnection;
        public DbAccess()
        {
            dbConnection = new Database("Server = .\\SQLEXPRESS; " + "Database = EstimationModelDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }
    }
}
