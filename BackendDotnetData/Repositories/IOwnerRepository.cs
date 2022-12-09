using BackendDotnetModel;

namespace BackendDotnetData.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerDetails(int id);
        Task<bool> InsertOwner(Owner owner);
    }
}