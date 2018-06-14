namespace LMSAPI.Models.Dto
{
    public class UserMasterDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
    }
}
