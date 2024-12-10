using Dapper;
using DapperWebAPI.Dtos;
using DapperWebAPI.Dtos.Student;
using DapperWebAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperWebAPI.Features.Student
{
    public interface IStudentService
    {
        Task<ResponseStatus> CreateStudent(CreateStudentRequest req);
        Task<ResponseStatus> UpdateStudent(UpdateStudentRequest req);
        Task<ResponseStatus> DeleteStudent(string id);
        Task<ResponseStatus> GetStudentList();
        Task<ResponseStatus> GetStudentDetail(string id);
    }

    public class StudentService : IStudentService
    {
        private readonly IConfiguration _configuration;

        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseStatus> CreateStudent(CreateStudentRequest req)
        {
            var response = new ResponseStatus();
            try
            {
                using IDbConnection _context = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                string query = StudentQuery.CreateStudentQuery();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", Guid.NewGuid().ToString());
                parameters.Add("@Name", req.Name);
                parameters.Add("@Email", req.Email);
                parameters.Add("@DateOfBirth", req.DateOfBirth);
                parameters.Add("@Address", req.Address);
                
                int result = await _context.ExecuteAsync(query, parameters);

                response = result > 0
                    ? new ResponseStatus(StatusCodes.Status200OK, "Success")
                    : new ResponseStatus(StatusCodes.Status500InternalServerError, "Failed");
            }
            catch(Exception ex)
            {
                response = new ResponseStatus(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return response;
        }

        public async Task<ResponseStatus> UpdateStudent(UpdateStudentRequest req)
        {
            var response = new ResponseStatus();
            try
            {
                using IDbConnection _context = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                string query = StudentQuery.UpdateStudentQuery();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", req.Id);
                parameters.Add("@Name", req.Name);
                parameters.Add("@Email", req.Email);
                parameters.Add("@DateOfBirth", req.DateOfBirth);
                parameters.Add("@Address", req.Address);

                int result = await _context.ExecuteAsync(query, parameters);

                response = result > 0
                    ? new ResponseStatus(StatusCodes.Status200OK, "Success")
                    : new ResponseStatus(StatusCodes.Status500InternalServerError, "Failed");
            }
            catch (Exception ex)
            {
                response = new ResponseStatus(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return response;
        }

        public async Task<ResponseStatus> DeleteStudent(string id)
        {
            var response = new ResponseStatus();
            try
            {
                using IDbConnection _context = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                string query = StudentQuery.DeleteStudentQuery();

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                int result = await _context.ExecuteAsync(query, parameters);

                response = result > 0
                    ? new ResponseStatus(StatusCodes.Status200OK, "Success")
                    : new ResponseStatus(StatusCodes.Status500InternalServerError, "Failed");
            }
            catch(Exception e)
            {
                response = new ResponseStatus(StatusCodes.Status500InternalServerError, e.Message);
            }
            return response;
        }

        public async Task<ResponseStatus> GetStudentList()
        {
            using IDbConnection _context = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = StudentQuery.GetStudentListQuery();
            IEnumerable<Models.Student> students = await _context.QueryAsync<Models.Student>(query);

            return new ResponseStatus(StatusCodes.Status200OK, "Success", students);
        }

        public async Task<ResponseStatus> GetStudentDetail(string id)
        {
            using IDbConnection _context = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = StudentQuery.GetStudentDetailQuery();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            Models.Student student = await _context.QueryFirstOrDefaultAsync<Models.Student>(query,parameters);

            if (student is null)
                return new ResponseStatus(StatusCodes.Status400BadRequest, "Student Not Found");

            return new ResponseStatus(StatusCodes.Status200OK, "Success", student);
        }
    }
}
