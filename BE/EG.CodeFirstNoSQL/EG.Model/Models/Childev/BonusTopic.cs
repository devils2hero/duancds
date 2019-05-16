using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class BonusTopic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Account_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Topics_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Question_id { get; set; }
        [BsonElement("DateStart")]
        public DateTime DateStart { get; set; }
        [BsonElement("DateEnd")]
        public DateTime DateEnd { get; set; }
        [BsonElement("IsQualified")]
        public bool IsQualified { get; set; }
          

    }
}
