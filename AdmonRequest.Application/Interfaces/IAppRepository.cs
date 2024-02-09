using AdmonRequest.Application.Models;

namespace AdmonRequest.Application.Interfaces
{
    public interface IAppRepository
    {
        IQueryable<RequestTypeModel> FetchRequestTypes();
        Task<bool> AddNewRequestType(RequestTypeModel requestType);

        IQueryable<SelectModel> FetchDepartment();
        IQueryable<SelectModel> FetchSubUnit(Guid deptId);
        IQueryable<SelectModel> FetchBudgetCategory();
        IQueryable<SelectModel> FetchBudgetYear();
        IQueryable<SelectModel> FetchBudgetPeriod(Guid yearId);
        IQueryable<SelectModel> FetchVoteType();
        IQueryable<SelectModel> FetchBeneficiary();
        IQueryable<PaymentRequestViewModel> FetchAllPaymentRequest();
        IQueryable<BudgetDetailsModel> FetchAllBudgetDetails();
        Task<Tuple<bool, Guid>> AddNewPaymentRequest(PaymentRequestModel model);
        Task<bool> ApproveOrDisaproveRequest(Guid requestId, Guid approvalStatus,string comment);
        RequestAttachmentModel FetchRequestAttachment(Guid requestId);
        IQueryable<RequestAttachmentModel> FetchRequestAttachments();
        Task<bool> AddRequestDocument(RequestAttachmentModel requestAttachment);
        IQueryable<SelectModel> FetchApprovalLevel();
        IQueryable<ApprovalStageModel> FetchAllApprovalStages();
        IQueryable<PersonRegistrationModel> FetchAllPersonRegistration(Int32 personType);
        Task<bool> AddNewPersonRegistration(PersonRegistrationModel personRegistration);
    }
}
