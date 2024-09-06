using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.CodeDom;
using DocumentFormat.OpenXml.Presentation;
using QuestPDF.Previewer;

namespace StakeOutReport_WinForms
{
  //SECTION OF CLASS RESERVED FOR GENERATING THE PDF REPORT
  public partial class StakeOutReport
    {
        private void GeneratePDF()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var report = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Header().Text("PDF Report");

                });
            });

            //SaveFileDialog PDFReport = new SaveFileDialog();
            //PDFReport.Filter = "PDF|*.pdf";
            //PDFReport.Title = "Save a PDF filedsasdasdasdasd";
            //PDFReport.ShowDialog();

            //report.GeneratePdf(PDFReport.FileName);
            report.ShowInPreviewer();
        }
    }
}
