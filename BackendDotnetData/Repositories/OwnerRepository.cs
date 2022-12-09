using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendDotnetModel;
using Dapper;
using MySql.Data.MySqlClient;

namespace BackendDotnetData.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public OwnerRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            var db = dbConnection();
            var sql = @" SELECT id_Owner, firstName, lastName, driverLicense
            FROM Owners ";
            return await db.QueryAsync<Owner>(sql, new { });
        }
        public async Task<Owner> GetOwnerDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT id_Owner, firstName, lastName, driverLicense
            FROM Owners
            WHERE id_Owner = @Id_Owner ";
            return await db.QueryFirstOrDefaultAsync<Owner>(sql, new { Id_Owner = id });
        }
        public async Task<bool> InsertOwner(Owner owner)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO Owners(id_Owner, firstName, lastName, driverLicense)
            VALUES(@Id_Owner, @FirstName, @LastName, @DriverLicense) ";
            var result = await db.ExecuteAsync(sql, new
            { owner.Id_Owner, owner.FirstName, owner.LastName, owner.DriverLicense });
            return result > 0;
        }
    }
}
