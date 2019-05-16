using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class AccountCourseLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Account_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Course_id { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("Price")]
        public double Price { get; set; }

    }
}
