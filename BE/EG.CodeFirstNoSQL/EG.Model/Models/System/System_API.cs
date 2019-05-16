using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.System
{
    public class System_API
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("MethodType")]
        public string MethodType { get; set; }
        [BsonElement("Controller")]
        public string Controller { get; set; }
        [BsonElement("Active")]
        public string Action { get; set; }
        [BsonElement("ParamsName")]
        public List<string> ParamsName { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}
