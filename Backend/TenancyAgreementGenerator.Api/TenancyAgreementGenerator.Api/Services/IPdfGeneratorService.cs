using TenancyAgreementGenerator.Api.Models;

namespace TenancyAgreementGenerator.Api.Services;

public interface IPdfGeneratorService
{
    byte[] GeneratePdf(TenancyAgreement model);
}
