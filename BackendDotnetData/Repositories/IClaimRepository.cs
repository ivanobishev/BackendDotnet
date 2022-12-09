using BackendDotnetModel;

namespace BackendDotnetData.Repositories
{
    public interface IClaimRepository
    {
        Task<IEnumerable<Claim>> GetAllClaims();
        Task<Claim> GetClaimDetails(int id);
        Task<bool> InsertClaim(Claim claim);
    }
}