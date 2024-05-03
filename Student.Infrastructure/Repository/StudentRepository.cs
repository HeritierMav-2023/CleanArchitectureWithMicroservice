using Dapper;
using Microsoft.Extensions.Options;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Infrastructure.DbContext;
using System.Data.SqlClient;
using System.Data;

namespace Student.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        //1-propriéte connexion BD
        private DapperContext _config;

        #region Constructeur DI
        public StudentRepository(IOptions<DapperContext> configuration)
        {
            _config = configuration.Value;
        }
        #endregion

        #region Methods
        public async Task<string> CreateAsync(Students student)
        {
            try
            {
                string sQuery = "GetStudentDetails";
                var dateAdded = DateTime.Now;

                using var connection = new SqlConnection(_config.DefaultConnection);
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Action", "Post");
                dynamicParameters.Add("@Id", student.Id);
                dynamicParameters.Add("@Name", student.Name);
                dynamicParameters.Add("@Gender", student.Gender);
                dynamicParameters.Add("@ContactNo", student.ContactNo);
                dynamicParameters.Add("@Faculty", student.Faculty);
                dynamicParameters.Add("@DateAdded", dateAdded);
                dynamicParameters.Add("@DateUpdated", null);
             
                var result= await connection.ExecuteAsync(sQuery, dynamicParameters, commandType: CommandType.StoredProcedure);
                string affiche = "Not Created ";
                if(result> 0)
                {
                    affiche = "Student Created !!";
                }

                return affiche ;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task DeleteAsync(Students student)
        {
            try
            {
                string sQuery = "GetStudentDetails";
                var dateDel = DateTime.Now;
                using var connection = new SqlConnection(_config.DefaultConnection);
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Action", "Delete");
                dynamicParameters.Add("@Id", student.Id);
                await connection.ExecuteAsync(sQuery, dynamicParameters, commandType: CommandType.StoredProcedure);
                //return Task.CompletedTask;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task< List<Students>> GetAllAsync()
        {
            try
            {
                using var con = new SqlConnection(_config.DefaultConnection);
                var param = new DynamicParameters();
                string Query = "GetStudentDetails";
                param.Add("@Action", "GetAll");
                var result = await con.QueryAsync<Students>(Query, param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Students> GetbyIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_config.DefaultConnection);
                var param = new DynamicParameters();
                string sQuery = "GetStudentDetails";
                param.Add("@Action", "GetData");
                param.Add("@ID", id);
                var result = await con.QueryAsync<Students>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<string> UpdateAsync(Students student, int id)
        {
            try
            {
                if(id  != student.Id)
                {
                    return $"Student ID {id} n'existe pas en base de donnée";
                }
                string sQuery = "GetStudentDetails";
                var dateUpd = DateTime.Now;

                using var connection = new SqlConnection(_config.DefaultConnection);
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Action", "Put");
                dynamicParameters.Add("@Id", student.Id);
                dynamicParameters.Add("@Name", student.Name);
                dynamicParameters.Add("@Gender", student.Gender);
                dynamicParameters.Add("@ContactNo", student.ContactNo);
                dynamicParameters.Add("@Faculty", student.Faculty);
                dynamicParameters.Add("@DateAdded", null);
                dynamicParameters.Add("@DateUpdated", dateUpd);
           
                var result = await connection.ExecuteAsync(sQuery, dynamicParameters, commandType: CommandType.StoredProcedure);

                return result.ToString();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
        #endregion
    }
}
