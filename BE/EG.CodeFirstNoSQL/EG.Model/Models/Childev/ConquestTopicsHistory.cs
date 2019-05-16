using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class ConquestTopicsHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ConquestTopics_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Question_id { get; set; }
    }
}
