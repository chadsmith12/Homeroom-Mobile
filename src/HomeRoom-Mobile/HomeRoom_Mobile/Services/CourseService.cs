using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using HomeRoom_Mobile.Models.Api;

namespace HomeRoom_Mobile.Services
{
    public class CourseService : BaseHttpService, ICourseService
    {
        private readonly Uri _baseUri;
        private IDictionary<string, string> _headers;

        public CourseService(Uri baseUri, string apiToken)
        {
            _baseUri = baseUri;

            _headers = new Dictionary<string, string> {{"Authorization", "Bearer " + apiToken}};
        }

        public async Task<CoursesResponse> GetAllUserCourses()
        {
            // we should not be trying to get any further if for some reason the current user id is null
            if (Helpers.Settings.CurrentUserId == null) return null;

            var courseResponse = new CoursesResponse();
            // we need to sync our local database, download latest courses using api
            if (Helpers.Settings.NeedsApiSync)
            {
                _headers = new Dictionary<string, string> { { "Authorization", "Bearer " + Helpers.Settings.ApiAuthToken } };
                var url = new Uri(_baseUri, "/api/Course/UserCourses/");
                var response = await SendRequestAsync<ApiResponse<CoursesResponse>>(url, HttpMethod.Get, _headers);
                if (response.Success)
                {
                    var courses = response.Result.Courses;
                    foreach (var course in courses)
                    {
                        var mobileCourse = App.Repository.GetByWebId<Course>(course.Id);
                        // updating the a previously synced course
                        if (mobileCourse != null)
                        {
                            mobileCourse.Teacher = course.Teacher;
                            mobileCourse.Name = course.Name;
                            mobileCourse.Subject = course.Subject;
                        }
                        // just make a new course to get inserted
                        else
                        {
                            mobileCourse = new Course
                            {
                                WebId = course.Id,
                                Name = course.Name,
                                Teacher = course.Teacher,
                                Subject = course.Subject,
                                UserId = Helpers.Settings.CurrentUserId.Value
                            };
                        }
                        App.Repository.Save(mobileCourse);
                    }
                }
                // uh-oh, we had an error, return know so we know something happened
                else return null;
            }
            // just get this information from the cache now
            var localCourses = App.Repository.GetAll<Course>().Where(x => x.UserId == Helpers.Settings.CurrentUserId.Value).Select(x => new CourseDto
            {
                Id = x.Id,
                Name = x.Name,
                Teacher = x.Teacher,
                Subject = x.Subject
            });

            courseResponse.Courses = localCourses.ToList();
            return courseResponse;
        }

        public async Task<CoursesResponse> GetAllCourses()
        {
            if (Helpers.Settings.CurrentUserId == null) return null;

            _headers = new Dictionary<string, string> { { "Authorization", "Bearer " + Helpers.Settings.ApiAuthToken} };
            var url = new Uri(_baseUri, "/api/Course/UserCourses/");
            var response = await SendRequestAsync<ApiResponse<CoursesResponse>>(url, HttpMethod.Get, _headers);
            if (response.Success)
            {
                var courses = response.Result.Courses;
                foreach (var course in courses)
                {
                    var mobileCourse = App.Repository.GetByWebId<Course>(course.Id);
                    // updating the a previously synced course
                    if (mobileCourse != null)
                    {
                        mobileCourse.Teacher = course.Teacher;
                        mobileCourse.Name = course.Name;
                        mobileCourse.Subject = course.Subject;
                    }
                    // just make a new course to get inserted
                    else
                    {
                        mobileCourse = new Course
                        {
                            WebId = course.Id,
                            Name = course.Name,
                            Teacher = course.Teacher,
                            Subject = course.Subject,
                            UserId = Helpers.Settings.CurrentUserId.Value
                        };
                    }
                    App.Repository.Save(mobileCourse);
                }
                return response.Result;
            }

            return null;
        }
    }
}
