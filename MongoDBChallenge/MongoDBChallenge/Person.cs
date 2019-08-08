using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBChallenge
{
    public class Person
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string FirstName { get; set; }

        [BsonElement]
        public string LastName { get; set; }

        [BsonElement]
        public string PhoneNumber { get; set; }
        
        public string FullName
        {
            get {
                return $"{ FirstName } { LastName }";
            }
        }
    }
}
