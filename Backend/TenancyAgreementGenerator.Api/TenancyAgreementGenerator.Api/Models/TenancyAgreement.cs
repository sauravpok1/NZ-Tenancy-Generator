namespace TenancyAgreementGenerator.Api.Models;

public class TenancyAgreement
{
    public string TenantName { get; set; } = string.Empty;
    public string TenantAddress { get; set; } = string.Empty;
    public string PropertyAddress { get; set; } = string.Empty;
    public decimal RentAmount { get; set; }
    public string RentFrequency { get; set; } = "weekly";
    public DateTime StartDate { get; set; }
}