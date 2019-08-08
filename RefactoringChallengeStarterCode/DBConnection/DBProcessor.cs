using System;
using System.Configuration;

namespace DBConnection
{
    public class DBProcessor
    {
        public static void Create()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;

            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var records = cnn.Query<SystemUserModel>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();

                users.Clear();
                records.ForEach(x => users.Add(x));
            }
        }

        public static void Get()
        {

        }

    }
}
