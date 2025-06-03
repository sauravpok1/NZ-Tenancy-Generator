using Microsoft.AspNetCore.Mvc;
using TenancyAgreementGenerator.Api.Models;
using TenancyAgreementGenerator.Api.Services;

namespace TenancyAgreementGenerator.Api.Controllers;

[ApiController]
[Route("api/tenancy")]
public class TenancyController : ControllerBase
{
    private readonly PdfGeneratorService _pdfService;

    public TenancyController(PdfGeneratorService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpPost("generate")]
    public IActionResult GenerateAgreement([FromBody] TenancyAgreement model)
    {
        var pdfBytes = _pdfService.GeneratePdf(model);
        return File(pdfBytes, "application/pdf", "TenancyAgreement.pdf");
    }
}