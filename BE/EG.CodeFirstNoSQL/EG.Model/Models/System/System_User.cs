using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EG.Model.Models.System
{
    public class System_User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("Username")]
        public string Username { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("PasswordSalt")]
        public string PasswordSalt { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("UserAvatar")]
        public string UserAvatar { get; set; }
        [BsonElement("Address")]
        public string Address { get; set; }
        [BsonElement("Phone")]
        public string Phone { get; set; }
        [BsonElement("SupperUser")]
        public bool SupperUser { get; set; }
        [BsonElement("DateCreated")]
        public DateTime? DateCreated { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}
