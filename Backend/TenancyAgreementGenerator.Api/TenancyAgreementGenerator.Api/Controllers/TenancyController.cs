using Microsoft.AspNetCore.Mvc;
using TenancyAgreementGenerator.Api.Models;
using TenancyAgreementGenerator.Api.Services;

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
        System.Diagnostics.Debugger.Break();
        if (model == null)
        {
            return BadRequest(new { Errors = new[] { "Invalid request body." } });
        }

        Console.WriteLine($"Received model: {model}");
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            Console.WriteLine("Validation Errors: " + string.Join(", ", errors));
            return BadRequest(new { Errors = errors });
        }

        try
        {
            var pdfBytes = _pdfService.GeneratePdf(model);
            return File(pdfBytes, "application/pdf", "TenancyAgreement.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating PDF: {ex.Message}");
            return StatusCode(500, new { Errors = new[] { "Internal server error while generating PDF." } });
        }
    }

    [HttpGet]
    public IActionResult Test() =>Ok("Controller is working");
}