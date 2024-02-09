using AdmonRequest.Application.Models;

namespace AdmonRequest.Application.Interfaces
{
    public interface IUserAccountService
    {
        Task<UserAccountModel> FindUserByUserName(string userName);
        Task<UserAccountModel> FindUserByStaffCode(string userName);
        Task<bool> UpdateUserLastPasswordChangeDate(Guid staffId);
        Task<bool> UpdateUserLastLoginDate(Guid staffId);
        IQueryable<UserAccountModel> FindAllUsers();
        Task<bool> ChangePassword(Guid staffId,string password,DateTime lastPasswordChangeDate);

        Task<bool> GenerateDefualtPassword(Guid staffId, string password, string passwordSalt);

        Task<bool> UpdateUser(UserAccountModel model);
    
    }
}
