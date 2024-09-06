using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.CodeDom;
using DocumentFormat.OpenXml.Presentation;
using QuestPDF.Previewer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StakeOutReport_WinForms
{
    //SECTION OF CLASS RESERVED FOR GENERATING THE PDF REPORT
    public partial class StakeOutReport
    {
        private void GeneratePDF()
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                var doc = Document.Create(document =>
                {
                    document.Page(page =>
                    {
                        //PAGE PROPERTIES
                        page.Size(PageSizes.A4);
                        page.MarginHorizontal(10);
                        page.MarginVertical(10);

                        //HEADER PROPERTIES
                        page.Header()
                        .Height(60)
                        .Background(Colors.Grey.Lighten1)
                        .AlignMiddle()
                        .Text($"Project Title: {ProjectTitle}\n" +
                        $"Element of Works: {ElementOfWorks}" +
                            $"\nDate: {DateTime.Now.ToShortDateString()}")
                        .Bold()
                        .Underline()
                        .FontSize(15);


                        //CONTENT PROPERTIES
                        //page.Content()
                        //.Background(Colors.Grey.Lighten2)
                        //.AlignTop()
                        //.Text("This is the main body of the report");

                        page.Content()
                        .PaddingVertical(10)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(BlockHeader).Text("Point ID").Bold();
                                header.Cell().Element(BlockHeader).Text("Difference in \nEasting").Bold();
                                header.Cell().Element(BlockHeader).Text("Difference in Northing").Bold();
                                header.Cell().Element(BlockHeader).Text("Difference in Elevation").Bold();

                                header.Cell().Element(BlockHeader).Text(Error2DCheckBox.Checked ? "2D Error" : "3D Error");

                                //if (Error2DCheckBox.Checked)
                                //    header.Cell().Element(BlockHeader).Text("2D Error").Bold();
                                //else
                                //    header.Cell().Element(BlockHeader).Text("3D Error").Bold();
                            });

                            foreach (var point in ErrorWith3D)
                            {
                                table.Cell().Element(BlockBody).Text(point.PointID.ToString());
                                table.Cell().Element(BlockBody).Text(point.Easting.ToString());
                                table.Cell().Element(BlockBody).Text(point.Northing.ToString());

                                table.Cell().Element(BlockBody).Text(Error2DCheckBox.Checked ? "N/A" : point.Level.ToString());

                                //if(Error2DCheckBox.Checked)
                                //    table.Cell().Element(BlockBody).Text("N/A");
                                //else
                                //    table.Cell().Element(BlockBody).Text(point.Level.ToString());

                                table.Cell().Element(BlockBody).Text(point.Error.ToString());

                                //Add a check for this element like the below but will be for the tolerance
                                //table.Cell().Element(Error2DCheckBox.Checked ? BlockBody : BlockHeader).Text(point.Error.ToString());
                            }





                        });

                        static QuestPDF.Infrastructure.IContainer BlockHeader(QuestPDF.Infrastructure.IContainer container)
                        {
                            return container
                            .Border(1)
                            .Background(Colors.Grey.Lighten1)
                            .ShowEntire()
                            .MinWidth(30)
                            .MinHeight(30)
                            .AlignCenter()
                            .AlignMiddle();
                        }

                        static QuestPDF.Infrastructure.IContainer BlockBody(QuestPDF.Infrastructure.IContainer container)
                        {
                            return container
                            .Border(1)
                            .Background(Colors.Grey.Lighten4)
                            .ShowOnce()
                            .MinWidth(25)
                            .MinHeight(25)
                            .AlignCenter()
                            .AlignMiddle();
                        }


                        //FOOTER PROPERTIES
                        page.Footer()
                        //.PaddingVertical(10)
                        //.PaddingHorizontal(10)
                        .Height(50)
                        .Background(Colors.Grey.Lighten1)
                        .Row(row =>
                        {
                            row.RelativeItem()
                            .AlignCenter()
                            .AlignMiddle()
                            .PaddingLeft(20)
                            .Text("Stake Out Report. Software Created By W.Johnson")
                            .Italic()
                            .SemiBold();

                            row.ConstantItem(100)
                            .AlignRight()
                            .AlignMiddle()
                            .PaddingRight(20)
                            .Text(text =>
                            {
                                text.Span("Page ");
                                text.CurrentPageNumber();
                                text.Span(" / ");
                                text.TotalPages();
                            });
                        });
                        //.Text("Stake Out Report. Software created by W.Johnson")
                        //.Italic().
                        //Underline();

                    });





                });

                SaveFileDialog PDFFile = new SaveFileDialog();
                PDFFile.Filter = "PDF|*.pdf";
                PDFFile.Title = "Save a PDF file";
                PDFFile.ShowDialog();
                string filePath = PDFFile.FileName; //FILEPATH IS STORED HERE
                doc.GeneratePdf(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error creating PDF file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //MESSAGE USER CONFIRMING SUCCESSFULLY CREATED EXCEL SHEET
            MessageBox.Show("PDF Report Created!", "Report Success", MessageBoxButtons.OK);



        }
    }
}
