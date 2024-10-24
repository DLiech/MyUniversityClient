using System;

namespace MyUniversityClient.Models.Input;

public class CreateUpdateStudentInput
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int MajorId { get; set; }
}

