using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Microservices.Services.Catolog.Models.BaseModels
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string? CreatedUserId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdateDate { get; set; }

        public string? UpdateUserId { get; set; }
    }
}
