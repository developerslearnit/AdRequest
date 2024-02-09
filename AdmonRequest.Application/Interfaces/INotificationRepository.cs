using AdmonRequest.Application.Models;

namespace AdmonRequest.Application.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<EmailWorkerModel> FetchAllNotifications();
        Task<bool> UpdateNotification(Guid id);
        Task<Guid> AddNewEmailNotification(EmailWorkerModel emailWorker);
    }

    
}
