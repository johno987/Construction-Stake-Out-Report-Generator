using ClosedXML.Excel;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport
    {
        private void GenerateExcelReport()
        {
            //FIRST GET THE USERS SAVE NAME AND FILE PATH
            try
            {
                SaveFileDialog CSVFile = new SaveFileDialog();
                CSVFile.Filter = "Excel Files|*.xlsx;*.xlsm";
                CSVFile.Title = "Save a CSV file";
                CSVFile.ShowDialog();
                string filePath = CSVFile.FileName; //FILEPATH IS STORED HERE

                //CREATE THE WORKBOOK
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(ElementOfWorks + " Report");
                    const int columnWidth = 20;
                    // Set column widths
                    for (int i = 1; i <= 5; ++i)
                    {
                        if (i == 3)
                        {
                            worksheet.Column(i).Width = 25;
                            continue;
                        }
                        worksheet.Column(i).Width = columnWidth;
                    }
                    for (int i = 7; i <= 10; ++i)
                    {
                        worksheet.Column(i).Width = columnWidth;
                    }
                    for (int i = 12; i <= 15; ++i)
                    {
                        worksheet.Column(i).Width = columnWidth;
                    }


                    // Add header information
                    worksheet.Cell("A1").Value = "Project Title";
                    worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


                    worksheet.Cell("A2").Value = "Element Of Works";
                    worksheet.Cell("A2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell("B1").Value = ProjectTitle;
                    worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.AshGrey;

                    worksheet.Cell("B2").Value = ElementOfWorks;
                    worksheet.Cell("B2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell("B2").Style.Fill.BackgroundColor = XLColor.AshGrey;

                    worksheet.Cell("C1").Value = "Date Report Generated";
                    worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell("C2").Value = "Defined Tolerance (m)";
                    worksheet.Cell("C2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell("D1").Value = DateTime.Now.ToString("dd/MM/yyyy");
                    worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.AshGrey;

                    worksheet.Cell("D2").Value = DefinedErrorTolerance == null ? "N/A" : DefinedErrorTolerance;
                    worksheet.Cell("D2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell("D2").Style.Fill.BackgroundColor = XLColor.AshGrey;


                    // Add main headers
                    worksheet.Cell("A4").Value = "Point Errors (m)";
                    worksheet.Range("A4:E4").Row(1).Merge();
                    worksheet.Cell("A4").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell("G4").Value = "Design Info";
                    worksheet.Range("G4:J4").Row(1).Merge();
                    worksheet.Cell("G4").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell("L4").Value = "As Built Info";
                    worksheet.Range("L4:O4").Row(1).Merge();
                    worksheet.Cell("L4").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    // Add sub-headers
                    string[] subHeaders3D = { "Point ID", "Difference in Easting", "Difference in Northing", "Difference in Elevation", "3D Error" };
                    string[] subHeaders2D = { "Point ID", "Difference in Easting", "Difference in Northing", "Difference in Elevation", "2D Error" };
                    string[] subHeadersWithoutError = { "Point ID", "Easting", "Northing", "Elevation" };

                    for (int i = 0; i < subHeaders3D.Length; i++)
                    {
                        //if 2d error only, use the 2d headers, else use the 3d headers
                        worksheet.Cell(5, i + 1).Value = Error2DCheckBox.Checked ? subHeaders2D[i] : subHeaders3D[i];
                    }

                    for (int i = 0; i < subHeadersWithoutError.Length; i++)
                    {
                        worksheet.Cell(5, i + 7).Value = subHeadersWithoutError[i];
                        worksheet.Cell(5, i + 12).Value = subHeadersWithoutError[i];
                    }

                    //Add borders
                    var ProjectHeaderRange = worksheet.Range("A1:D2");
                    ProjectHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ProjectHeaderRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    var ErrorTableRange = worksheet.Range("A5:E5");
                    ErrorTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ErrorTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    var DesignDataTableRange = worksheet.Range("G5:J5");
                    DesignDataTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    DesignDataTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    var AsBuiltDataTableRange = worksheet.Range("L5:O5");
                    AsBuiltDataTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    AsBuiltDataTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;


                    //do the final header borders thick last so they arent overwrote
                    var ErrorHeader = worksheet.Range("A4:E4");
                    ErrorHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    var DesignHeader = worksheet.Range("G4:J4");
                    DesignHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    var AsBuiltHeader = worksheet.Range("L4:O4");
                    AsBuiltHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;



                    //text styling
                    var headerRange = worksheet.Range("A1:D2");
                    headerRange.Style.Font.Bold = true;

                    var subHeaderRange = worksheet.Range("A4:O5");
                    subHeaderRange.Style.Font.Bold = true;
                    subHeaderRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //var tableHeaders = worksheet.Range("A4:O4");
                    //tableHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                    //WRITE THE DATA TO THE TABLES
                    var errorRange = worksheet.Cell("A6").InsertData(ErrorWith3D);
                    var DesignRange = worksheet.Cell("G6").InsertData(DesignData);
                    var AsBuiltRange = worksheet.Cell("L6").InsertData(AsBuiltData);



                    //NEED TO REORDER THE FIRST TABLE SHOWING THE ERROR
                    #region ReorderingColumns
                    var ColARangeData = worksheet.Range($"A6:A{6 + ErrorWith3D.Count}");
                    var ColBRangeData = worksheet.Range($"B6:B{6 + ErrorWith3D.Count}");
                    var ColCRangeData = worksheet.Range($"C6:C{6 + ErrorWith3D.Count}");
                    var ColDRangeData = worksheet.Range($"D6:D{6 + ErrorWith3D.Count}");
                    var ColERangeData = worksheet.Range($"E6:E{6 + ErrorWith3D.Count}");

                    var targetCellA = worksheet.Cell("A6"); //col A
                    var targetCellB = worksheet.Cell("B6"); //col B 
                    var targetCellC = worksheet.Cell("C6"); //Col C
                    var targetCellD = worksheet.Cell("D6"); //col D 
                    var targetCellE = worksheet.Cell("E6"); //col E

                    //COPY THE DATA OUTSIDE THE RANGE OF THE WORKSHEET

                    var targetCellR = worksheet.Cell("R6"); //col R
                    var targetCellS = worksheet.Cell("S6"); //col S 
                    var targetCellT = worksheet.Cell("T6"); //Col T
                    var targetCellU = worksheet.Cell("U6"); //col U 
                    var targetCellV = worksheet.Cell("V6"); //col V

                    ColBRangeData.CopyTo(targetCellR);
                    ColARangeData.CopyTo(targetCellV);
                    ColCRangeData.CopyTo(targetCellS);
                    ColDRangeData.CopyTo(targetCellT);
                    ColERangeData.CopyTo(targetCellU);

                    //NOW MOVE IT BACK INTO THE CORRECT CELLS FROM TABLE 1
                    var ColRRangeData = worksheet.Range($"R6:R{6 + ErrorWith3D.Count}");
                    var ColSRangeData = worksheet.Range($"S6:S{6 + ErrorWith3D.Count}");
                    var ColTRangeData = worksheet.Range($"T6:T{6 + ErrorWith3D.Count}");
                    var ColURangeData = worksheet.Range($"U6:U{6 + ErrorWith3D.Count}");
                    var ColVRangeData = worksheet.Range($"V6:V{6 + ErrorWith3D.Count}");

                    ColRRangeData.CopyTo(targetCellA);
                    ColSRangeData.CopyTo(targetCellB);
                    ColTRangeData.CopyTo(targetCellC);
                    ColURangeData.CopyTo(targetCellD);
                    ColVRangeData.CopyTo(targetCellE);

                    //NOW DELETE THE TEMPORARY STORAGE COLUMNS
                    ColRRangeData.Delete(XLShiftDeletedCells.ShiftCellsLeft);
                    ColSRangeData.Delete(XLShiftDeletedCells.ShiftCellsLeft);
                    ColTRangeData.Delete(XLShiftDeletedCells.ShiftCellsLeft);
                    ColURangeData.Delete(XLShiftDeletedCells.ShiftCellsLeft);
                    ColVRangeData.Delete(XLShiftDeletedCells.ShiftCellsLeft);

                    //NOW GET THE RANGE OF CELLS THAT CONTAIN THE ERROR COLUMN
                    if(DefineErrorCheckBox.Checked && !string.IsNullOrEmpty(ToleranceTextBox.Text))
                    {
                        var ErrorRangeData = worksheet.Range($"E6:E{6 + ErrorWith3D.Count - 1}");
                        foreach (var cell in ErrorRangeData.Cells())
                        {
                            //MAY NEED TO ADD AN EMPTY CELL CHECK HERE
                            if (cell.IsEmpty())
                                continue;
                            var cellValue = decimal.Parse(cell.Value.ToString());
                            if (cellValue > DefinedErrorTolerance)
                            {
                                worksheet.Range($"A{cell.Address.RowNumber}:{cell.Address}").Style.
                                    Fill.BackgroundColor = XLColor.Jasper;
                            }
                        }
                    }

                    #endregion;

                    //IF 2D ERROR OPTION IS SELECTED, N/A WILL BE APPENDED TO THE DIFFERENCE IN ELEVATION COLUMN TO SHOW IT IS NOT BEING USED WITHIN THE ERROR CALC
                    if (Error2DCheckBox.Checked) //TEMP
                    {
                        var ElevationRange = worksheet.Range($"D6:D{6 + ErrorWith3D.Count - 1}");

                        //ONLY ADDS N/A TO CELLS THAT HAVE CURRENT DATA
                        ElevationRange.Cells()
                            .Where(cell => !worksheet.Cell($"B{cell.Address.RowNumber}").IsEmpty())
                            .ToList()
                            .ForEach(cell => cell.Value = "N/A");
                    }


                    //ADD BORDERS TO THE TABLES
                    errorRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    errorRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    DesignRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    DesignRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    AsBuiltRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    AsBuiltRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    //CENTRE THE TEXT FOR THE TABLES
                    errorRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    DesignRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    AsBuiltRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Save the workbook
                    workbook.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                //message user with error
                MessageBox.Show(ex.Message, "Error creating excel file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //MESSAGE USER CONFIRMING SUCCESSFULLY CREATED EXCEL SHEET
            MessageBox.Show("Exccel Report Created!", "Report Success", MessageBoxButtons.OK);
        }
    }
}