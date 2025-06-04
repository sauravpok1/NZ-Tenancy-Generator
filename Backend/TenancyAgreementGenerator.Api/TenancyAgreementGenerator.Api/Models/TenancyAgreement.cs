namespace TenancyAgreementGenerator.Api.Models;
using System.ComponentModel.DataAnnotations;

public class TenancyAgreement
{
    [Required(ErrorMessage = "Tenant Name is required")]
    public string TenantName { get; set; }

    [Required(ErrorMessage = "Tenant Address is required")]
    public string TenantAddress { get; set; }

    [Required(ErrorMessage = "Property Address is required")]
    public string PropertyAddress { get; set; }

    [Required(ErrorMessage = "Rent Amount is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Rent Amount must be greater than 0")]
    public decimal RentAmount { get; set; }

    [Required(ErrorMessage = "Rent Frequency is required")]
    public string RentFrequency { get; set; }

    [Required(ErrorMessage = "Start Date is required")]
    public DateTime StartDate { get; set; }
}