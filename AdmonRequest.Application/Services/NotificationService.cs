using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;


namespace AdmonRequest.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Guid> AddNewEmailNotification(EmailWorkerModel emailWorker)
        {
            return await _notificationRepository.AddNewEmailNotification(emailWorker);
        }

        public IQueryable<EmailWorkerModel> FetchAllNotifications()
        {
            return _notificationRepository.FetchAllNotifications();
        }

        public async Task<bool> UpdateNotification(Guid id)
        {
            return await _notificationRepository.UpdateNotification(id);
        }
    }
}
