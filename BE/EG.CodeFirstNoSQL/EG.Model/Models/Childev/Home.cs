using MongoDB.Bson;
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace EG.Model.Models.Childev
{
    public class Home
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
