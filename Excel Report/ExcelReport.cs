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

                    worksheet.Cell("B1").Value = ProjectTitle;
                    worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.AshGrey;

                    worksheet.Cell("C1").Value = "Date Report Generated";
                    worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell("D1").Value = DateTime.Now.ToString("dd/MM/yyyy");
                    worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.AshGrey;

                    // Add main headers
                    worksheet.Cell("A3").Value = "Point Errors";
                    worksheet.Range("A3:E3").Row(1).Merge();
                    worksheet.Cell("A3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell("G3").Value = "Design Info";
                    worksheet.Range("G3:J3").Row(1).Merge();
                    worksheet.Cell("G3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell("L3").Value = "As Built Info";
                    worksheet.Range("L3:O3").Row(1).Merge();
                    worksheet.Cell("L3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    // Add sub-headers
                    string[] subHeaders3D = { "Point ID", "Difference in Easting", "Difference in Northing", "Difference in Elevation", "3D Error" };
                    string[] subHeaders2D = { "Point ID", "Difference in Easting", "Difference in Northing", "Difference in Elevation", "2D Error" };
                    string[] subHeadersWithoutError = { "Point ID", "Easting", "Northing", "Elevation" };

                    for (int i = 0; i < subHeaders3D.Length; i++)
                    {
                        //if 2d error only, use the 2d headers, else use the 3d headers
                        worksheet.Cell(4, i + 1).Value = Error2DCheckBox.Checked ? subHeaders2D[i] : subHeaders3D[i];
                    }

                    for (int i = 0; i < subHeadersWithoutError.Length; i++)
                    {
                        worksheet.Cell(4, i + 7).Value = subHeadersWithoutError[i];
                        worksheet.Cell(4, i + 12).Value = subHeadersWithoutError[i];
                    }

                    //Add borders
                    var ProjectHeaderRange = worksheet.Range("A1:D1");
                    ProjectHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ProjectHeaderRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    var ErrorTableRange = worksheet.Range("A4:E4");
                    ErrorTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ErrorTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    var DesignDataTableRange = worksheet.Range("G4:J4");
                    DesignDataTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    DesignDataTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    var AsBuiltDataTableRange = worksheet.Range("L4:O4");
                    AsBuiltDataTableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    AsBuiltDataTableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;


                    //do the final header borders thick last so they arent overwrote
                    var ErrorHeader = worksheet.Range("A3:E3");
                    ErrorHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    var DesignHeader = worksheet.Range("G3:J3");
                    DesignHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    var AsBuiltHeader = worksheet.Range("L3:O3");
                    AsBuiltHeader.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;



                    //text styling
                    var headerRange = worksheet.Range("A1:D1");
                    headerRange.Style.Font.Bold = true;

                    var subHeaderRange = worksheet.Range("A3:O4");
                    subHeaderRange.Style.Font.Bold = true;
                    subHeaderRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    //var tableHeaders = worksheet.Range("A4:O4");
                    //tableHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                    //WRITE THE DATA TO THE TABLES
                    var errorRange = worksheet.Cell("A5").InsertData(ErrorWith3D);
                    var DesignRange = worksheet.Cell("G5").InsertData(DesignData);
                    var AsBuiltRange = worksheet.Cell("L5").InsertData(AsBuiltData);



                    //NEED TO REORDER THE FIRST TABLE SHOWING THE ERROR
                    #region ReorderingColumns
                    var ColARangeData = worksheet.Range($"A5:A{5 + ErrorWith3D.Count}");
                    var ColBRangeData = worksheet.Range($"B5:B{5 + ErrorWith3D.Count}");
                    var ColCRangeData = worksheet.Range($"C5:C{5 + ErrorWith3D.Count}");
                    var ColDRangeData = worksheet.Range($"D5:D{5 + ErrorWith3D.Count}");
                    var ColERangeData = worksheet.Range($"E5:E{5 + ErrorWith3D.Count}");

                    var targetCellA = worksheet.Cell("A5"); //col A
                    var targetCellB = worksheet.Cell("B5"); //col B 
                    var targetCellC = worksheet.Cell("C5"); //Col C
                    var targetCellD = worksheet.Cell("D5"); //col D 
                    var targetCellE = worksheet.Cell("E5"); //col E

                    //COPY THE DATA OUTSIDE THE RANGE OF THE WORKSHEET

                    var targetCellR = worksheet.Cell("R5"); //col R
                    var targetCellS = worksheet.Cell("S5"); //col S 
                    var targetCellT = worksheet.Cell("T5"); //Col T
                    var targetCellU = worksheet.Cell("U5"); //col U 
                    var targetCellV = worksheet.Cell("V5"); //col V

                    ColBRangeData.CopyTo(targetCellR);
                    ColARangeData.CopyTo(targetCellV);
                    ColCRangeData.CopyTo(targetCellS);
                    ColDRangeData.CopyTo(targetCellT);
                    ColERangeData.CopyTo(targetCellU);

                    //NOW MOVE IT BACK INTO THE CORRECT CELLS FROM TABLE 1
                    var ColRRangeData = worksheet.Range($"R5:R{5 + ErrorWith3D.Count}");
                    var ColSRangeData = worksheet.Range($"S5:S{5 + ErrorWith3D.Count}");
                    var ColTRangeData = worksheet.Range($"T5:T{5 + ErrorWith3D.Count}");
                    var ColURangeData = worksheet.Range($"U5:U{5 + ErrorWith3D.Count}");
                    var ColVRangeData = worksheet.Range($"V5:V{5 + ErrorWith3D.Count}");

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





                    #endregion;

                    //IF 2D ERROR OPTION IS SELECTED, N/A WILL BE APPENDED TO THE DIFFERENCE IN ELEVATION COLUMN TO SHOW IT IS NOT BEING USED WITHIN THE ERROR CALC
                    if (Error2DCheckBox.Checked) //TEMP
                    {
                        var ElevationRange = worksheet.Range($"D5:D{5 + ErrorWith3D.Count - 1}");
                        ElevationRange.Cells().Value = "N/A";
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
            MessageBox.Show("Report Created!", "Report Success", MessageBoxButtons.OK);

        }
    }
}