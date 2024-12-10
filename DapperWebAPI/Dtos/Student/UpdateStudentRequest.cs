﻿namespace DapperWebAPI.Dtos.Student
{
    public class UpdateStudentRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
