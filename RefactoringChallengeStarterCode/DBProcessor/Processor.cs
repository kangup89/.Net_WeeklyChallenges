using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DBProcessor
{
    public class Processor
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;

        public static List<UserModel> GetUserModels(String filter)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                List<UserModel> records;

                if(filter == null)
                {
                    records = cnn.Query<UserModel>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();
                }
                else
                {
                    var p = new
                    {
                        Filter = filter
                    };

                    records = cnn.Query<UserModel>("spSystemUser_GetFiltered", p, commandType: CommandType.StoredProcedure).ToList();
                }
                
                return records;
            }
        }

        public static void CreateUser(String firstName, String lastName)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var p = new
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                cnn.Execute("dbo.spSystemUser_Create", p, commandType: CommandType.StoredProcedure);
            }
        }
        
    }
}
