using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using TenancyAgreementGenerator.Api.Models;
using System.IO;

namespace TenancyAgreementGenerator.Api.Services;

public class PdfGeneratorService
{
    private readonly string _templatePath;

    public PdfGeneratorService()
    {
        _templatePath = Path.Combine(Directory.GetCurrentDirectory(), "../../Shared/Templates/tenancy-template.json");
    }

    public byte[] GeneratePdf(TenancyAgreement model)
    {
        // Load template (simplified for demo)
        string template = File.Exists(_templatePath)
            ? File.ReadAllText(_templatePath)
            : @"
                RESIDENTIAL TENANCY AGREEMENT
                This agreement is made between the Landlord and the Tenant as per the Residential Tenancies Act 1986.
                Landlord: [Placeholder]
                Tenant: {0}
                Property Address: {1}
                Rent: ${2} {3}
                Start Date: {4:dd/MM/yyyy}
                Terms and conditions as per tenancy.govt.nz standards.
            ";

        // Format template with user input
        string content = string.Format(
            template,
            model.TenantName,
            model.PropertyAddress,
            model.RentAmount,
            model.RentFrequency,
            model.StartDate
        );

        // Generate PDF
        using var memoryStream = new MemoryStream();
        using var writer = new PdfWriter(memoryStream);
        using var pdf = new PdfDocument(writer);
        var document = new Document(pdf);
        document.Add(new Paragraph(content));
        document.Close();

        return memoryStream.ToArray();
    }
}