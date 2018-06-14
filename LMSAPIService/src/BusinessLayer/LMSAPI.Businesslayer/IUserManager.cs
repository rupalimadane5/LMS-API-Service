using LMSAPI.Models.Domain;
using System.Threading.Tasks;

namespace LMSAPI.BusinessLayer
{
    public interface IUserManager
    {
        Task<UserMasterDomain> GetUserInformation(string userName, string password);
    }
}
