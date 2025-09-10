using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.comon.Mapper
{
    public static class CustomerMapper
    {
        public static CustomerDto ToDto(Customer entity)
        {
            return new CustomerDto
            {
                Id = entity.Id,
                CustomerNumber = entity.CustomerNumber,
                ApplicationNo = entity.ApplicationNo,
                SourcingDetailsId = entity.SourcingDetailsId,
                ItemType = entity.ItemType,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy,
                IsActive = entity.IsActive,

                Proposer = entity.Proposer,
                ProposerDob = entity.ProposerDob,
                ProposerPan = entity.ProposerPan,
                ProposerAadhar = entity.ProposerAadhar,
                ProposerGender = entity.ProposerGender,
                ProposerPhone = entity.ProposerPhone,
                ProposerEmail = entity.ProposerEmail,
                ProposerAddress = entity.ProposerAddress,
                ProposerDistrict = entity.ProposerDistrict,
                ProposerPincode = entity.ProposerPincode,
                ProposerState = entity.ProposerState,

                LifeAssured = entity.LifeAssured,
                LifeAssuredDob = entity.LifeAssuredDob,
                LifeAssuredPan = entity.LifeAssuredPan,
                LifeAssuredAadhar = entity.LifeAssuredAadhar,
                LifeAssuredGender = entity.LifeAssuredGender,
                LifeAssuredPhone = entity.LifeAssuredPhone,
                LifeAssuredEmail = entity.LifeAssuredEmail,
                LifeAssuredAddress = entity.LifeAssuredAddress,
                LifeAssuredDistrict = entity.LifeAssuredDistrict,
                LifeAssuredPincode = entity.LifeAssuredPincode,
                LifeAssuredState = entity.LifeAssuredState,

                Nominee = entity.Nominee,
                NomineeDob = entity.NomineeDob,
                NomineePan = entity.NomineePan,
                NomineeAadhar = entity.NomineeAadhar,
                NomineeGender = entity.NomineeGender,
                NomineePhone = entity.NomineePhone,
                NomineeEmail = entity.NomineeEmail,
                NomineeAddress = entity.NomineeAddress,
                NomineeDistrict = entity.NomineeDistrict,
                NomineePincode = entity.NomineePincode,
                NomineeState = entity.NomineeState,

                Appointee = entity.Appointee,
                AppointeeDob = entity.AppointeeDob,
                AppointeePan = entity.AppointeePan,
                AppointeeAadhar = entity.AppointeeAadhar,
                AppointeeGender = entity.AppointeeGender,
                AppointeePhone = entity.AppointeePhone,
                AppointeeEmail = entity.AppointeeEmail,
                AppointeeAddress = entity.AppointeeAddress,
                AppointeeDistrict = entity.AppointeeDistrict,
                AppointeePincode = entity.AppointeePincode,
                AppointeeState = entity.AppointeeState,

                CustomerType = entity.CustomerType
            };
        }

        public static Customer ToEntity(CustomerDto dto)
        {
            return new Customer
            {
                Id = dto.Id,
                CustomerNumber = dto.CustomerNumber,
                ApplicationNo = dto.ApplicationNo,
                SourcingDetailsId = dto.SourcingDetailsId,
                ItemType = dto.ItemType,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                IsActive = dto.IsActive,

                Proposer = dto.Proposer,
                ProposerDob = dto.ProposerDob,
                ProposerPan = dto.ProposerPan,
                ProposerAadhar = dto.ProposerAadhar,
                ProposerGender = dto.ProposerGender,
                ProposerPhone = dto.ProposerPhone,
                ProposerEmail = dto.ProposerEmail,
                ProposerAddress = dto.ProposerAddress,
                ProposerDistrict = dto.ProposerDistrict,
                ProposerPincode = dto.ProposerPincode,
                ProposerState = dto.ProposerState,

                LifeAssured = dto.LifeAssured,
                LifeAssuredDob = dto.LifeAssuredDob,
                LifeAssuredPan = dto.LifeAssuredPan,
                LifeAssuredAadhar = dto.LifeAssuredAadhar,
                LifeAssuredGender = dto.LifeAssuredGender,
                LifeAssuredPhone = dto.LifeAssuredPhone,
                LifeAssuredEmail = dto.LifeAssuredEmail,
                LifeAssuredAddress = dto.LifeAssuredAddress,
                LifeAssuredDistrict = dto.LifeAssuredDistrict,
                LifeAssuredPincode = dto.LifeAssuredPincode,
                LifeAssuredState = dto.LifeAssuredState,

                Nominee = dto.Nominee,
                NomineeDob = dto.NomineeDob.Value,
                NomineePan = dto.NomineePan,
                NomineeAadhar = dto.NomineeAadhar,
                NomineeGender = dto.NomineeGender,
                NomineePhone = dto.NomineePhone,
                NomineeEmail = dto.NomineeEmail,
                NomineeAddress = dto.NomineeAddress,
                NomineeDistrict = dto.NomineeDistrict,
                NomineePincode = dto.NomineePincode,
                NomineeState = dto.NomineeState,

                Appointee = dto.Appointee,
                AppointeeDob = dto.AppointeeDob,
                AppointeePan = dto.AppointeePan,
                AppointeeAadhar = dto.AppointeeAadhar,
                AppointeeGender = dto.AppointeeGender,
                AppointeePhone = dto.AppointeePhone,
                AppointeeEmail = dto.AppointeeEmail,
                AppointeeAddress = dto.AppointeeAddress,
                AppointeeDistrict = dto.AppointeeDistrict,
                AppointeePincode = dto.AppointeePincode,
                AppointeeState = dto.AppointeeState,

                CustomerType = dto.CustomerType
            };
        }
    }

}
