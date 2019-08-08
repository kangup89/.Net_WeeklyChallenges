using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBChallenge
{
    public class MongoDBAccess
    {
        public static IMongoDatabase db;
        public static IMongoCollection<Person> collection;
        public static List<Person> people = new List<Person>();

        public MongoDBAccess()
        {
            string username = "kangup89";
            string password = "0215";
            string mongoDbAuthMechanism = "SCRAM-SHA-1";
            MongoInternalIdentity internalIdentity =
                      new MongoInternalIdentity("CSharpTest", username);
            PasswordEvidence passwordEvidence = new PasswordEvidence(password);
            MongoCredential mongoCredential =
                 new MongoCredential(mongoDbAuthMechanism,
                         internalIdentity, passwordEvidence);
            List<MongoCredential> credentials =
                       new List<MongoCredential>() { mongoCredential };

            MongoClientSettings settings = new MongoClientSettings();
            // comment this line below if your mongo doesn't run on secured mode
            settings.Credentials = credentials;
            String mongoHost = "127.0.0.1";
            MongoServerAddress address = new MongoServerAddress(mongoHost);
            settings.Server = address;

            var cnn = ConfigurationManager.ConnectionStrings["MongoDB"];
            var connectionString = cnn.ConnectionString;
            MongoClient client = new MongoClient(settings);

            db = client.GetDatabase("CSharpTest");
            GetCollection();
        }

        static void GetCollection()
        {
            collection = db.GetCollection<Person>("People");
        }
        
        public List<Person> getPeople()
        {
            people = (List<Person>)collection.AsQueryable<Person>().ToList();

            return people;
        }

        public void addPerson(Person p)
        {
            collection.InsertOne(p);
            collection = db.GetCollection<Person>("People");
        }

        public bool checkPerson(string firstName, string lastName)
        {
            foreach (Person p in people)
            {
                if (p.FirstName == firstName && p.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        public void addOrUpdate(Person p)
        {
            //var filter = new BsonDocument();
            //filter.Add("firstname", p.FirstName);
            //filter.Add("lastname", p.LastName);

            //var newperson = new bsondocument();
            //newperson.add("firstname", p.firstname);
            //newperson.add("lastname", p.lastname);
            //if (p.phonenumber != null)
            //{
            //    newperson.add("phonenumber", p.phonenumber);
            //}

            var builder = new FilterDefinitionBuilder<Person>();
            var filter = builder.Eq(x => x.FirstName, p.FirstName) & builder.Eq(x => x.LastName, p.LastName);

            if (collection.Find<Person>(filter).FirstOrDefault() != null)
            {
                collection.FindOneAndUpdate<Person>(
                    //Builders<Person>.Filter.Eq("FirstName", p.FirstName),
                    filter,
                    Builders<Person>.Update.Set("PhoneNumber", p.PhoneNumber)
                );
            }
            else
            {
                collection.InsertOne(p);
            }

            collection = db.GetCollection<Person>("People");
        }
    }
}
