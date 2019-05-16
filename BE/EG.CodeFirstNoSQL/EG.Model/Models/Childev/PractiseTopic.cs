using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class PractiseTopic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Topic_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Account_id { get; set; }
        [BsonElement("Note")]
        public string Note { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("IsComplete")]
        public bool IsComplete { get; set; }
        [BsonElement("CompleteDate")]
        public DateTime ComleteDate { get; set; }

    }
}
