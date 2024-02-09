namespace AdmonRequest.Application.Models
{
    public class UserAccountModel
    {
        public Guid StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffCode { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public Guid? ApprovalStage { get; set; }
        public bool ActiveStatus { get; set; }
        public string readAbleStatus { get { return ActiveStatus == true ? "Active" : "Disabled"; } }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
    }
}
