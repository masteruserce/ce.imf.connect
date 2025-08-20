using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Mapper
{
    public static class SourcingDetailsMapper
    {
        public static SourcingDetailsDto ToDto(this SourcingDetails model)
        {
            if (model == null) return null;

            return new SourcingDetailsDto
            {
                Id = model.Id,
                ItemType = model.ItemType,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                IsActive = model.IsActive,
                SourceNumber = model.SourceNumber,
                Fy = model.Fy,
                Year = model.Year,
                LoginMonth = model.LoginMonth,
                PremiumMonth = model.PremiumMonth,
                Location = model.Location,
                Department = model.Department,
                InsuranceHead = model.InsuranceHead,
                BusinessHead = model.BusinessHead,
                Presentator = model.Presentator,
                BusinessPartner = model.BusinessPartner,
                InsuranceCategory = model.InsuranceCategory,
                FreshRenewal = model.FreshRenewal,
                PrincipalCo = model.PrincipalCo,
                PlanType = model.PlanType,
                EmpCode = model.EmpCode,
                ApplicationNo = model.ApplicationNo
            };
        }

        public static SourcingDetails ToModel(this SourcingDetailsDto dto)
        {
            if (dto == null) return null;

            return new SourcingDetails
            {
                Id = dto.Id == null || dto.Id == Guid.Empty  ? Guid.NewGuid() : dto.Id.Value,
                ItemType = dto.ItemType,
                CreatedDate = dto.CreatedDate == default ? DateTime.Now : dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                IsActive = dto.IsActive,
                SourceNumber = dto.SourceNumber,
                Fy = dto.Fy,
                Year = dto.Year,
                LoginMonth = dto.LoginMonth,
                PremiumMonth = dto.PremiumMonth,
                Location = dto.Location,
                Department = dto.Department,
                InsuranceHead = dto.InsuranceHead,
                BusinessHead = dto.BusinessHead,
                Presentator = dto.Presentator,
                BusinessPartner = dto.BusinessPartner,
                InsuranceCategory = dto.InsuranceCategory,
                FreshRenewal = dto.FreshRenewal,
                PrincipalCo = dto.PrincipalCo,
                PlanType = dto.PlanType,
                EmpCode = dto.EmpCode,
                ApplicationNo = dto.ApplicationNo,
            };
        }
    }


}
