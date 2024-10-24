using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MyUniversityClient.Models.Input;
using MyUniversityClient.Models.Output;

namespace MyUniversityClient.Service;

public interface IStudent
{
    // Output NamaLayanan(Input varA)
    Task<ApiResponse<IEnumerable<GetStudentOutput>>> GetStudent();
    Task<ApiResponse<GetStudentOutput>> FindStudent(string id);
    Task<ApiResponse<string>> CreateStudent(CreateUpdateStudentInput request);
    Task<ApiResponse<string>> UpdateStudent(string id, CreateUpdateStudentInput request);
    Task<ApiResponse<string>> DeleteStudent(string id);

}
