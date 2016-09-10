using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeRoom_Mobile.Models;
using HomeRoom_Mobile.Models.Api;

namespace HomeRoom_Mobile.Interfaces.DataService
{
    public interface IDataService
    {
        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse<CoursesResponse>> GetAllCourses();

        /// <summary>
        /// Gets all user courses.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<CoursesResponse> GetAllUserCourses(long userId);

        /// <summary>
        /// Gets the course.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<CourseDto> GetCourse(int id);

        /// <summary>
        /// Inserts the course into database.
        /// </summary>
        /// <param name="course">The course.</param>
        void InsertCourseIntoDb(Course course);

        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Course> GetAllCoursesFromDb();
    }
}
