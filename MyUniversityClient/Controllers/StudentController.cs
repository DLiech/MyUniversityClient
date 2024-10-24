using Microsoft.AspNetCore.Mvc;
using MyUniversityClient.Models.Input;
using MyUniversityClient.Service;

namespace MyUniversityClient.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _studentApi;
        // GET: StudentController
        public StudentController(IStudent studentApi)
        {
            _studentApi = studentApi;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetStudent()
        {
            var result = await _studentApi.GetStudent();
            return Json(result);
        }
        public async Task<IActionResult> FindStudent(string id)
        {
            var result = await _studentApi.FindStudent(id);
            return Json(result);
        }
        public async Task<IActionResult> CreateStudent([FromBody] CreateUpdateStudentInput request)
        {
            var result = await _studentApi.CreateStudent(request);
            return Json(result);
        }
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] CreateUpdateStudentInput request)
        {
            var result = await _studentApi.UpdateStudent(id, request);
            return Json(result);
        }
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var result = await _studentApi.DeleteStudent(id);
            return Json(result);
        }
    }
}
