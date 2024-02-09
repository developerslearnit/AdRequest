using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using System.Runtime.CompilerServices;

namespace AdmonRequest.Application.Services
{
    public class AppService : IAppService
    {
        private readonly IAppRepository _appRepository;

        public AppService(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public async Task<Tuple<bool, Guid>> AddNewPaymentRequest(PaymentRequestModel model)
        {
            return await _appRepository.AddNewPaymentRequest(model);
        }

        public async Task<bool> AddNewRequestType(RequestTypeModel requestType)
        {
            return await _appRepository.AddNewRequestType(requestType);
        }

        public async Task<bool> AddRequestDocument(RequestAttachmentModel requestAttachment)
        {
          return await _appRepository.AddRequestDocument(requestAttachment);
        }

        public async Task<bool> ApproveOrDisaproveRequest(Guid requestId, Guid approvalStatus, string comment)
        {
            return await _appRepository.ApproveOrDisaproveRequest(requestId, approvalStatus, comment);
        }

        public IQueryable<ApprovalStageModel> FetchAllApprovalStages()
        {

            //var result = _appRepository.FetchAllApprovalStages();

            return _appRepository.FetchAllApprovalStages();
        }

        public IQueryable<BudgetDetailsModel> FetchAllBudgetDetails()
        {
            return _appRepository.FetchAllBudgetDetails();
        }

        public IQueryable<PaymentRequestViewModel> FetchAllPaymentRequest()
        {
            return _appRepository.FetchAllPaymentRequest();
        }

        public IQueryable<SelectModel> FetchApprovalLevel()
        {
            return _appRepository.FetchApprovalLevel();
        }

        public IQueryable<SelectModel> FetchBeneficiary()
        {
            return _appRepository.FetchBeneficiary();
        }

        public IQueryable<SelectModel> FetchBudgetCategory()
        {
            return (_appRepository.FetchBudgetCategory());
        }

        public IQueryable<SelectModel> FetchBudgetPeriod(Guid yearId)
        {
            return _appRepository.FetchBudgetPeriod(yearId);
        }

        public IQueryable<SelectModel> FetchBudgetYear()
        {
            return _appRepository.FetchBudgetYear();
        }

        public IQueryable<SelectModel> FetchDepartment()
        {
            return _appRepository.FetchDepartment();
        }

        public RequestAttachmentModel FetchRequestAttachment(Guid requestId)
        {
            return _appRepository.FetchRequestAttachment(requestId);
        }

        public IQueryable<RequestAttachmentModel> FetchRequestAttachments()
        {
            return _appRepository.FetchRequestAttachments();
        }

        public IQueryable<RequestTypeModel> FetchRequestTypes()
        {
            return _appRepository.FetchRequestTypes();  
        }

        public IQueryable<SelectModel> FetchSubUnit(Guid deptId)
        {
            return _appRepository.FetchSubUnit(deptId);
        }

        public IQueryable<SelectModel> FetchVoteType()
        {
            return _appRepository.FetchVoteType();
        }

        public async Task<bool> AddNewPersonRegistration(PersonRegistrationModel personRegistration)
        {
            return await _appRepository.AddNewPersonRegistration(personRegistration);
        }
        public IQueryable<PersonRegistrationModel> FetchAllPersonRegistration(int personType)
        {
            return _appRepository.FetchAllPersonRegistration(personType);
        }
    }
}
