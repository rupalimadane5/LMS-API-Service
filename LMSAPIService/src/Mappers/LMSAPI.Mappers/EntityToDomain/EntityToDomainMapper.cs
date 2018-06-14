using AutoMapper;
using LMSAPI.Models.Domain;
using LMSAPI.Models.Entity;
using System.Collections.Generic;

namespace LMSAPI.Mappers.EntityToDomain
{
    public static class EntityToDomainMapper
    {
        private static IMapper _mapper = ConfigMapper();

        public static IMapper ConfigMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserMasterEntity, UserMasterDomain>()
                    .ForMember(dest => dest.UserId, m => m.MapFrom(src => src.PkUser))
                    .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.SUserName))
                    .ForMember(dest => dest.Password, m => m.MapFrom(src => src.SPassword))
                    .ForMember(dest => dest.Active, m => m.MapFrom(src => src.BActive))
                    .ForMember(dest => dest.AddedDate, m => m.MapFrom(src => src.DtAdded))
                    .ForMember(dest => dest.AddedBy, m => m.MapFrom(src => src.SAddedBy))
                    .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(src => src.DtUpdated))
                    .ForMember(dest => dest.UpdatedBy, m => m.MapFrom(src => src.SUpdatedBy))
                    ;

                    cfg.CreateMap<LeaveBalanceEntity, LeaveBalanceDomain>()
                    .ForMember(dest => dest.LeaveBalanceId, m => m.MapFrom(src => src.PkLeaveBalance))
                    .ForMember(dest => dest.LeaveTypeId, m => m.MapFrom(src => src.FkLeaveType))
                    .ForMember(dest => dest.UserId, m => m.MapFrom(src => src.FkUser))
                    .ForMember(dest => dest.YearId, m => m.MapFrom(src => src.FkYear))
                    .ForMember(dest => dest.LeaveCredit, m => m.MapFrom(src => src.NLeaveCredit))
                    .ForMember(dest => dest.LeaveConsumed, m => m.MapFrom(src => src.NLeaveConsumed))
                    .ForMember(dest => dest.LeaveBalanceId, m => m.MapFrom(src => src.NLeaveBalance))
                    .ForMember(dest => dest.Active, m => m.MapFrom(src => src.BActive))
                    .ForMember(dest => dest.AddedDate, m => m.MapFrom(src => src.DtAdded))
                    .ForMember(dest => dest.AddedBy, m => m.MapFrom(src => src.SAddedBy))
                    .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(src => src.DtUpdated))
                    .ForMember(dest => dest.UpdatedBy, m => m.MapFrom(src => src.SUpdatedBy))
                    ;

                    cfg.CreateMap<LeaveStatusMasterEntity, LeaveStatusMasterDomain>()
                   .ForMember(dest => dest.LeaveStatusId, m => m.MapFrom(src => src.PkLeaveStatus))
                   .ForMember(dest => dest.LeaveStatus, m => m.MapFrom(src => src.SLeaveStatus))
                   .ForMember(dest => dest.Active, m => m.MapFrom(src => src.BActive))
                   .ForMember(dest => dest.AddedDate, m => m.MapFrom(src => src.DtAdded))
                   .ForMember(dest => dest.AddedBy, m => m.MapFrom(src => src.SAddedBy))
                   .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(src => src.DtUpdated))
                   .ForMember(dest => dest.UpdatedBy, m => m.MapFrom(src => src.SUpdatedBy))
                   ;

                    cfg.CreateMap<LeaveTypeMasterEntity, LeaveTypeMasterDomain>()
                    .ForMember(dest => dest.LeaveTypeId, m => m.MapFrom(src => src.PkLeaveType))
                    .ForMember(dest => dest.LeaveType, m => m.MapFrom(src => src.SLeaveType))
                    .ForMember(dest => dest.Active, m => m.MapFrom(src => src.BActive))
                    .ForMember(dest => dest.AddedDate, m => m.MapFrom(src => src.DtAdded))
                    .ForMember(dest => dest.AddedBy, m => m.MapFrom(src => src.SAddedBy))
                    .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(src => src.DtUpdated))
                    .ForMember(dest => dest.UpdatedBy, m => m.MapFrom(src => src.SUpdatedBy))
                    ;

                    cfg.CreateMap<ManageLeaveTransactionEntity, ManageLeaveTransactionDomain>()
                   .ForMember(dest => dest.ManageleaveId, m => m.MapFrom(src => src.PkManageleave))
                   .ForMember(dest => dest.UserId, m => m.MapFrom(src => src.FkUser))
                   .ForMember(dest => dest.YearId, m => m.MapFrom(src => src.FkYear))
                   .ForMember(dest => dest.LeaveFrom, m => m.MapFrom(src => src.DtLeaveFrom))
                   .ForMember(dest => dest.leaveTo, m => m.MapFrom(src => src.DtleaveTo))
                   .ForMember(dest => dest.LeaveStatus, m => m.MapFrom(src => src.FkLeaveStatus))
                   .ForMember(dest => dest.ApprovedBy, m => m.MapFrom(src => src.SApprovedBy))
                   .ForMember(dest => dest.Active, m => m.MapFrom(src => src.BActive))
                   .ForMember(dest => dest.LeaveType, m => m.MapFrom(src => src.FkLeaveType))
                   .ForMember(dest => dest.LeaveDaysCount, m => m.MapFrom(src => src.LeaveDaysCount))
                   .ForMember(dest => dest.LeaveReason, m => m.MapFrom(src => src.LeaveReason))
                   .ForMember(dest => dest.AddedDate, m => m.MapFrom(src => src.DtAdded))
                   .ForMember(dest => dest.AddedBy, m => m.MapFrom(src => src.SAddedBy))
                   .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(src => src.DtUpdated))
                   .ForMember(dest => dest.UpdatedBy, m => m.MapFrom(src => src.SUpdatedBy))
                   ;

                   cfg.CreateMap<ManageLeaveTransactionDomain, ManageLeaveTransactionEntity>()
                  .ForMember(dest => dest.PkManageleave, m => m.MapFrom(src => src.ManageleaveId))
                  .ForMember(dest => dest.FkUser, m => m.MapFrom(src => src.UserId))
                  .ForMember(dest => dest.FkYear, m => m.MapFrom(src => src.YearId))
                  .ForMember(dest => dest.DtLeaveFrom, m => m.MapFrom(src => src.LeaveFrom))
                  .ForMember(dest => dest.DtleaveTo, m => m.MapFrom(src => src.leaveTo))
                  .ForMember(dest => dest.FkLeaveStatus, m => m.MapFrom(src => src.LeaveStatus))
                  .ForMember(dest => dest.SApprovedBy, m => m.MapFrom(src => src.ApprovedBy))
                  .ForMember(dest => dest.BActive, m => m.MapFrom(src => src.Active))
                  .ForMember(dest => dest.FkLeaveType, m => m.MapFrom(src => src.LeaveType))
                  .ForMember(dest => dest.LeaveDaysCount, m => m.MapFrom(src => src.LeaveDaysCount))
                  .ForMember(dest => dest.LeaveReason, m => m.MapFrom(src => src.LeaveReason))
                  .ForMember(dest => dest.DtAdded, m => m.MapFrom(src => src.AddedDate))
                  .ForMember(dest => dest.SAddedBy, m => m.MapFrom(src => src.AddedBy))
                  .ForMember(dest => dest.DtUpdated, m => m.MapFrom(src => src.UpdatedDate))
                  .ForMember(dest => dest.SUpdatedBy, m => m.MapFrom(src => src.UpdatedBy))
                  ;

                    cfg.CreateMap<YearMasterEntity, YearMasterDomain>()
                 .ForMember(dest => dest.YearId, m => m.MapFrom(src => src.PkYear))
                 .ForMember(dest => dest.YearCode, m => m.MapFrom(src => src.SYearCode))
                 .ForMember(dest => dest.YearStart, m => m.MapFrom(src => src.SYearStart))
                 .ForMember(dest => dest.YearEnd, m => m.MapFrom(src => src.SYearEnd))
                 .ForMember(dest => dest.Active, m => m.MapFrom(src => src.BActive))
                 .ForMember(dest => dest.AddedDate, m => m.MapFrom(src => src.DtAdded))
                 .ForMember(dest => dest.AddedBy, m => m.MapFrom(src => src.SAddedBy))
                 .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(src => src.DtUpdated))
                 .ForMember(dest => dest.UpdatedBy, m => m.MapFrom(src => src.SUpdatedBy))
                 ;

                  cfg.CreateMap<LeaveDetailsEntity, LeaveDetailsDomain>()
                 .ForMember(dest => dest.ManageleaveId, m => m.MapFrom(src => src.PkManageleave))
                 .ForMember(dest => dest.LeaveReason, m => m.MapFrom(src => src.SLeaveReason))
                 .ForMember(dest => dest.LeaveType, m => m.MapFrom(src => src.SLeaveType))
                 .ForMember(dest => dest.LeaveStatus, m => m.MapFrom(src => src.SLeaveStatus))
                 .ForMember(dest => dest.LeaveDaysCount, m => m.MapFrom(src => src.LeaveDaysCount))
                 .ForMember(dest => dest.LeaveFrom, m => m.MapFrom(src => src.DtLeaveFrom))
                 .ForMember(dest => dest.LeaveTo, m => m.MapFrom(src => src.DtleaveTo))
                 ;


                });
            return _mapper = config.CreateMapper();
        }


        public static UserMasterDomain ToDomain(this UserMasterEntity userMasterEntity)
        {
            return _mapper.Map<UserMasterEntity, UserMasterDomain>(userMasterEntity);
        }

        public static LeaveBalanceDomain ToDomain(this LeaveBalanceEntity leaveBalanceEntity)
        {
            return _mapper.Map<LeaveBalanceEntity, LeaveBalanceDomain>(leaveBalanceEntity);
        }

        public static LeaveStatusMasterDomain ToDomain(this LeaveStatusMasterEntity leaveStatusEntity)
        {
            return _mapper.Map<LeaveStatusMasterEntity, LeaveStatusMasterDomain>(leaveStatusEntity);
        }

        public static List<LeaveTypeMasterDomain> ToDomain(this List<LeaveTypeMasterEntity> leaveTypeEntity)
        {
            return _mapper.Map<List<LeaveTypeMasterEntity>, List<LeaveTypeMasterDomain>>(leaveTypeEntity);
        }

        public static ManageLeaveTransactionDomain ToDomain(this ManageLeaveTransactionEntity manageLeaveTransactionEntity)
        {
            return _mapper.Map<ManageLeaveTransactionEntity, ManageLeaveTransactionDomain>(manageLeaveTransactionEntity);
        }
        public static ManageLeaveTransactionEntity ToEntity(this ManageLeaveTransactionDomain manageLeaveTransactionDomain)
        {
            return _mapper.Map<ManageLeaveTransactionDomain, ManageLeaveTransactionEntity>(manageLeaveTransactionDomain);
        }

        public static YearMasterDomain ToDomain(this YearMasterEntity yearMasterEntity)
        {
            return _mapper.Map<YearMasterEntity, YearMasterDomain>(yearMasterEntity);
        }

        public static List<LeaveDetailsDomain> ToDomain(this List<LeaveDetailsEntity> leaveDetailsEntity)
        {
            return _mapper.Map<List<LeaveDetailsEntity>, List<LeaveDetailsDomain>>(leaveDetailsEntity);
        }


    }
}
