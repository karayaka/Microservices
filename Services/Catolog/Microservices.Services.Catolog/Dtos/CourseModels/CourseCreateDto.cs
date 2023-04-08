using Microservices.Services.Catolog.Dtos.BaseDtos;
using Microservices.Services.Catolog.Dtos.DefinationModels;

namespace Microservices.Services.Catolog.Dtos.CourseModels
{
    public class CourseCreateDto:BaseDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Desc { get; set; }

        public string CategoryId { get; set; }

        public FeatureDto Feature { get; set; }
    }
}
