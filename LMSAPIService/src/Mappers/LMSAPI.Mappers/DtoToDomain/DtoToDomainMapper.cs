using AutoMapper;
using LMSAPI.Models.Domain;
using LMSAPI.Models.Dto;
using LMSAPI.Models.Dto.Contract;
using System.Collections.Generic;

namespace LMSAPI.Mappers.DtoToDomain
{
    public static class DtoToDomainMapper
    {
        public static IMapper _mapper = ConfigMapper();

        public static IMapper ConfigMapper()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<UserMasterDomain, UserMasterDto>();
                cfg.CreateMap<LeaveBalanceDomain, LeaveBalanceDto>();
                cfg.CreateMap<LeaveStatusMasterDomain, LeaveStatusMasterDto>();
                cfg.CreateMap<LeaveTypeMasterDomain, LeaveTypeMasterDto>();
                cfg.CreateMap<ManageLeaveTransactionDomain, ManageLeaveTransactionDto>();
                cfg.CreateMap<YearMasterDomain, YearMasterDto>();
                cfg.CreateMap<LeaveDetailsDomain, LeaveDetailsDto>();

                cfg.CreateMap<NewLeaveDto, ManageLeaveTransactionDomain>();

            });

            return _mapper = config.CreateMapper();
        }

        public static UserMasterDto ToDto(this UserMasterDomain userDomain)
        {
            return _mapper.Map<UserMasterDomain, UserMasterDto>(userDomain);
        }
        public static LeaveBalanceDto ToDto(this LeaveBalanceDomain leaveBalanceDomain)
        {
            return _mapper.Map<LeaveBalanceDomain, LeaveBalanceDto>(leaveBalanceDomain);
        }
        public static LeaveStatusMasterDto ToDto(this LeaveStatusMasterDomain leaveStatusMasterDomain)
        {
            return _mapper.Map<LeaveStatusMasterDomain, LeaveStatusMasterDto>(leaveStatusMasterDomain);
        }
        public static List<LeaveTypeMasterDto> ToDto(this List<LeaveTypeMasterDomain> leaveTypeMasterDomain)
        {
            return _mapper.Map<List<LeaveTypeMasterDomain>, List<LeaveTypeMasterDto>>(leaveTypeMasterDomain);
        }
        public static ManageLeaveTransactionDto ToDto(this ManageLeaveTransactionDomain manageLeaveTransactionDomain)
        {
            return _mapper.Map<ManageLeaveTransactionDomain, ManageLeaveTransactionDto>(manageLeaveTransactionDomain);
        }
        public static YearMasterDto ToDto(this YearMasterDomain yearMasterDomain)
        {
            return _mapper.Map<YearMasterDomain, YearMasterDto>(yearMasterDomain);
        }
        public static List<LeaveDetailsDto> ToDto(this List<LeaveDetailsDomain> leaveDetailsDomain)
        {
            return _mapper.Map<List<LeaveDetailsDomain>, List<LeaveDetailsDto>>(leaveDetailsDomain);
        }
        public static ManageLeaveTransactionDomain ToDomain(this NewLeaveDto leaveRequest)
        {
            return _mapper.Map<NewLeaveDto, ManageLeaveTransactionDomain>(leaveRequest);
        }
    }
}
