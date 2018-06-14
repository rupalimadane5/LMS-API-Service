using LMSAPI.DataLayer;
using LMSAPI.Mappers.EntityToDomain;
using LMSAPI.Models.Domain;
using System.Threading.Tasks;

namespace LMSAPI.BusinessLayer
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserMasterDomain> GetUserInformation(string userName, string password)
        {
            var userMasterEntity = await _userRepository.GetUserInformation(userName, password)
                 .ConfigureAwait(false);
            if (userMasterEntity == null)
            {
                return null;
            }

            return userMasterEntity.ToDomain();
        }
    }
}
