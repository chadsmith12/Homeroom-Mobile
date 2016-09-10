using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces.DataService;
using HomeRoom_Mobile.Models;
using HomeRoom_Mobile.Models.Api;

namespace HomeRoom_Mobile.Services.DataService
{
    public class DataService : BaseHttpService, IDataService
    {
        private readonly Uri _baseUri;
        private readonly IDictionary<string, string> _headers;
        
        public DataService(Uri baseUri)
        {
            _baseUri = baseUri;

            _headers = new Dictionary<string, string>();
        } 

        public async Task<ApiResponse<CoursesResponse>> GetAllCourses()
        {
            var url = new Uri(_baseUri, "/api/Course/Courses/");
            var response = await SendRequestAsync<ApiResponse<CoursesResponse>>(url, HttpMethod.Get);

            return response;
        }

        public Task<CoursesResponse> GetAllUserCourses(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto> GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertCourseIntoDb(Course course)
        {
            App.Repository.Save(course);
        }

        public IEnumerable<Course> GetAllCoursesFromDb()
        {
            return App.Repository.GetAll<Course>();
        }
    }
}
