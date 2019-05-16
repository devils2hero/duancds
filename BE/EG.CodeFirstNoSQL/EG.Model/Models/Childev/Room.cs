using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Home_id { get; set; }
        public string Name { get; set; }
        public double Acreage { get; set; }
        public bool IsUsed { get; set; }
    }
}
