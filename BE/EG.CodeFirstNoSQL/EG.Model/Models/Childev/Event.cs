using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Account_id { get; set; }
        [BsonElement("ContentEvent")]
        public string ContentEvent { get; set; }
        [BsonElement("TimeStart")] 
        public DateTime TimeStart { get; set; }
        [BsonElement("TimeEnd")]
        public DateTime TimeEnd { get; set; }
        [BsonElement("Result")]
        public string Result { get; set; }
        [BsonElement("Bonus")]
        public string Bonus { get; set; }
    }
}
