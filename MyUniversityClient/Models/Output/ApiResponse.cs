using System;

namespace MyUniversityClient.Models.Output;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public string RequestMethod{ get; set; }
    public T Data { get; set; }
}
