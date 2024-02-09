using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using AdmonRequest.Domain.Entities;
using Azure.Core;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using static AdmonRequest.Application.Constants.AppConstants;

namespace AdmonRequest.Persistence.Repository
{
    public class AppRepository : IAppRepository
    {
        private readonly AppDbContext _context;

        public AppRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tuple<bool, Guid>> AddNewPaymentRequest(PaymentRequestModel model)
        {
            try
            {
                if (model.PaymentRequestId == Guid.Empty)
                {
                    var newPaymentRequest = new PaymentRequest()
                    {
                        StaffId = model.StaffId,
                        RequestTypeId = model.RequestTypeId,
                        DepartmentSubUnitId = model.DepartmentSubUnitId,
                        RequestDate = model.RequestDate,
                        BeneficiaryName = model.BeneficiaryName,
                        RefNo = model.RefNo,
                        BudgetCategoryId = model.BudgetCategoryId,
                        BudgetPeriodId = model.BudgetPeriodId,
                        VoteType = model.VoteType,
                        Amount = model.Amount,
                        Description = model.Description,
                        ApprovalStatus = model.ApprovalStatus,
                        IsSyncronized = false,
                        DateCreated = DateTime.UtcNow,
                        CreatedBy = model.CreatedBy,
                        ApprovalLevel = model.ApprovalLevel
                    };

                    await _context.AddAsync(newPaymentRequest);

                    await _context.SaveChangesAsync();

                    return Tuple.Create(true, newPaymentRequest.PaymentRequestId);

                }
                else
                {
                    var targetRequest = await _context.PaymentRequests.FindAsync(model.PaymentRequestId);
                    if (targetRequest != null)
                    {
                        targetRequest.StaffId = model.StaffId;
                        targetRequest.RequestTypeId = model.RequestTypeId;
                        targetRequest.DepartmentSubUnitId = model.DepartmentSubUnitId;
                        targetRequest.BeneficiaryName = model.BeneficiaryName;
                        targetRequest.BudgetCategoryId = model.BudgetCategoryId;
                        targetRequest.BudgetPeriodId = model.BudgetPeriodId;
                        targetRequest.VoteType = model.VoteType;
                        targetRequest.Amount = model.Amount;
                        targetRequest.Description = model.Description;
                        await _context.SaveChangesAsync();
                    }

                    return Tuple.Create(true, model.PaymentRequestId);

                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<bool> AddNewRequestType(RequestTypeModel requestType)
        {

            if (requestType.RequestTypeId == Guid.Empty)
            {
                var newRequest = new RequestType()
                {
                    ActiveStatus = requestType.Status,
                    IsAdvance = requestType.IsAdvance,
                    IsDirectPayment = requestType.IsDirectPayment,
                    IsProject = requestType.IsProject,
                    ReduceBuget = requestType.ReduceBuget,
                    RequestTypeName = requestType.Name
                };
                await _context.AddAsync(newRequest);

                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                var targetRequest = _context.RequestTypes.Find(requestType.RequestTypeId);

                if (targetRequest != null)
                {
                    targetRequest.ActiveStatus = requestType.Status;
                    targetRequest.IsAdvance = requestType.IsAdvance;
                    targetRequest.IsDirectPayment = requestType.IsDirectPayment;
                    targetRequest.IsProject = requestType.IsProject;
                    targetRequest.ReduceBuget = requestType.ReduceBuget;
                    targetRequest.RequestTypeName = requestType.Name;
                    _context.SaveChanges();
                }

                return true;
            }



        }

        public async Task<bool> AddRequestDocument(RequestAttachmentModel requestAttachment)
        {
            try
            {
                var existingDocs = await _context.RequestAttachments.FirstOrDefaultAsync(x => x.PaymentRequestId == requestAttachment.PaymentRequestId);


                if (existingDocs != null)
                {
                    existingDocs.Attachment = requestAttachment.Attachment;
                    existingDocs.FileExt = requestAttachment.FileExt;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var newAttachent = new RequestAttachment()
                    {
                        Attachment = requestAttachment.Attachment,
                        FileExt = requestAttachment.FileExt,
                        PaymentRequestId = requestAttachment.PaymentRequestId
                    };

                    await _context.RequestAttachments.AddAsync(newAttachent);

                    return await _context.SaveChangesAsync() > 0;

                }


            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> ApproveOrDisaproveRequest(Guid requestId, Guid approvalStatus, string comment)
        {

            var targetRequest = await _context.PaymentRequests.FindAsync(requestId);
            var approvalStages = _context.ApprovalStages;

            if (targetRequest != null)
            {
                var approvalStage = approvalStages.FirstOrDefault(x => x.ApprovalStageId == targetRequest.ApprovalLevel);

                if (approvalStage != null)
                {
                    if (approvalStage.IsFinal)
                    {
                        targetRequest.ApprovalStatus = approvalStatus;
                    }
                    else
                    {
                        var nextLevelComputation = approvalStage.Level + 1;
                        var nextApproval = approvalStages.FirstOrDefault(x => x.Level == nextLevelComputation);
                        if (nextApproval != null)
                        {
                            var approvalID = nextApproval.ApprovalStageId;
                            targetRequest.ApprovalLevel = approvalID;
                        }
                    }

                    await _context.SaveChangesAsync();

                    return true;
                }

            }

            return true;

        }

        public IQueryable<ApprovalStageModel> FetchAllApprovalStages()
        {
            return _context.ApprovalStages.AsNoTracking()
                .OrderBy(x => x.Level)
                .Select(x => new ApprovalStageModel()
                {
                    ApprovalStageId = x.ApprovalStageId,
                    IsFinal = x.IsFinal,
                    Level = x.Level,
                    StageName = x.StageName,
                });
        }

        public IQueryable<BudgetDetailsModel> FetchAllBudgetDetails()
        {
            return _context.BudgetDetails.AsNoTracking()
                .Select(x => new BudgetDetailsModel
                {
                    BudgetDetailPeriodID = x.BudgetDetailPeriodID,
                    BudgetDetailId = x.BudgetDetailId,
                    BudgetCategoryId = x.BudgetCategoryId,
                    DepartmentId = x.DepartmentId,
                    AccountID = x.AccountID,
                    AccountName = x.AccountName,
                    BudgetAmount = x.BudgetAmount,
                    BudgetPeriodId = x.BudgetPeriodId,
                    BudgetMethodId = x.BudgetMethodId,
                    BudgetYearId = x.BudgetYearId,
                    DepartmentSubUnitId = x.DepartmentSubUnitId,
                    ApplicableToUnit = x.ApplicableToUnit,

                });
        }

        public IQueryable<PaymentRequestViewModel> FetchAllPaymentRequest()
        {
            return (from pr in _context.PaymentRequests
                    join rt in _context.RequestTypes
                    on pr.RequestTypeId equals rt.RequestTypeId
                    join dept in _context.DepartmentSubUnits
                    on pr.DepartmentSubUnitId equals dept.DepartmentSubUnitId
                    select new PaymentRequestViewModel
                    {
                        PaymentRequestId = pr.PaymentRequestId,
                        RequestTypeId = pr.RequestTypeId,
                        RequestType = rt.RequestTypeName,
                        DepartmentSubUnitId = dept.DepartmentSubUnitId,
                        SubDepartment = dept.SubUnitName,
                        StaffId = pr.StaffId,
                        Beneficiary = pr.BeneficiaryName,
                        RefNo = pr.RefNo,
                        BudgetCategoryId = pr.BudgetCategoryId,
                        VoteType = pr.VoteType,
                        Amount = pr.Amount,
                        Description = pr.Description,
                        ApprovalStatus = pr.ApprovalStatus,
                        IsSyncronized = pr.IsSyncronized,
                        RequestDate = pr.RequestDate,
                        CreatedBy = pr.CreatedBy,
                        ApprovalStage = pr.ApprovalLevel


                    });
        }

        public IQueryable<SelectModel> FetchApprovalLevel()
        {
            return _context.ApprovalStages.AsNoTracking()
                .OrderBy(x => x.Level)
                .Select(x => new SelectModel
                {
                    Id = x.ApprovalStageId,
                    Name = x.StageName
                });
        }

        public IQueryable<SelectModel> FetchBeneficiary()
        {
            return _context.StaffRecords.AsNoTracking()
                .Select(x => new SelectModel
                {
                    Id = x.StaffId,
                    Name = x.StaffName
                });
        }

        public IQueryable<SelectModel> FetchBudgetCategory()
        {
            return _context.BudgetCategories.AsNoTracking()
                .Select(x => new SelectModel
                {
                    Id = x.BudgetCategoryId,
                    Name = x.BudgetCategoryName
                });
        }

        public IQueryable<SelectModel> FetchBudgetPeriod(Guid yearId)
        {
            return _context.BudgetPeriods.AsNoTracking()
                .Where(x => x.BudgetYearId == yearId)
                .OrderBy(x => x.OrderNo)
                .Select(x => new SelectModel
                {
                    Id = x.BudgetPeriodId,
                    Name = x.BudgetPeriodName
                });
        }

        public IQueryable<SelectModel> FetchBudgetYear()
        {
            return _context.BudgetYears.AsNoTracking()
                .Select(x => new SelectModel
                {
                    Id = x.BudgetYearId,
                    Name = x.BudgetYearName
                });
        }

        public IQueryable<SelectModel> FetchDepartment()
        {
            return _context.Departments.AsNoTracking()
                .Select(x => new SelectModel { Id = x.DepartmentId, Name = x.DepartmentName });
        }

        public RequestAttachmentModel FetchRequestAttachment(Guid requestId)
        {
            return _context.RequestAttachments.AsNoTracking()
                .Where(x => x.PaymentRequestId == requestId)
                .Select(x => new RequestAttachmentModel
                {
                    RequestAttachmentId = x.RequestAttachmentId,
                    Attachment = x.Attachment,
                    FileExt = x.FileExt,
                    PaymentRequestId = x.PaymentRequestId

                }).FirstOrDefault();
        }

        public IQueryable<RequestAttachmentModel> FetchRequestAttachments()
        {
            return _context.RequestAttachments.AsNoTracking()
                .Select(x => new RequestAttachmentModel
                {
                    RequestAttachmentId = x.RequestAttachmentId,
                    Attachment = x.Attachment,
                    FileExt = x.FileExt,
                    PaymentRequestId = x.PaymentRequestId
                });
        }

        public IQueryable<RequestTypeModel> FetchRequestTypes()
        {
            return _context.RequestTypes.AsNoTracking()
                .Select(x => new RequestTypeModel()
                {
                    Status = x.ActiveStatus,
                    IsAdvance = x.IsAdvance,
                    IsDirectPayment = x.IsDirectPayment,
                    IsProject = x.IsProject,
                    ReduceBuget = x.ReduceBuget,
                    Name = x.RequestTypeName,
                    RequestTypeId = x.RequestTypeId
                });
        }

        public IQueryable<SelectModel> FetchSubUnit(Guid deptId)
        {
            return _context.DepartmentSubUnits.AsNoTracking()
                .Where(x => x.DepartmentId == deptId)
                .Select(x => new SelectModel
                {
                    Id = x.DepartmentSubUnitId,
                    Name = x.SubUnitName
                });
        }

        public IQueryable<SelectModel> FetchVoteType()
        {
            return _context.VoteTypes.AsNoTracking()
                .Select(x => new SelectModel
                {
                    Id = x.VoteTypeId,
                    Name = x.VoteTypeName
                });
        }

        public async Task<bool> AddNewPersonRegistration(PersonRegistrationModel personRegistration)
        {
            if (personRegistration.PersonRegistrationId == Guid.Empty)
            {
                var newPersonRegistration = new PersonRegistration()
                {
                   
                };
                await _context.AddAsync(newPersonRegistration);

                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                var targetRequest = _context.PersonRegistrations.Find(personRegistration.PersonRegistrationId);

                if (targetRequest != null)
                {
                   
                    _context.SaveChanges();
                }

                return true;
            }

        }
        public IQueryable<PersonRegistrationModel> FetchAllPersonRegistration(int personType)
        {
            return (from pr in _context.PersonRegistrations
                    join rt in _context.PersonAdditionalInfo
                    on pr.PersonRegistrationId equals rt.PersonRegistrationId
                                      select new PersonRegistrationModel
                                      {
                                          PersonRegistrationId = pr.PersonRegistrationId,
                                          PersonRegistrationNo = pr.PersonRegistrationNo,
                                          PersonName = pr.PersonName,
                                          Email = pr.Email,
                                          Phone = pr.Phone,
                                          Address = pr.Address,
                                          Pictures = pr.Pictures,
                                          RegisterDate = pr.RegisterDate,
                                          Gender = pr.Gender,
                                          Nationality = pr.Nationality,
                                          ContactPerson = pr.ContactPerson,
                                          State = pr.State,
                                          LGA = pr.LGA,
                                          AccountName = pr.AccountName,
                                          BankName = pr.BankName,
                                          AccountNo = pr.AccountNo,
                                          PersonAdditionalInfoId = rt.PersonAdditionalInfoId,
                                          AdditionalInfoTitleName = rt.TitleName,
                                          AdditionalInfoEmail = rt.Email,
                                          AdditionalInfoPhone = rt.Phone,
                                       
                                          AdditionalInfoAddress = rt.Address,
                                          OtherDetails = rt.OtherDetails,



                                      });
        }
    }
}
