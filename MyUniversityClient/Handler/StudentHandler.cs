using System;
using MyUniversityClient.Models.Input;
using MyUniversityClient.Models.Output;
using MyUniversityClient.Service;
using Newtonsoft.Json;

namespace MyUniversityClient.Handler;

public class StudentHandler : IStudent
{
    private readonly IConfiguration _configuration;
    private readonly string baseUrl = "";
    private HttpClient httpClient = new HttpClient();

    public StudentHandler(IConfiguration configuration)
    {
        _configuration = configuration;
        baseUrl = _configuration["apiEndpoint"];
    }
    public async Task<ApiResponse<IEnumerable<GetStudentOutput>>> GetStudent(){
        string endpoint = baseUrl + "Student";

        var studentOutput = new ApiResponse<IEnumerable<GetStudentOutput>>();

        var response = await httpClient.GetAsync(endpoint);
        string apiResponse = await response.Content.ReadAsStringAsync();

        if (!string.IsNullOrEmpty(apiResponse))
        {
            studentOutput = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<GetStudentOutput>>>(apiResponse);
        }

        return studentOutput;
    }
    public async Task<ApiResponse<GetStudentOutput>> FindStudent(string id){
        string endpoint = baseUrl + "Student/" + id;

        var studentOutput = new ApiResponse<GetStudentOutput>();

        var response = await httpClient.GetAsync(endpoint);
        string apiResponse = await response.Content.ReadAsStringAsync();

        if (!string.IsNullOrEmpty(apiResponse))
        {
            studentOutput = JsonConvert.DeserializeObject<ApiResponse<GetStudentOutput>>(apiResponse);
        }

        return studentOutput;
    }
    public async Task<ApiResponse<string>> CreateStudent(CreateUpdateStudentInput request){
        if (request == null)
        {
            return new ApiResponse<string>
            {
                StatusCode = 400,
                Data = "Bad Request"
            };
        }

        string endpoint = baseUrl + "Student";
        var response = await httpClient.PostAsJsonAsync(endpoint, request);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

        return apiResponse;
    }
    public async Task<ApiResponse<string>> UpdateStudent(string id, CreateUpdateStudentInput request){
        if (id == null || request == null)
        {
            return new ApiResponse<string>
            {
                StatusCode = 400,
                Data = "Bad Request"
            };
        }

        string endpoint = baseUrl + "Student/" + id;
        var response = await httpClient.PutAsJsonAsync(endpoint, request);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

        return apiResponse;
    }
    public async Task<ApiResponse<string>> DeleteStudent(string id){
        if (id == null)
        {
            return new ApiResponse<string>
            {
                StatusCode = 400,
                Data = "Bad Request"
            };
        }

        string endpoint = baseUrl + "Student/" + id;
        var response = await httpClient.DeleteAsync(endpoint);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

        return apiResponse;
    }

}
