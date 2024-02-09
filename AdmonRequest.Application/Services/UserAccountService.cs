using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;

namespace AdmonRequest.Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepo;

        public UserAccountService(IUserAccountRepository userAccountRepo)
        {
            _userAccountRepo = userAccountRepo;
        }
        
        public async Task<bool> ChangePassword(Guid staffId, string password, DateTime lastPasswordChangeDate)
        {
            return await _userAccountRepo.ChangePassword(staffId, password, lastPasswordChangeDate);
        }

        public IQueryable<UserAccountModel> FindAllUsers()
        {
            return _userAccountRepo.FindAllUsers();
        }

        public async Task<UserAccountModel> FindUserByStaffCode(string userName)
        {
            return await _userAccountRepo.FindUserByStaffCode(userName);
        }

        public async Task<UserAccountModel> FindUserByUserName(string userName)
        {
           return await _userAccountRepo.FindUserByUserName(userName);
        }

        public async Task<bool> GenerateDefualtPassword(Guid staffId, string password, string passwordSalt)
        {
            return await _userAccountRepo.GenerateDefualtPassword(staffId,password,passwordSalt);
        }

        public async Task<bool> UpdateUser(UserAccountModel model)
        {
            return await _userAccountRepo.UpdateUser(model);
        }

        public async Task<bool> UpdateUserLastLoginDate(Guid staffId)
        {
            return await _userAccountRepo.UpdateUserLastLoginDate(staffId);
        }

        public async Task<bool> UpdateUserLastPasswordChangeDate(Guid staffId)
        {
            return await _userAccountRepo.UpdateUserLastPasswordChangeDate(staffId);
        }
    }
}
