using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Models;
using Dapper;

namespace DatabaseAccess
{
    class DataAccess
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            
        public static List<Person> getPeople()
        {
            List<Person> people = new List<Person>();

            using (IDbConnection cnn = new SqlConnection(connectionString)) 
            {
                people = cnn.Query<Person>("spPerson_GetPeople", commandType: CommandType.StoredProcedure).ToList();
            }

            return people;
        }

        public static List<Present> getPresents()
        {
            List<Present> presents = new List<Present>();

            using (IDbConnection cnn = new SqlConnection(connectionString)) 
            {
                presents = cnn.Query<Present>("spPerson_GetPresent", commandType: CommandType.StoredProcedure).ToList();
            }

            return presents;
        }

        public static List<Person> getLeftPeople()
        {
            List<Person> leftPeople = new List<Person>();

            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                leftPeople = cnn.Query<Person>("spPerson_GetPersonNoPresent", commandType: CommandType.StoredProcedure).ToList();
            }

            return leftPeople;
        }

        public static void givePresent(int personId, int presentId)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Execute("dbo.spUpdatePresent", new { PersonId = personId, PresentId = presentId }, commandType: CommandType.StoredProcedure);
            }
        }

        public static Present getPresentNameById(int presentId)
        {
            Present output = new Present();

            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                output = cnn.Query<Present>("dbo.spGetPresentNameById", new { PresentId = presentId }, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();
            }

            return output;
        }
    }
}
