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
                        .Height(70)
                        .PaddingBottom(5)
                        .Background(Colors.Grey.Lighten1)
                        .Border(1)
                        .BorderColor(Colors.Black)
                        .Row(row =>
                        {
                            row.RelativeItem()
                            .AlignLeft()
                            .AlignMiddle()
                            .PaddingLeft(10)
                            .Text($"Project Title: {ProjectTitle}\n" +
                                  $"Element of Works: {ElementOfWorks}" +
                                  $"\nDate Report Generated: {DateTime.Now.ToShortDateString()}")
                            .Bold()
                            .Underline()
                            .FontSize(15);

                            row.RelativeItem()
                            .AlignRight()
                            .AlignMiddle()
                            .PaddingRight(10)
                            .Text(DefineErrorCheckBox.Checked ? $"Defined Tolerance: {DefinedErrorTolerance}m" : "Defined Tolerance: N/A")
                            .Bold()
                            .Underline()
                            .FontSize(15);




                        });

                        //PAGE CONTENT
                        page.Content()
                        //.PaddingVertical(10)
                        .Column(column =>
                        {
                            column.Item()
                            .Element(BlockTableHeader)
                            .Text("Summary of Point Errors (m)")
                            .Bold()
                            .Underline();
                      
                            column.Item().
                            Table(table =>
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

                                    header.Cell().Element(BlockHeader).Text(Error2DCheckBox.Checked ? "2D Error" : "3D Error").Bold();

                                });

                                foreach (var point in ErrorWith3D)
                                {
                                    //SECTION HERE DECIDES THE COLOUR OF THE ROW DEPENDING ON WHETHER OR NOT THE TOLERANCE IS EXCEEDED, ENTIRE ROW IS HIGHLIGHTED
                                    var ExceededTolerance = point.Error > DefinedErrorTolerance;

                                    table.Cell().Element(ExceededTolerance ? BlockBodyExceededTolerance : BlockBody).Text(point.PointID.ToString());
                                    table.Cell().Element(ExceededTolerance ? BlockBodyExceededTolerance : BlockBody).Text(point.Easting.ToString());
                                    table.Cell().Element(ExceededTolerance ? BlockBodyExceededTolerance : BlockBody).Text(point.Northing.ToString());

                                    //ENSURES ONLY ROWS THAT HAVE A VALUE / EXIST ARE OVERWROTE WITH N/A WHEN CONDUCTING A 2D CHECK
                                    if (point.Easting != null)
                                    {
                                        table.Cell().Element(ExceededTolerance ? BlockBodyExceededTolerance : BlockBody).Text(Error2DCheckBox.Checked ? "N/A" : point.Level.ToString());
                                    }
                                    else
                                    {
                                        table.Cell().Element(ExceededTolerance ? BlockBodyExceededTolerance : BlockBody).Text(string.Empty);
                                    }

                                    table.Cell().Element(ExceededTolerance ? BlockBodyExceededTolerance : BlockBody).Text(point.Error.ToString());

                                }

                            });
                        });
                        

                        //FOOTER PROPERTIES
                        page.Footer()
                        .Height(50)
                        .Background(Colors.Grey.Lighten1)
                        .Border(1)
                        .BorderColor(Colors.Black)
                        .Row(row =>
                        {
                            row.RelativeItem()
                            .AlignLeft()
                            .AlignMiddle()
                            .PaddingLeft(10)
                            .Text("Stake Out Report.\nSoftware created By W.Johnson\nV1.0.0")
                            .FontSize(10)
                            .Italic();

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

                        static QuestPDF.Infrastructure.IContainer BlockHeader(QuestPDF.Infrastructure.IContainer container)
                        {
                            return container
                            .Border(1)
                            .Background(Colors.Grey.Lighten2)
                            .ShowEntire()
                            .MinWidth(30)
                            .MinHeight(30)
                            .AlignCenter()
                            .AlignMiddle();
                        }

                        static QuestPDF.Infrastructure.IContainer BlockTableHeader(QuestPDF.Infrastructure.IContainer container)
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


                        static QuestPDF.Infrastructure.IContainer BlockBodyExceededTolerance(QuestPDF.Infrastructure.IContainer container)
                        {
                            return container
                            .Border(1)
                            .Background(Colors.Red.Lighten1)
                            .ShowOnce()
                            .MinWidth(25)
                            .MinHeight(25)
                            .AlignCenter()
                            .AlignMiddle();
                        }

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
