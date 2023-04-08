using Microservices.Services.Catolog.Models.BaseModels;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microservices.Services.Catolog.Models.Definations;

namespace Microservices.Services.Catolog.Models.Courses
{
    public class Course:BaseModel
    {
        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Desc { get; set; }

        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        //ignore edilmeli sadece veri dönerken klullanılacak
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
