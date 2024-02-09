using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using AdmonRequest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdmonRequest.Persistence.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddNewEmailNotification(EmailWorkerModel emailWorker)
        {
            var emailNotification = new EmailWorker()
            {
                Body = emailWorker.Body,
                DueDate = DateTime.Now,
                FromAddress = emailWorker.FromAddress,
                ToAddress = emailWorker.ToAddress,
                SentStatus = 0,
                Subject = emailWorker.Subject,
            };

            await _context.AddAsync(emailNotification);
            await _context.SaveChangesAsync();
            return emailNotification.EmailWorkerId;
        }

        public IQueryable<EmailWorkerModel> FetchAllNotifications() => _context.EmailWorkers.AsNoTracking()
                .Select(x => new EmailWorkerModel
                {
                    Body = x.Body,
                    EmailWorkerId = x.EmailWorkerId,
                    FromAddress = x.FromAddress,
                    ToAddress = x.ToAddress,
                    SentStatus = x.SentStatus,
                    Subject = x.Subject
                });

        public async Task<bool> UpdateNotification(Guid id)
        {
            var notification = await _context.EmailWorkers.FindAsync(id);
            if(notification == null) return false;

            notification.SentStatus = 1;
            notification.DateSent = DateTime.Now;
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
