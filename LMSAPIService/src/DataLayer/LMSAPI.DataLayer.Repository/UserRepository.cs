using LMSAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LMSAPI.DataLayer
{
    public class UserRepository : IUserRepository
    {
        private ILMSContext _context;
        //private ILogger _logger;

        public UserRepository(ILMSContext dbcontext)//, ILogger logger)
        {
            _context = dbcontext;
            // _logger = logger;
        }
        public async Task<UserMasterEntity> GetUserInformation(string userName, string password)
        {
            var userMasterEntity = await _context.UserMaster
                      .Where(x => x.SUserName == userName && x.SPassword == password)
                      .FirstOrDefaultAsync().ConfigureAwait(false);

            return userMasterEntity;

        }

        
    }
}
