using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using RestaurantManagement.Servisies;
using System.Reflection;


public class PdfExportService : IPdfExportService
{
    public async Task<byte[]> ExportTableToPdfAsync<T>(IEnumerable<T> data, string title)
    {
        // إنشاء ملف PDF جديد
        var document = new PdfDocument();
        var page = document.AddPage();
        var gfx = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 12, XFontStyle.Regular);
        var boldFont = new XFont("Verdana", 12, XFontStyle.Bold);

        // عنوان التقرير
        gfx.DrawString(title, new XFont("Verdana", 16, XFontStyle.Bold),
            XBrushes.Black, new XRect(0, 0, page.Width, 30),
            XStringFormats.TopCenter);

        int yPoint = 50;
        int startX = 20;

        // جلب أسماء الأعمدة (Properties)
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // رسم العناوين
        foreach (var prop in properties)
        {
            gfx.DrawString(prop.Name, boldFont, XBrushes.Black, startX, yPoint);
            startX += 100; // عرض العمود
        }

        yPoint += 20;

        // رسم الصفوف
        foreach (var item in data)
        {
            startX = 20;
            foreach (var prop in properties)
            {
                var value = prop.GetValue(item)?.ToString() ?? "";
                gfx.DrawString(value, font, XBrushes.Black, startX, yPoint);
                startX += 100;
            }
            yPoint += 20;
        }

        // حفظ في MemoryStream
        using (var stream = new MemoryStream())
        {
            document.Save(stream, false);
            return stream.ToArray();
        }
    }
}
