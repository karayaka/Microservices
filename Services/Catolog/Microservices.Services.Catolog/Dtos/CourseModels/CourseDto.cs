using Microservices.Services.Catolog.Dtos.BaseDtos;
using Microservices.Services.Catolog.Models.Definations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microservices.Services.Catolog.Dtos.DefinationModels;

namespace Microservices.Services.Catolog.Dtos.CourseModels
{
    public class CourseDto:BaseDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Desc { get; set; }

        public string CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public FeatureDto Feature { get; set; }

    }
}
