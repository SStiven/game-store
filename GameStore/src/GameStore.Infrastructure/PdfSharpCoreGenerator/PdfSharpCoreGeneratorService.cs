using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace GameStore.Infrastructure.PdfSharpCoreGenerator;

public class PdfSharpCoreGeneratorService : IPdfGeneratorService
{
    public byte[] GenerateInvoicePdf(Order order)
    {
        using var document = new PdfDocument();
        var page = document.AddPage();
        var graphics = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 20, XFontStyle.Bold);

        graphics.DrawString(
            "Invoice",
            font,
            XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.TopCenter);

        font = new XFont("Verdana", 12, XFontStyle.Regular);

        graphics.DrawString(
            $"User ID: {order.CustomerId}",
            font,
            XBrushes.Black,
            new XRect(40, 80, page.Width, page.Height),
            XStringFormats.TopLeft);

        graphics.DrawString(
            $"Order ID: {order.Id}",
            font,
            XBrushes.Black,
            new XRect(40, 100, page.Width, page.Height),
            XStringFormats.TopLeft);

        graphics.DrawString(
            $"Creation Date: {order.Date}",
            font,
            XBrushes.Black,
            new XRect(40, 120, page.Width, page.Height),
            XStringFormats.TopLeft);

        var validityDate = order.Date?.AddDays(7);
        graphics.DrawString(
            $"Validity Date: {validityDate}",
            font,
            XBrushes.Black,
            new XRect(40, 140, page.Width, page.Height),
            XStringFormats.TopLeft);

        graphics.DrawString(
            $"Total: {order.GetTotal():C}",
            font,
            XBrushes.Black,
            new XRect(40, 160, page.Width, page.Height),
            XStringFormats.TopLeft);

        using var stream = new MemoryStream();
        document.Save(stream, false);
        return stream.ToArray();
    }
}
