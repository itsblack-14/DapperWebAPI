namespace DapperWebAPI.Features.Student
{
    public class StudentQuery
    {
        public static string GetStudentListQuery()
        {
            return @"SELECT * FROM Students ORDER BY Name";
        }

        public static string GetStudentDetailQuery()
        {
            return @"SELECT TOP 1 * FROM Students WHERE Id = @Id";
        }

        public static string CreateStudentQuery()
        {
            return @"INSERT INTO Students (Id,Name,Email,DateOfBirth,Address) 
                    Values(@Id,@Name,@Email,@DateOfBirth,@Address)";
        }

        public static string UpdateStudentQuery()
        {
            return @"UPDATE Students set 
                    Name = @Name ,
                    Email = @Email ,
                    DateOfBirth = @DateOfBirth ,
                    Address = @Address
                    WHERE Id = @Id";
        }

        public static string DeleteStudentQuery()
        {
            return @"DELETE Students where Id = @Id";
        }
    }
}
