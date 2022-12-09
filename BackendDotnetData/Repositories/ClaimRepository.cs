using BackendDotnetModel;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDotnetData.Repositories
{
    internal class ClaimRepository : IClaimRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public ClaimRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Claim>> GetAllClaims()
        {
            var db = dbConnection();
            var sql = @" SELECT *
            FROM Claims ";
            return await db.QueryAsync<Claim>(sql, new { });
        }

        public async Task<Claim> GetClaimDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT id_Claim, description, status, date, vehicle_Id
            FROM Claims
            WHERE id_Claim = @Id_Claim ";
            return await db.QueryFirstOrDefaultAsync<Claim>(sql, new { Id = id });
        }

        public async Task<bool> InsertClaim(Claim claim)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO Claims(id_Claim, description, status, date, vehicle_Id)
            VALUES(@Id_Claim, @Description, @Status, @Date, @Vehicle_Id) ";
            var result = await db.ExecuteAsync(sql, new
            { claim.Id_Claim, claim.Description, claim.Status, claim.Date, claim.Vehicle_Id });
            return result > 0;
        }
    }
}
