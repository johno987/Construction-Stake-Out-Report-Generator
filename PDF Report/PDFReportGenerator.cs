using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.CodeDom;

namespace StakeOutReport_WinForms
{
    public class PDFGenerator : IDocument
    {
        public StakeOutReport StakeOutReport { get; } //pass in the stake out report class object
        //when am i ready to call this, should be able to pass in the this pointer?

        public PDFGenerator(StakeOutReport stakeOutReport)
        {
            StakeOutReport = stakeOutReport;
        }
       
        public DocumentMetadata GetMetaData() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;
        public void Compose(IDocumentContainer container) //make the PDF page
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Header().Height(100).Background(Colors.Grey.Lighten1);
                page.Content().Background(Colors.Grey.Lighten3);
                page.Footer().Height(50).Background(Colors.Grey.Lighten1);
                page.Size(PageSizes.A3);
            });
        }

        //private void composeHeader(IContainer container)
        //{
        //    var titleStyle = TextStyle.Default.FontSize(20).SemiBold()
        //        .FontColor(Colors.Blue.Medium);

        //    container.Row(row =>
        //    {
        //        row.RelativeItem().Column(column =>
        //        {
                    
        //        })
        //    })
        //}
    }

    public interface IDocument
    {
        DocumentMetadata GetMetaData();
        DocumentSettings GetSettings();
        void Compose(IDocumentContainer container);
    }
}
