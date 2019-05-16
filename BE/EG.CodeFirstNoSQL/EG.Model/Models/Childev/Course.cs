using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EG.Model.Models.Childev
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("PrerequisiteCourse")]
        public string PrerequisiteCourse { get; set; }
        [Required(ErrorMessage ="Tên khóa học không được để trống")]
        [BsonElement("CourseName")]
        public string CourseName { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }
        [BsonElement("Background")]
        public string Background { get; set; }
        [BsonElement("Price")]
        public double Price { get; set; }
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [BsonElement("CreatedBy")]
        public string CreatedBy { get; set; }
        [BsonElement("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
        [BsonElement("ModifiedBy")]
        public string ModifiedBy { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}
