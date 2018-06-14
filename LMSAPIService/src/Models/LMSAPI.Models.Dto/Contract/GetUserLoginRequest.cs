using System.ComponentModel.DataAnnotations;

namespace LMSAPI.Models.Dto.Contract
{
    public class GetUserLoginRequest
    {
        [Required (AllowEmptyStrings =false)]
        //[NotNullOrEmpty(Constants.UserNameNotNull)]
        public string UserName { get; set; }
        [Required (AllowEmptyStrings =false)]
        //[NotNullOrEmpty(Constants.PasswordNotNull)]
        public string Password { get; set; }
    }
}
