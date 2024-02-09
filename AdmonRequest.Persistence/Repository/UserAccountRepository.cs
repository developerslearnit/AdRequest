using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdmonRequest.Persistence.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AppDbContext _context;

        public UserAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangePassword(Guid staffId, string password, DateTime lastPasswordChangeDate)
        {
            var staff = await FindStaffById(staffId);

            if (staff != null)
            {
                staff.Password = password;
                staff.LastPasswordChangeDate = lastPasswordChangeDate;
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public IQueryable<UserAccountModel> FindAllUsers()
        {
            return _context.StaffRecords.AsNoTracking()
             .Select(x => new UserAccountModel
             {
                 Username = x.Username.Trim(),
                 LastLoginDate = x.LastLoginDate,
                 StaffCode = x.StaffCode.Trim(),
                 StaffId = x.StaffId,
                 StaffName = x.StaffName.Trim(),
                 Role =x.Role.Trim(),
                 Email =x.Email.Trim(),
                 ActiveStatus =x.ActiveStatus,
                 ApprovalStage =x.ApprovalStage,                 
             });
        }

        public async Task<UserAccountModel> FindUserByStaffCode(string userName)
        {
            return await _context.StaffRecords.AsNoTracking().Where(x => x.StaffCode == userName)
                .Select(x => new UserAccountModel
                {
                    Username = x.Username,

                    LastLoginDate = x.LastLoginDate,
                    Password = x.Password,
                    PasswordSalt = x.PasswordSalt,
                    StaffCode = x.StaffCode,
                    StaffId = x.StaffId,
                    StaffName = x.StaffName,
                    LastPasswordChangeDate = x.LastPasswordChangeDate,
                    Email = x.Email,
                    Role = x.Role,
                    ActiveStatus = x.ActiveStatus,
                    ApprovalStage = x.ApprovalStage,

                }).FirstOrDefaultAsync();
        }

        public async Task<UserAccountModel> FindUserByUserName(string userName)
        {
            return await _context.StaffRecords.AsNoTracking().Where(x => x.Username == userName)
              .Select(x => new UserAccountModel
              {
                  Username = x.Username,
                  LastLoginDate = x.LastLoginDate,
                  Password = x.Password,
                  PasswordSalt = x.PasswordSalt,
                  StaffCode = x.StaffCode,
                  StaffId = x.StaffId,
                  StaffName = x.StaffName,
                  LastPasswordChangeDate = x.LastPasswordChangeDate,
                  Email = x.Email,
                  Role =x.Role,
                  ActiveStatus = x.ActiveStatus,
                  ApprovalStage = x.ApprovalStage,
              }).FirstOrDefaultAsync();
        }

        public async Task<bool> GenerateDefualtPassword(Guid staffId, string password, string passwordSalt)
        {
            var targetUser = await _context.StaffRecords.FindAsync(staffId);
            if (targetUser != null)
            {
                targetUser.PasswordSalt = passwordSalt;
                targetUser.Password = password;
               await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> UpdateUser(UserAccountModel model)
        {
            var user = await _context.StaffRecords.FindAsync(model.StaffId);
            if (user != null)
            {
                user.Email = model.Email;
                user.ActiveStatus = model.ActiveStatus;
                user.Role = model.Role;
                user.ApprovalStage = model.ApprovalStage;

                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> UpdateUserLastLoginDate(Guid staffId)
        {
            var staff = await FindStaffById(staffId);

            if (staff != null)
            {
                staff.LastLoginDate = DateTime.Now;
               await  _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> UpdateUserLastPasswordChangeDate(Guid staffId)
        {
            var staff = await FindStaffById(staffId);

            if (staff != null)
            {
                staff.LastPasswordChangeDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return true;
        }

        async Task<StaffRecord> FindStaffById(Guid staffId)
        {
            return await _context.StaffRecords.FindAsync(staffId);
        }

    }
}
