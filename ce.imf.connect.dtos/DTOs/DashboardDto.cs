namespace ce.imf.connect.comon.DTOs
{
    public class DashboardDto
    {
        public List<MonthlyInsuranceSoldDto> InsuranceSold { get; set; } = new();
        public List<MonthlyDraftDto> DraftSaved { get; set; } = new();
        public List<InsuranceTypeBreakdownDto> InsuranceTypeBreakdown { get; set; } = new();
        public List<SalesAmountByTypeDto> SalesAmountByType { get; set; } = new();
    }

    public class MonthlyInsuranceSoldDto
    {
        public string Month { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class MonthlyDraftDto
    {
        public string Month { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class InsuranceTypeBreakdownDto
    {
        public string InsuranceType { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class SalesAmountByTypeDto
    {
        public string InsuranceType { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}