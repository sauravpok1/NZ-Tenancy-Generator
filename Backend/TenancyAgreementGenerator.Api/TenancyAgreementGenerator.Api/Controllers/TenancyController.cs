using Microsoft.AspNetCore.Mvc;
using TenancyAgreementGenerator.Api.Models;
using TenancyAgreementGenerator.Api.Services; // Add this line

[ApiController]
[Route("api/[controller]")]
public class TenancyController : ControllerBase
{
    private readonly IPdfGeneratorService _pdfService;

    public TenancyController(IPdfGeneratorService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromBody] TenancyAgreement model)
    {
        Console.WriteLine($"Received model:",model);
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                         .Select(e => e.ErrorMessage);
            Console.WriteLine("Validation Errors: " + string.Join("; ", errors));
            return BadRequest(new { Errors = errors });
        }

        var pdfBytes = _pdfService.GeneratePdf(model);
        return File(pdfBytes, "application/pdf", "TenancyAgreement.pdf");
    }
}