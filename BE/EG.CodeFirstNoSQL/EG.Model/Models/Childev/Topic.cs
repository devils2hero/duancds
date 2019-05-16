using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class Topic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Course_id { get; set; }
        [BsonElement("TopicName")]
        public string TopicName { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }
        [BsonElement("Background")]
        public string Background { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("NumberOfPraticeDays")]
        public int NumberOfPraticeDays { get; set; }
        [BsonElement("ConquestPoints")]
        public int ConquestPoints { get; set; }
        [BsonElement("PractisePoints")]
        public int PractisePoints { get; set; }
        [BsonElement("BonusPoints")]
        public int BonusPoints { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
       
    }
}
