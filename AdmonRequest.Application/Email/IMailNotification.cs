using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonRequest.Application.Email
{
    public interface IMailNotification
    {
        void QueueEmail(Guid emailId);
    }
}
