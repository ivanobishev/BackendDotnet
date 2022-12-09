using BackendDotnetModel;

namespace BackendDotnetData.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleDetails(int id);
        Task<bool> InsertVehicle(Vehicle vehicle);
    }
}