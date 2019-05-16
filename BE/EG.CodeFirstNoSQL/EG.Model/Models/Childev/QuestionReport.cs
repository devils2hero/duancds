using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class QuestionReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Question_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Account_id { get; set; }
        [BsonElement("Content")]
        public string Content { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
