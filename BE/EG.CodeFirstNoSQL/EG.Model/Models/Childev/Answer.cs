using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class Answer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Quesiton_id { get; set; }
        [BsonElement("CorrectIndex")]
        public int CorrectIndex { get; set; }
        [BsonElement("Content")]
        public string Content { get; set; }
        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }
        [BsonElement("AudioPath")]
        public string AudioPath { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

    }
}
