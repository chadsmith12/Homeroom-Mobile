using System.Collections.Generic;
using Newtonsoft.Json;

namespace HomeRoom_Mobile.Models.Api
{
    public class CoursesResponse
    {
        [JsonProperty("courses")]
        public IList<CourseDto> Courses { get; set; } 
    }

    public class CourseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("teacher")]
        public string Subject { get; set; }
        [JsonProperty("subject")]
        public string Teacher { get; set; }
    }
}
