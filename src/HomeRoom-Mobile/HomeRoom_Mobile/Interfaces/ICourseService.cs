using System.Threading.Tasks;
using HomeRoom_Mobile.Models.Api;

namespace HomeRoom_Mobile.Interfaces
{
    public interface ICourseService
    {
        /// <summary>
        /// Gets all user courses.
        /// </summary>
        /// <returns>List of all the user courses.</returns>
        Task<CoursesResponse> GetAllUserCourses();

        /// <summary>
        /// Gets all courses.
        /// </summary>
        /// <returns></returns>
        Task<CoursesResponse> GetAllCourses();
    }
}
