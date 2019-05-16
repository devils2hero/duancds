using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class Account
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
        [BsonElement("Gender")]
        public bool Gender { get; set; }
        [BsonElement("Address")]
        public string Address { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}
