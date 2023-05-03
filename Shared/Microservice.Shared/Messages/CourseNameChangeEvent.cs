using System;
namespace Microservice.Shared.Messages
{
	public class CourseNameChangeEvent
	{
		public CourseNameChangeEvent()
		{
		}

		public string CourseId { get; set; }

		public string UpdatedName { get; set; }
	}
}

