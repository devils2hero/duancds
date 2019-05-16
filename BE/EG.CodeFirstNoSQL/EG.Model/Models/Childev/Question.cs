using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Topic_id { get; set; }

        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        [BsonElement("Content")]
        public string Content { get; set; }
        [BsonElement("AudioPath")]
        public string AudioPath { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
