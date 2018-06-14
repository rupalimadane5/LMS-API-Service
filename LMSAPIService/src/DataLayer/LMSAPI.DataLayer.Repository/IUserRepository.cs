using LMSAPI.Models.Entity;
using System.Threading.Tasks;

namespace LMSAPI.DataLayer
{
    public interface IUserRepository
    {
        Task<UserMasterEntity> GetUserInformation(string userName, string password);
    }
}
