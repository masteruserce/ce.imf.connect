using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models.InsuranceApp.Models;

namespace ce.imf.connect.common.Mapper
{
    public static class PayoutDetailsMapper
    {
        public static PayoutDetailsDto ToDto(this PayoutDetails entity)
        {
            return new PayoutDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                PayoutPercentage = entity.PayoutPercentage,
                PayoutMonth = entity.PayoutMonth,
                PayoutAmount = entity.PayoutAmount,
                TdsDeducted = entity.TdsDeducted,
                NetPayoutAmount = entity.NetPayoutAmount,
                AmountPaid = entity.AmountPaid,
                BalancePayable = entity.BalancePayable,
                PayoutStatus = entity.PayoutStatus,
                PaidDate = entity.PaidDate,
                PayeeName = entity.PayeeName,
                PaymentMode = entity.PaymentMode,
                BankAccountNo = entity.BankAccountNo,
                BankHolderName = entity.BankHolderName,
                BankName = entity.BankName,
                IfscCode = entity.IfscCode,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static PayoutDetails ToEntity(this PayoutDetailsDto dto)
        {
            return new PayoutDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                PayoutPercentage = dto.PayoutPercentage,
                PayoutMonth = dto.PayoutMonth,
                PayoutAmount = dto.PayoutAmount,
                TdsDeducted = dto.TdsDeducted,
                NetPayoutAmount = dto.NetPayoutAmount,
                AmountPaid = dto.AmountPaid,
                BalancePayable = dto.BalancePayable,
                PayoutStatus = dto.PayoutStatus,
                PaidDate = dto.PaidDate,
                PayeeName = dto.PayeeName,
                PaymentMode = dto.PaymentMode,
                BankAccountNo = dto.BankAccountNo,
                BankHolderName = dto.BankHolderName,
                BankName = dto.BankName,
                IfscCode = dto.IfscCode,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this PayoutDetails entity, PayoutDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.PayoutPercentage = dto.PayoutPercentage;
            entity.PayoutMonth = dto.PayoutMonth;
            entity.PayoutAmount = dto.PayoutAmount;
            entity.TdsDeducted = dto.TdsDeducted;
            entity.NetPayoutAmount = dto.NetPayoutAmount;
            entity.AmountPaid = dto.AmountPaid;
            entity.BalancePayable = dto.BalancePayable;
            entity.PayoutStatus = dto.PayoutStatus;
            entity.PaidDate = dto.PaidDate;
            entity.PayeeName = dto.PayeeName;
            entity.PaymentMode = dto.PaymentMode;
            entity.BankAccountNo = dto.BankAccountNo;
            entity.BankHolderName = dto.BankHolderName;
            entity.BankName = dto.BankName;
            entity.IfscCode = dto.IfscCode;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
