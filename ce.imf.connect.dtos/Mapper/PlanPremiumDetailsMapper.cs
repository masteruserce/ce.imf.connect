using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Mapper
{
    public static class PlanPremiumDetailsMapper
    {
        public static PlanPremiumDetailsDto ToDto(this PlanPremiumDetails e)
        {
            if (e == null) return null;
            return new PlanPremiumDetailsDto
            {
                Id = e.Id,
                PlanName = e.PlanName,
                ApplicationNo = e.ApplicationNo,
                SourcingId = e.SourcingId,
                PolicyNo = e.PolicyNo,
                PaymentTerm = e.PaymentTerm,
                PaymentPayingTerm = e.PaymentPayingTerm,
                SumAssured = e.SumAssured,
                PremiumPayingMode = e.PremiumPayingMode,
                ChequeAmount = e.ChequeAmount,
                ModelPremium = e.ModelPremium,
                Wrp = e.Wrp,
                Wapi = e.Wapi,
                IssuedWrp = e.IssuedWrp
            };
        }

        public static PlanPremiumDetails ToEntity(this PlanPremiumDetailsDto d)
        {
            if (d == null) return null;
            return new PlanPremiumDetails
            {
                Id = d.Id == Guid.Empty ? Guid.NewGuid() : d.Id,
                PlanName = d.PlanName,
                ApplicationNo = d.ApplicationNo,
                SourcingId = d.SourcingId,
                PolicyNo = d.PolicyNo,
                PaymentTerm = d.PaymentTerm,
                PaymentPayingTerm = d.PaymentPayingTerm,
                SumAssured = d.SumAssured,
                PremiumPayingMode = d.PremiumPayingMode,
                ChequeAmount = d.ChequeAmount,
                ModelPremium = d.ModelPremium,
                Wrp = d.Wrp,
                Wapi = d.Wapi,
                IssuedWrp = d.IssuedWrp
            };
        }
    }
}
