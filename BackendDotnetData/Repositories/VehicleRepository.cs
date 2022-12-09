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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public VehicleRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            var db = dbConnection();
            var sql = @" SELECT *
            FROM Vehicles ";
            return await db.QueryAsync<Vehicle>(sql, new { });
        }

        public async Task<Vehicle> GetVehicleDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT id_Vehicle, brand, vin, color, year, owner_Id
            FROM Vehicles
            WHERE id_Vehicle = @Id_Vehicle ";
            return await db.QueryFirstOrDefaultAsync<Vehicle>(sql, new { Id = id });
        }

        public async Task<bool> InsertVehicle(Vehicle vehicle)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO Vehicles(id_Vehicle, brand, vin, color, year, owner_Id)
            VALUES(@Id_Vehicle, @Brand, @Vin, @Color, @Year, @Owner_Id) ";
            var result = await db.ExecuteAsync(sql, new
            { vehicle.Id_Vehicle, vehicle.Brand, vehicle.Vin, vehicle.Color, vehicle.Year, vehicle.Owner_Id });
            return result > 0;
        }
    }
}
