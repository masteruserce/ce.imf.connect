using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Mapper
{
    public static class PolicyLoginDetailsMapper
    {
        public static PolicyLoginDetailsDto ToDto(this PolicyLoginDetails entity)
        {
            return new PolicyLoginDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                PrincipalCoLoginDate = entity.PrincipalCoLoginDate,
                PolicyNumber = entity.PolicyNumber,
                IssueDate = entity.IssueDate,
                PolicyStatus = entity.PolicyStatus,
                WorkFlowStatus = entity.WorkFlowStatus,
                PlvcStatus = entity.PlvcStatus,
                PaidToDate = entity.PaidToDate,
                PlvcDescription = entity.PlvcDescription,
                PolicyType = entity.PolicyType
            };
        }

        public static PolicyLoginDetails ToEntity(this PolicyLoginDetailsDto dto)
        {
            return new PolicyLoginDetails
            {
                Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                PrincipalCoLoginDate = dto.PrincipalCoLoginDate,
                PolicyNumber = dto.PolicyNumber,
                IssueDate = dto.IssueDate,
                PolicyStatus = dto.PolicyStatus,
                WorkFlowStatus = dto.WorkFlowStatus,
                PlvcStatus = dto.PlvcStatus,
                PaidToDate = dto.PaidToDate,
                PlvcDescription = dto.PlvcDescription,
                PolicyType = dto.PolicyType
            };
        }
    }

}
