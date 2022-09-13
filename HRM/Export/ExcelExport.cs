using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.XlsIO;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Library;
using HRM.Entities;
using HRM;
using HRM.DataAccess.TuyenDung;
using HRM.DataAccess.Common;
using HRM.DataAccess.Catalogs;
using System.Globalization;

namespace HRM.Class
{
    public class ExcelExport
    {
        #region ---- Constants ----

        private const int ROW_MAXIMUM = 200;
        private const int COL_MAXIMUM = 256;

        private const string FONT_NAME = "Arial";
        private const int HEADER_FONT_SIZE = 16;
        private const int SUBHEADER_FONT_SIZE = 13;
        private const int CAPTION_FONT_SIZE = 10;
        private const int CONTENT_FONT_SIZE = 10;

        #endregion

        #region ---- Member variables ----

        private IWorkbook _workBook;

        #endregion

        #region ---- Constructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelExport"/> class.
        /// </summary>
        public ExcelExport()
        {

        }

        #endregion

        #region ---- Private methods ----

        public string AutoExportToExcel(HRMGrigouping gridData, string pSheetName, bool isPrint = false, bool usingStyle = false)
        {
            int rowStart = 2;
            int colStart = 2;
            int rowIndex = rowStart;
            int colIndex = colStart;

            // Number column visible + No. column
            int colNum = gridData.TableDescriptor.VisibleColumns.Count + 1;

            ExcelEngine xslEngine = new ExcelEngine();
            IApplication application = xslEngine.Excel;
            IWorksheet xlsSheet;

            // Create sheet name
            this._workBook = application.Workbooks.Create(new string[] { pSheetName });
            xlsSheet = this._workBook.Worksheets[0];

            // 
            xlsSheet.Range[1, 1].ColumnWidth = 3;

            #region ---- Header ----

            string[] headerName = new string[colNum];
            string[] headerText = new string[colNum];
            int[] headerWidth = new int[colNum];

            // 0 No. column
            headerName[0] = string.Empty;
            headerText[0] = "STT";
            headerWidth[0] = 4;

            int index = 1;

            // Get column export
            foreach (GridVisibleColumnDescriptor column in gridData.TableDescriptor.VisibleColumns)
            {
                if (column.Name == "TrackingState" || column.Name == "CheckSelect" || column.Name == "Select")
                {
                    continue;
                }

                headerName[index] = column.Name;
                headerText[index] = gridData.TableDescriptor.Columns[column.Name].HeaderText;
                headerWidth[index] = gridData.TableDescriptor.Columns[column.Name].Width / 7;

                index++;
            }

            // Resize column number
            colNum = index;

            Array.Resize(ref headerName, index);
            Array.Resize(ref headerText, index);
            Array.Resize(ref headerWidth, index);

            // Write header
            WriteColumHeader(xlsSheet, rowIndex, colStart, headerText, headerWidth, gridData.TableModel.RowHeights[1]);
            CellStyleBackGround(xlsSheet, rowIndex, colStart, rowIndex, colStart + colNum - 1);

            #endregion

            #region ---- Content ----

            int stt = 0;
            string columnName = string.Empty;
            object objValue = null;
            GridColumnDescriptor gridColumn = null;

            // Write record
            foreach (Record record in gridData.Table.Records)
            {
                if (!record.IsRecord())
                {
                    continue;
                }

                rowIndex++;
                colIndex = colStart;

                // STT
                stt++;
                xlsSheet.Range[rowIndex, colIndex, rowIndex, colIndex].Text = stt.ToString();
                xlsSheet.Range[rowIndex, colIndex, rowIndex, colIndex].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

                // Write cell
                for (int i = 1; i < headerName.Length; i++)
                {
                    colIndex++;

                    // Get column name
                    columnName = headerName[i];

                    // Get value in cell                    
                    objValue = record.GetValue(columnName);

                    gridColumn = gridData.TableDescriptor.Columns[columnName];

                    // Cell is datetime value
                    if (gridColumn.Appearance.AnyRecordFieldCell.CellValueType == typeof(DateTime) && objValue != null)
                    {
                        //objValue = ((DateTime)(objValue)).ToString("dd/MM/yyyy");
                    }

                    objValue = usingStyle ? gridData.TableModel[rowIndex - 1, i].FormattedText : objValue;

                    xlsSheet.Range[rowIndex, colIndex, rowIndex, colIndex].Text = objValue != null ? objValue.ToString() : string.Empty;

                    // Cell align center
                    if (gridColumn.Appearance.AnyRecordFieldCell.HorizontalAlignment == GridHorizontalAlignment.Center)
                    {
                        CellAlighment(xlsSheet, rowIndex, colIndex, rowIndex, colIndex, ExcelHAlign.HAlignCenter, ExcelVAlign.VAlignCenter);
                    }

                    // Cell align right
                    if (gridColumn.Appearance.AnyRecordFieldCell.HorizontalAlignment == GridHorizontalAlignment.Right)
                    {
                        CellAlighment(xlsSheet, rowIndex, colIndex, rowIndex, colIndex, ExcelHAlign.HAlignRight, ExcelVAlign.VAlignCenter);
                    }


                }
            }

            #endregion

            // Draw border
            DrawTableBorder(xlsSheet, rowStart, colStart, rowIndex, colStart + colNum - 1, ExcelLineStyle.Thin);

            // Hide grid line
            xlsSheet.IsGridLinesVisible = false;

            int maxWidth = 0;

            // Calculate with page
            foreach (int intColumn in headerWidth)
            {
                maxWidth += intColumn;
            }

            if (maxWidth >= 100)
            {
                PageSetup(xlsSheet, ExcelPageOrientation.Landscape, false);
            }
            else
            {
                PageSetup(xlsSheet, ExcelPageOrientation.Portrait, false);
            }

            return SaveExcel(xslEngine, isPrint, pSheetName);
        }

        /// <summary>
        /// Writes the colum header.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="arrColName">Name of the arr col.</param>
        /// <param name="arrColWidth">Width of the arr col.</param>
        /// <param name="rowHeight">Height of the row.</param>
        /// <Author>LONG LY</Author>
        /// <Date>25/07/2011</Date>
        private void WriteColumHeader(IWorksheet xlsSheet, int startRow, int startCol, string[] arrColName, int[] arrColWidth, int rowHeight)
        {
            for (int i = 0; i < arrColName.Length; i++)
            {
                xlsSheet.Range[startRow, startCol + i].Text = arrColName[i];
                xlsSheet.Range[startRow, startCol + i].ColumnWidth = arrColWidth[i];
            }

            xlsSheet.Range[startRow, 1].RowHeight = rowHeight;
            CellStyle(xlsSheet, startRow, startCol, startRow, startCol + arrColName.Length, FONT_NAME, CAPTION_FONT_SIZE, true, false);
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].VerticalAlignment = ExcelVAlign.VAlignCenter;
            xlsSheet.Range[startRow, startCol, startRow, startCol + arrColName.Length].WrapText = true;
        }

        /// <summary>
        /// Draws the table border.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="lineStyle">The line style.</param>
        /// <Author>LONG LY</Author>
        /// <Date>25/07/2011</Date>
        private void DrawTableBorder(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelLineStyle lineStyle)
        {
            xlsSheet.IsGridLinesVisible = false;

            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders.LineStyle = lineStyle;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            xlsSheet[startRow, startCol, endRow, endCol].CellStyle.Borders.ColorRGB = Color.Black;

            xlsSheet.Range[startRow, startCol, endRow, endCol].WrapText = true;
        }

        #region ---- Format -----

        /// <summary>
        /// Colses the alighment.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="HAlight">The H alight.</param>
        private void ColsAlighment(IWorksheet xlsSheet, int[] cols, ExcelHAlign HAlight)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                ColAlighment(xlsSheet, cols[i], HAlight);
            }
        }

        /// <summary>
        /// Cols the alighment.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="col">The start col.</param>
        /// <param name="HAlight">The H alight.</param>
        private void ColAlighment(IWorksheet xlsSheet, int col, ExcelHAlign HAlight)
        {
            xlsSheet.Range[1, col, ROW_MAXIMUM, col].CellStyle.HorizontalAlignment = HAlight;
            xlsSheet.Range[1, col, ROW_MAXIMUM, col].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
        }

        /// <summary>
        /// Cells the alighment.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="HAlight">The H alight.</param>
        /// <param name="VAlight">The V alight.</param>
        private void CellAlighment(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelHAlign HAlight, ExcelVAlign VAlight)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.HorizontalAlignment = HAlight;
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.VerticalAlignment = VAlight;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Bold = isBold;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="isItalic">if set to <c>true</c> [is italic].</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, bool isItalic)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold);
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Italic = isItalic;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="color">The color.</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, ExcelKnownColors color)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Color = color;
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="color">The color.</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, ExcelKnownColors color)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold);
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, color);
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="isItalic">if set to <c>true</c> [is italic].</param>
        /// <param name="color">The color.</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, bool isBold, bool isItalic, ExcelKnownColors color)
        {
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold, isItalic);
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, color);
        }

        /// <summary>
        /// Cells the style.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="isBold">if set to <c>true</c> [is bold].</param>
        /// <param name="isItalic">if set to <c>true</c> [is italic].</param>
        private void CellStyle(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol, string fontName, int fontSize, bool isBold, bool isItalic)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.FontName = fontName;
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.Font.Size = fontSize;
            CellStyle(xlsSheet, startRow, startCol, endRow, endCol, isBold, isItalic);
        }

        /// <summary>
        /// Cells the style back ground.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="startRow">The start row.</param>
        /// <param name="startCol">The start col.</param>
        /// <param name="endRow">The end row.</param>
        /// <param name="endCol">The end col.</param>
        private void CellStyleBackGround(IWorksheet xlsSheet, int startRow, int startCol, int endRow, int endCol)
        {
            xlsSheet.Range[startRow, startCol, endRow, endCol].CellStyle.ColorIndex = ExcelKnownColors.Grey_25_percent;
        }

        #endregion ---- Format -----

        /// <summary>
        /// Pages the setup.
        /// </summary>
        /// <param name="xlsSheet">The XLS sheet.</param>
        /// <param name="PageOrientation">The page orientation.</param>
        /// <param name="isSmall">if set to <c>true</c> [is small].</param>
        private void PageSetup(IWorksheet xlsSheet, ExcelPageOrientation PageOrientation, bool isSmall)
        {
            // Setting the file name in the Footer
            xlsSheet.PageSetup.RightFooter = "&P";
            // Setting Page Number
            xlsSheet.PageSetup.AutoFirstPageNumber = false;
            xlsSheet.PageSetup.FirstPageNumber = 1;
            // Setting Page Margins
            xlsSheet.PageSetup.TopMargin = 0.35;
            xlsSheet.PageSetup.BottomMargin = 0.5;
            xlsSheet.PageSetup.LeftMargin = 0.35;
            xlsSheet.PageSetup.RightMargin = 0.2;

            xlsSheet.PageSetup.HeaderMargin = 0.3;
            xlsSheet.PageSetup.FooterMargin = 0.5;
            // Setting the Paper Type
            if (isSmall)
            {
                xlsSheet.PageSetup.PaperSize = ExcelPaperSize.PaperA5;
            }
            else
            {
                xlsSheet.PageSetup.PaperSize = ExcelPaperSize.PaperA4;
            }

            // Setting the Page Orientation as Portrait or Landscape
            xlsSheet.PageSetup.Orientation = PageOrientation;
        }

        /// <summary>
        /// Saves the excel.
        /// </summary>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        /// <returns></returns>
        private string SaveExcel(ExcelEngine xslEngine, bool isPrint, string defaultName = "", bool usingStyle = false)
        {
            string result = string.Empty;

            try
            {
                if (isPrint)
                {
                    result = Path.GetTempFileName() + ".xls";
                    _workBook.SaveAs(result);
                }
                else
                {
                    string extension = "xsl";
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Files(*.xls)|*.xls";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.DefaultExt = "." + extension;
                    saveFileDialog.FileName = defaultName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
                    {
                        _workBook.Version = (ExcelVersion.Excel97to2003);
                        _workBook.SaveAs(saveFileDialog.FileName);
                        if (MessageBox.Show("Mở file vừa xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = saveFileDialog.FileName;

                            result = saveFileDialog.FileName;

                            proc.Start();
                        }
                    }
                }

                _workBook.Close();
            }
            catch
            { }
            finally
            {
                xslEngine.Dispose();
            }

            return result;
        }

        #endregion

        #region ---- Export Excel Template ----

        #region ---- Constants ----

        #region ---- Template ----

        // Tuyen Dung
        public const string T_KeHoachTuyenDung = "KeHoachTD";
        public const string T_PhieuYeuCau = "PhieuYeuCau";
        public const string T_ThongBao = "ViTriTD";
        public const string T_DanhSachUvDau = "UngVien";
        public const string T_NhanVien = "NhanVien";
        public const string T_ThuViec = "ThuViec";
        public const string T_BangLuong = "BangLuong";
        public const string T_PhieuLuong = "PhieuLuong";


        #endregion

        #region ---- Variables ----

        // Utility                        
        private const string TMP_SHEET = "TMP";
        private const string TMP_ROW = "[TMP]";

        private const string V_PHONGBAN = "%PhongBan";
        private const string V_QUY = "%Quy";
        private const string V_NAM = "%Nam";

        private const string V_TONGSO = "%TongSo";
        private const string V_NGAYTHANGANAM = "%NgayThangNam";

        // ke Hoach thu viec
        private const string V_HOTEN = "%HoTen";
        private const string V_CHUCVU = "%ChucVu";
        private const string V_NGAYTHUVIEC = "%NgayThuViec";
        private const string V_NGUOIQUANLY = "%NguoiQuanLy";
        private const string V_QUANLYCV = "%QuanLyCV";
        private const string V_THUVIECDENNGAY = "%ThuViecDenNgay";


        // Phieu yeu cau
        private const string V_NOIDUNGYEUCAU = "%NoiDungYeuCau";
        private const string V_TENCHUCDANH = "%TenChucDanh";
        private const string V_SOLUONG = "%SoLuong";
        private const string V_TRINHDO = "%TenTrinhDo";
        private const string V_SOLUONGNAM = "%SoLuongNam";
        private const string V_TUOITU = "%TuoiTu";
        private const string V_CHUYENNGANH = "%TenChuyenNganh";
        private const string V_KINHNGHIEMLAMVIEC = "%SoNamKinhNghiem";
        private const string V_NGAYCANNHANSU = "%NgayCanNhanSu";
        private const string V_LYDO = "%TenLyDo";
        private const string V_NGOAINGU = "%TenNgoaiNgu";
        private const string V_TINHOC = "%TenTrinhDoTinHoc";
        private const string V_YEUCAUCANTHIET = "%YeuCauCanThiet";
        private const string V_YEUCAUSUCKHOE = "%YeuCauSucKhoe";
        private const string V_TINHTRANGHONNHAN = "%TenTinhTrangHonNhan";
        private const string V_YEUCAUKHAC = "%YeuCauKhac";
        private const string V_GHICHU = "%GhiChu";
        #endregion

        #region ---- Phieu Luong ----
        private const string V_HOVATEN = "%HoVaTen";
        private const string V_THANGNAM = "%ThangNam";
        private const string V_CHUCDANH = "%ChucDanh";
        private const string V_TENPHONGBAN = "PhongBan";
        private const string V_LUONGCANBAN = "%LuongCanBan";
        private const string V_HESOLUONG = "%HeSoLuong";
        private const string V_HESOCHUCVU = "%HeSoChucVu";
        private const string V_HESOCHUYENMON = "%HeSoChuyenMon";
        private const string V_HESOTRACHNHIEM = "%HeSoTrachNhiem";
        private const string V_TONGHESO = "%TongHeSo";
        private const string V_NGAYCONG = "%NgayCong";
        private const string V_NGAYNGHI = "%NgayNghi";
        private const string V_TIENHESOLUONG = "%TienHeSoLuong";
        private const string V_TIENNGAYNGHI = "%TienNgayNghi";
        private const string V_TIENTHUONGLE = "%TienThuongLe";
        private const string V_TIENPHAT = "%TienPhat";
        private const string V_THUONGKHAC = "%ThuongKhac";
        private const string V_PHUCAPKHAC = "%PhuCapKhac";
        private const string V_GIAMTRUKHAC = "%GiamTruKhac";
        private const string V_TAMUNG = "%TamUng";
        private const string V_BAOHIEM = "%BaoHiem";
        private const string V_THUCLANH = "%ThucLanh";


        #endregion

        #endregion

        #region ---- Private methods ----

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="pIsPrint">if set to <c>true</c> [p is print].</param>
        /// <returns></returns>
        private string SaveFile(bool pIsPrint = true)
        {
            string result = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Constants.FILTER_EXCEL;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = Constants.FILE_EXT_XLS;

            if (!pIsPrint && saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
            {
                result = saveFileDialog.FileName;
            }

            return result;
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="pPathFile">The p path file.</param>
        public void OpenFile(string pPathFile)
        {
            if (string.IsNullOrEmpty(pPathFile))
            {
                return;
            }

            if (UICommon.ShowMsgConfirm("MSG023") == DialogResult.Yes)
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = pPathFile;
                proc.Start();
            }
        }

        /// <summary>
        /// Replace the specified value in work sheet.
        /// </summary>
        /// <param name="workSheet">The work sheet.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="replaceValue">The replace value.</param>
        private static void Replace(IWorksheet workSheet, string findValue, string replaceValue)
        {
            // Find and replace
            if (workSheet != null && !string.IsNullOrEmpty(findValue))
            {
                // Get current cells
                IRange[] cells = workSheet.Range.Cells;
                IRange range = null;

                // Loop cells to replace
                for (int i = 0; i < cells.Count(); i++)
                {
                    // Current cell
                    range = cells[i];

                    // Find and replace values
                    if (range != null && range.DisplayText.Contains(findValue))
                    {
                        range.Text = range.Text.Replace(findValue, replaceValue);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Prints the excel.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void PrintExcel(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;

            try
            {
                wb = excelApp.Workbooks.Open(fileName);

                if (wb != null)
                {
                    // Show print preview
                    excelApp.Visible = true;
                    wb.PrintPreview(true);
                }
            }
            catch (Exception ex)
            {
                //ShowMessage
            }
            finally
            {
                // Cleanup:
                GC.Collect();
                GC.WaitForPendingFinalizers();

                wb.Close(false, Type.Missing, Type.Missing);
                Marshal.FinalReleaseComObject(wb);

                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);
            }
        }

        /// <summary>
        /// Builds the replacer current date.
        /// </summary>
        /// <param name="pReplacer">The p replacer.</param>
        private void BuildReplacerCurrentDate(ref Dictionary<string, string> pReplacer)
        {
            if (pReplacer != null)
            {
                DateTime currentDate = CacheData.Context.GetSystemDate();
                string ngay = "Ngày " + currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;
                pReplacer.Add(V_NGAYTHANGANAM, ngay);

            }
        }

        /// <summary>
        /// Outs the simple report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <param name="replaceValues">The replace values.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private bool OutSimpleReport<T>(List<T> dataSource, Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Fill variables
            markProcessor.AddVariable(viewName, dataSource);



            // End template
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            // Delete temporary row
            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            // Delete
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;

            fileName = file;

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }

        /// <summary>
        /// Outs the group report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="groupData">The group data.</param>
        /// <param name="replaceValues">The replace values.</param>
        /// <param name="groupBox">The group box.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        private bool OutGroupReport<T>(List<IGrouping<int, T>> groupData, Dictionary<string, string> replaceValues,
                                        string groupBox, string viewName, bool isPrintPreview,ref string fileName, string groupName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            // Get sheets
            IWorksheet workSheet = workBook.Worksheets[0];
            IWorksheet tmpSheet = workBook.Worksheets.Create(TMP_SHEET);

            // Copy template of group to temporary sheet
            IRange range = workSheet.Range[groupBox];
            int rowCount = range.Rows.Count();
            IRange tmpRange = tmpSheet.Range[groupBox];
            range.CopyTo(tmpRange, ExcelCopyRangeOptions.All);

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Loop data
            for (int i = groupData.Count - 1; i >= 0; i--)
            {
                IGrouping<int, T> group = groupData[i];
                List<T> listMember = group.ToList();

                // Create template maker
                ITemplateMarkersProcessor markProcess = workSheet.CreateTemplateMarkersProcessor();

                // Fill data into templates
                if (listMember.Count > 0)
                {
                     //markProcess.AddVariable(groupName,CacheData.GetTenChucDanh(group.Key));
                    Replace(workSheet, groupName, CacheData.GetTenChucDanh(group.Key));
                    markProcess.AddVariable(viewName, listMember);
                    markProcess.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
                }
                else
                {
                    markProcess.AddVariable(groupName, string.Empty);
                    markProcess.ApplyMarkers(UnknownVariableAction.Skip);
                }

                // Insert template rows
                if (i > 0)
                {
                    workSheet.InsertRow(range.Row, rowCount);
                    tmpRange.CopyTo(workSheet.Range[groupBox], ExcelCopyRangeOptions.All);
                }
            }

            // Find row
            IRange[] rowSet = workSheet.FindAll(TMP_ROW, ExcelFindType.Text);

            //// Delete row
            for (int i = rowSet.Count() - 1; i >= 0; i--)
            {
                range = rowSet[i];

                // Delete
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }
            }

            
                fileName = Path.GetTempFileName() + Constants.FILE_EXT_XLS;
           

            // Remove temporary sheet
            workBook.Worksheets.Remove(tmpSheet);

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(fileName))
            {
                workBook.SaveAs(fileName);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(fileName);
                File.Delete(fileName);
            }

            return result;
        }

        /// <summary>
        /// Export the List of Type
        /// </summary>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private bool OutReport<T>(List<IGrouping<string, T>> groupData, Dictionary<string, string> replaceValues,
                                    string groupBox, string viewName, bool isPrintPreview, string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);

            // Get sheets
            IWorksheet workSheet = workBook.Worksheets[0];
            IWorksheet tmpSheet = workBook.Worksheets.Create(TMP_SHEET);

            // Copy template of group to temporary sheet
            IRange range = workSheet.Range[groupBox];
            int rowCount = range.Rows.Count();
            IRange tmpRange = tmpSheet.Range[groupBox];
            range.CopyTo(tmpRange, ExcelCopyRangeOptions.All);

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Loop data
            for (int i = groupData.Count - 1; i >= 0; i--)
            {
                IGrouping<string, T> group = groupData[i];
                List<T> listMember = group.ToList();

                // Create template maker
                ITemplateMarkersProcessor markProcess = workSheet.CreateTemplateMarkersProcessor();

                // Fill data into templates
                if (listMember.Count > 0)
                {
                    markProcess.AddVariable(viewName, listMember);
                    markProcess.ApplyMarkers();
                }
                else
                {
                    markProcess.ApplyMarkers(UnknownVariableAction.Skip);
                }

                // Insert template rows
                if (i > 0)
                {
                    workSheet.InsertRow(range.Row, rowCount);
                    tmpRange.CopyTo(workSheet.Range[groupBox], ExcelCopyRangeOptions.All);
                }
            }

            // Find row
            IRange[] rowSet = workSheet.FindAll(TMP_ROW, ExcelFindType.Text);

            // Delete row
            for (int i = rowSet.Count() - 1; i >= 0; i--)
            {
                range = rowSet[i];

                // Delete
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }
            }

            // Get file name
            if (isPrintPreview)
            {
                file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;
            }
            else
            {
                file = fileName;
            }

            // Remove temporary sheet
            workBook.Worksheets.Remove(tmpSheet);

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }

        /// <summary>
        /// Gets the template stream.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <returns></returns>
        private MemoryStream GetTemplateStream(string viewName)
        {
            MemoryStream stream = null;
            byte[] arrByte = new byte[0];

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMPLATES))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMPLATES);
            }

            //Declare path App/Templates/Excels
            string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH; //+ Constants.FOLDER_EXCELS + Constants.CHAR_FLASH;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();

            // Get template by view name
            switch (viewName)
            {
                #region ---- Tuyen Dung ----

                case T_KeHoachTuyenDung:
                    path += Constants.FILE_KEHOACHTD;
                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_KEHOACHTD).NoiDung.ToArray();
                    break;
                case T_PhieuYeuCau:
                    path += Constants.FILE_PHIEUYEUCAU;
                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_PHIEUYEUCAU).NoiDung.ToArray();
                    break;

                case T_ThongBao:
                    path += Constants.FILE_THONGBAOTUYENDUNG;
                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_THONGBAOTUYENDUNG).NoiDung.ToArray();
                    break;

                case T_ThuViec:
                    path += Constants.FILE_CHUONGTRINHTHUVIEC;
                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_CHUONGTRINHTHUVIEC).NoiDung.ToArray();
                    break;

                case T_DanhSachUvDau:
                    path += Constants.FILE_DANHSACHUNGVIENDAU;
                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_DANHSACHUNGVIENDAU).NoiDung.ToArray();
                    break;
                #endregion

                #region ---- Nhan Vien----

                case T_NhanVien:
                    path += Constants.FILE_DANHSACHNHANVIEN;
                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_DANHSACHNHANVIEN).NoiDung.ToArray();
                    break;

                #endregion

                #region ---- Tinh Luong ----

                case T_BangLuong:

                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_BANGLUONG).NoiDung != null ? _busBieuMau.GetBieuMauByMau(Constants.FILE_BANGLUONG).NoiDung.ToArray() : null;
                    break;

                case T_PhieuLuong:

                    arrByte = _busBieuMau.GetBieuMauByMau(Constants.FILE_PHIEULUONG).NoiDung != null ? _busBieuMau.GetBieuMauByMau(Constants.FILE_PHIEULUONG).NoiDung.ToArray() : null;
                    break;

                #endregion


            }

            // Get stream
            if (arrByte.Count() > 0)
            {
                stream = new MemoryStream(arrByte);
            }

            return stream;
        }

        /// <summary>
        /// Replaces the data work sheet.
        /// </summary>
        /// <param name="replaceValues">The replace values.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private bool ReplaceDataWorkSheet(Dictionary<string, string> replaceValues, string viewName, bool isPrintPreview, ref string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }


            file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;

            fileName = file;

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }

        /// <summary>
        /// Exports the thong bao tuyen dung.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="replaceValues">The replace values.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>05/07/2011</Date>
        private bool ExportThongBaoTuyenDung(List<NoiDung> dataSource, string viewName, Dictionary<string, string> replaceValues, bool isPrintPreview, ref string fileName)
        {
            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(viewName);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            // Replace value
            if (replaceValues != null && replaceValues.Count > 0)
            {
                // Find and replace values
                foreach (KeyValuePair<string, string> replacer in replaceValues)
                {
                    Replace(workSheet, replacer.Key, replacer.Value);
                }
            }

            // Fill variables
            markProcessor.AddVariable(viewName, dataSource);



            // End template
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            // Delete temporary row
            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);

            // Delete
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;

            fileName = file;

            // Output file
            if (!FileCommon.IsFileOpenOrReadOnly(file))
            {
                workBook.SaveAs(file);
                result = true;
            }

            // Close
            workBook.Close();
            engine.Dispose();

            // Print preview
            if (result && isPrintPreview)
            {
                PrintExcel(file);
                File.Delete(file);
            }

            return result;
        }

        #endregion

        #region ---- Business ----

        #region ---- Tuyen Dung ----

        /// <summary>
        /// Exports the ke hoach tuyen dung.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="pThongTin">The p thong tin.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        public bool ExportKeHoachTuyenDung(List<TD_ChiTietKeHoachTuyenDung> dataSource, Dictionary<string, string> pThongTin, ref string fileName, bool isPrintPreview)
        {
            TD_ChiTietKeHoachTuyenDungBLL _busChiTiet = new TD_ChiTietKeHoachTuyenDungBLL();

            // Check if data is null
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }

            // Set the So thu tu
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i;
            }
            string tongSo = dataSource.Sum(t => t.SoLuong).Value.ToString();
            // Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add(V_PHONGBAN, pThongTin["PhongBan"]);
            replacer.Add(V_QUY, pThongTin["Quy"]);
            replacer.Add(V_NAM, pThongTin["Nam"]);
            replacer.Add(V_TONGSO, tongSo);

            BuildReplacerCurrentDate(ref replacer);

            return OutSimpleReport(dataSource, replacer, T_KeHoachTuyenDung, isPrintPreview, ref fileName);
        }

        /// <summary>
        /// Exports the phieu yeu cau tuyen dung.
        /// </summary>
        /// <param name="pPhieuYeuCau">The p phieu yeu cau.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        public bool ExportPhieuYeuCauTuyenDung(TD_PhieuYeuCauTuyenDung pPhieuYeuCau, ref string fileName, bool isPrintPreview)
        {
            TD_ChiTietKeHoachTuyenDungBLL _busChiTiet = new TD_ChiTietKeHoachTuyenDungBLL();

            // Check if data is null
            if (pPhieuYeuCau == null)
            {
                return false;
            }

            //string tongSo = pPhieuYeuCau.SoLuong;
            // Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            string tuoiTu = pPhieuYeuCau.TuoiTu + " - " + pPhieuYeuCau.DenTuoi;

            replacer.Add(V_PHONGBAN, pPhieuYeuCau.TenPhongBan);
            replacer.Add(V_QUY, pPhieuYeuCau.Quy.ToString());
            replacer.Add(V_NAM, pPhieuYeuCau.Nam.ToString());
            replacer.Add(V_NOIDUNGYEUCAU, pPhieuYeuCau.TenPhieuYeuCau);
            replacer.Add(V_TENCHUCDANH, pPhieuYeuCau.TenChucDanh);
            replacer.Add(V_SOLUONG, pPhieuYeuCau.SoLuong.HasValue ? pPhieuYeuCau.SoLuong.ToString() : string.Empty);
            replacer.Add(V_TRINHDO, pPhieuYeuCau.TenTrinhDo);
            replacer.Add(V_SOLUONGNAM, pPhieuYeuCau.SoLuongNam.HasValue ? pPhieuYeuCau.SoLuongNam.ToString() : string.Empty);
            replacer.Add(V_TUOITU, tuoiTu);
            replacer.Add(V_CHUYENNGANH, pPhieuYeuCau.TenChuyenNganh);
            replacer.Add(V_KINHNGHIEMLAMVIEC, pPhieuYeuCau.SoNamKinhNghiem.HasValue ? pPhieuYeuCau.SoNamKinhNghiem + " năm" : string.Empty);
            replacer.Add(V_NGAYCANNHANSU, pPhieuYeuCau.NgayCanNhanSu.HasValue ? pPhieuYeuCau.NgayCanNhanSu.Value.ToString("dd/MM/yyyy") : string.Empty);
            replacer.Add(V_NGOAINGU, pPhieuYeuCau.TenTrinhDoNgoaiNgu);
            replacer.Add(V_TINHOC, pPhieuYeuCau.TenTrinhDoTinHoc);
            replacer.Add(V_YEUCAUCANTHIET, pPhieuYeuCau.YeuCauCanThiet);
            replacer.Add(V_YEUCAUSUCKHOE, pPhieuYeuCau.YeuCauSucKhoe);
            replacer.Add(V_YEUCAUKHAC, pPhieuYeuCau.YeuCauKhac);
            replacer.Add(V_GHICHU, pPhieuYeuCau.GhiChu);
            replacer.Add(V_LYDO, pPhieuYeuCau.TenLyDo);
            replacer.Add(V_TINHTRANGHONNHAN, pPhieuYeuCau.TenTinhTrangHonNhan);


            BuildReplacerCurrentDate(ref replacer);

            return ReplaceDataWorkSheet(replacer, T_PhieuYeuCau, isPrintPreview, ref fileName);
        }

        /// <summary>
        /// Exports the thong bao tuyen dung.
        /// </summary>
        /// <param name="plist">The plist.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>16/06/2011</Date>
        public bool ExportThongBaoTuyenDung(List<IGrouping<int, TD_PhieuYeuCauTuyenDung>> plist, ref string fileName, bool isPrintPreview)
        {
            List<NoiDung> listNoiDung = new List<NoiDung>();
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            IGrouping<string, List<string>> listYeuCau;
            int STT = 1;
            string ChucDanh = string.Empty;
            string NoiDung = string.Empty;
            int SoLuong = 0;
            string yeuCau;
            BuildReplacerCurrentDate(ref replacer);

            return OutGroupReport(plist, replacer, "C21:G23", T_ThongBao, false,ref fileName, "%TenChucDanh");

            //// Thay doi Thong bao tuyen dung
            foreach (IGrouping<int, TD_PhieuYeuCauTuyenDung> g in plist)
            {
                ChucDanh = string.Empty;
                NoiDung = string.Empty;
                SoLuong = 0;
                yeuCau = string.Empty;


                List<TD_PhieuYeuCauTuyenDung> subList = g.ToList();
                foreach (TD_PhieuYeuCauTuyenDung item in subList)
                {
                    SoLuong += item.SoLuong.HasValue ? item.SoLuong.Value : 0;
                    yeuCau += item.YeuCauCanThiet + "\n";
                }

                ChucDanh = CacheData.GetTenChucDanh(g.Key);

                NoiDung = STT + "." + " " + ChucDanh + " Số lượng " + SoLuong + " người";
                yeuCau = STT + "." + " " + ChucDanh + ": " + yeuCau + ", ";
                NoiDung _noiDung = new NoiDung();
                _noiDung.ViTri = NoiDung;
                _noiDung.YeuCau = yeuCau;
                listNoiDung.Add(_noiDung);

                STT++;
            }

            return ExportThongBaoTuyenDung(listNoiDung, T_ThongBao, replacer, isPrintPreview, ref fileName);
        }

        /// <summary>
        /// Exports the danh sach ung vien dau.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="pThongTin">The p thong tin.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>29/06/2011</Date>
        public bool ExportDanhSachUngVienDau(List<TD_UngVien> dataSource, Dictionary<string, string> pThongTin, ref string fileName, bool isPrintPreview)
        {
            TD_ChiTietKeHoachTuyenDungBLL _busChiTiet = new TD_ChiTietKeHoachTuyenDungBLL();

            // Check if data is null
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }

            // Set the So thu tu
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            string tongSo = dataSource.Count.ToString();
            // Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add(V_PHONGBAN, pThongTin["PhongBan"]);
            replacer.Add(V_QUY, pThongTin["Quy"]);
            replacer.Add(V_NAM, pThongTin["Nam"]);
            replacer.Add(V_TONGSO, tongSo);

            BuildReplacerCurrentDate(ref replacer);

            return OutSimpleReport(dataSource, replacer, T_DanhSachUvDau, isPrintPreview, ref fileName);
        }

        /// <summary>
        /// Exports the danh sach nhan vien theo phong ban.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="pThongTin">The p thong tin.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>29/06/2011</Date>
        public bool ExportDanhSachNhanVienTheoPhongBan(List<NV_NhanVien> dataSource, Dictionary<string, string> pThongTin, ref string fileName, bool isPrintPreview)
        {
            TD_ChiTietKeHoachTuyenDungBLL _busChiTiet = new TD_ChiTietKeHoachTuyenDungBLL();

            // Check if data is null
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }

            // Set the So thu tu
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            string tongSo = dataSource.Count.ToString();
            // Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add(V_PHONGBAN, pThongTin["PhongBan"]);
            replacer.Add(V_NAM, pThongTin["Nam"]);
            replacer.Add(V_TONGSO, tongSo);

            BuildReplacerCurrentDate(ref replacer);

            return OutSimpleReport(dataSource, replacer, T_NhanVien, isPrintPreview, ref fileName);
        }

        /// <summary>
        /// Exports the ke hoach thu viec.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="pThongTin">The p thong tin.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>29/06/2011</Date>
        public bool ExportKeHoachThuViec(List<TD_YeuCauCongViec> dataSource, Dictionary<string, string> pThongTin, ref string fileName, bool isPrintPreview)
        {
            TD_ChiTietKeHoachThuViecBLL _busChiTiet = new TD_ChiTietKeHoachThuViecBLL();

            // Check if data is null
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }

            // Set the So thu tu
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i;
            }

            // Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add(V_PHONGBAN, pThongTin["PhongBan"]+".");
            replacer.Add(V_QUY, pThongTin["Quy"]);
            replacer.Add(V_NAM, pThongTin["Nam"]);
            replacer.Add(V_HOTEN, pThongTin["HoTen"].Trim());
            replacer.Add(V_CHUCVU, pThongTin["ChucVu"]);
            replacer.Add(V_NGAYTHUVIEC, pThongTin["NgayThuViec"]);
            replacer.Add(V_NGUOIQUANLY, pThongTin["NguoiQuanLy"]);
            replacer.Add(V_QUANLYCV, pThongTin["QuanLyCV"]);
            replacer.Add(V_THUVIECDENNGAY, pThongTin["ThuViecDenNgay"]);

            BuildReplacerCurrentDate(ref replacer);

            return OutSimpleReport(dataSource, replacer, T_ThuViec, isPrintPreview, ref fileName);
        }

        #endregion

        #region ---- Tinh Luong ----

        /// <summary>
        /// Exports the bang luong nhan vien.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="pThongTin">The p thong tin.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>07/07/2011</Date>
        public bool ExportBangLuongNhanVien(List<TL_BangLuong> dataSource, Dictionary<string, string> pThongTin, ref string fileName, bool isPrintPreview)
        {

            // Check if data is null
            if (dataSource == null || (dataSource != null && dataSource.Count == 0))
            {
                return false;
            }

            // Set the So thu tu
            for (int i = 1; i <= dataSource.Count; i++)
            {
                dataSource[i - 1].STT = i.ToString();
            }
            string tongSo = dataSource.Count.ToString();
            // Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add(V_PHONGBAN, pThongTin["PhongBan"]);
            BuildReplacerCurrentDate(ref replacer);

            return OutSimpleReport(dataSource, replacer, T_BangLuong, isPrintPreview, ref fileName);
        }

        /// <summary>
        /// Exports the bang luong tung nhan vien.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isPrintPreview">if set to <c>true</c> [is print preview].</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>07/07/2011</Date>
        public bool ExportBangLuongTungNhanVien(List<TL_BangLuong> dataSource, string phongBan, ref string fileName, bool isPrintPreview)
        {
            // Format Currency

            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = "đồng";
            vnfi.CurrencyDecimalSeparator = ",";
            vnfi.CurrencyDecimalDigits = 0;

            string file = string.Empty;
            bool result = false;

            // Get template stream
            MemoryStream stream = GetTemplateStream(T_PhieuLuong);

            // Check if data is null
            if (stream == null)
            {
                return false;
            }

            // Create excel engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);


            #region Danh sach tien chi

            IWorksheet workSheetNew = workBook.Worksheets[0];

            foreach (TL_BangLuong phieuLuong in dataSource)
            {

                IWorksheet workSheet = workBook.Worksheets.AddCopy(workBook.Worksheets[0]);
                workSheet.Name = phieuLuong.MaNhanVien;

                ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

                Dictionary<string, string> replacerDetail = new Dictionary<string, string>();

                DateTime currentDate = CacheData.Context.GetSystemDate();

                string ThangNam = phieuLuong.Thang + " NĂM " + phieuLuong.Nam;
                string ngayIn = currentDate.Day + " tháng " + currentDate.Month + " năm " + currentDate.Year;

                string luongCanBan = phieuLuong.MucLuongCoBan.HasValue ? phieuLuong.MucLuongCoBan.Value.ToString("C", vnfi) : "0";
                string heSoLuong = phieuLuong.HeSoLuong.HasValue ? phieuLuong.HeSoLuong.Value.ToString("N") : "0";
                string heSoChucVu = phieuLuong.HeSoChucVu.HasValue ? phieuLuong.HeSoChucVu.Value.ToString("N") : "0";
                string heSoTrachNhiem = phieuLuong.HeSoTrachNhiem.HasValue ? phieuLuong.HeSoTrachNhiem.Value.ToString("N") : "0";
                string heSoChuyenMon = phieuLuong.HeSoChuyenMon.HasValue ? phieuLuong.HeSoChuyenMon.Value.ToString("N") : "0";
                string tongHeSo = phieuLuong.TongHeSo.HasValue ? phieuLuong.TongHeSo.Value.ToString("N") : "0";
                string ngayCong = phieuLuong.SoNgayCong.HasValue ? phieuLuong.SoNgayCong.Value.ToString("N") : "0";
                string ngayNghi = phieuLuong.SoNgayNghi.HasValue ? phieuLuong.SoNgayNghi.Value.ToString("N") : "0";
                string tienHeSoLuong = phieuLuong.TienHeSoLuong.HasValue ? phieuLuong.TienHeSoLuong.Value.ToString("C", vnfi) : "0";
                string tienNgayNghi = phieuLuong.TienNgayNghi.HasValue ? phieuLuong.TienNgayNghi.Value.ToString("C", vnfi) : "0";
                string tienThuongLe = phieuLuong.TienThuongLe.HasValue ? phieuLuong.TienThuongLe.Value.ToString("C", vnfi) : "0";
                string tienPhat = phieuLuong.TienPhat.HasValue ? phieuLuong.TienPhat.Value.ToString("C", vnfi) : "0";
                string thuongKhac = phieuLuong.TienThuongKhac.HasValue ? phieuLuong.TienThuongKhac.Value.ToString("C", vnfi) : "0";
                string phuCapKhac = phieuLuong.PhuCapKhac.HasValue ? phieuLuong.PhuCapKhac.Value.ToString("C", vnfi) : "0";
                string giamTruKhac = phieuLuong.GiamTruKhac.HasValue ? phieuLuong.GiamTruKhac.Value.ToString("C", vnfi) : "0";
                string tamUng = phieuLuong.TamUng.HasValue ? phieuLuong.TamUng.Value.ToString("C", vnfi) : "0";
                string baoHiem = phieuLuong.BaoHiem.HasValue ? phieuLuong.BaoHiem.Value.ToString("C", vnfi) : "0";
                string thucLanh = phieuLuong.ThucLinh.HasValue ? phieuLuong.ThucLinh.Value.ToString("C", vnfi) : "0";

                // Add infor to replace
                replacerDetail.Add(V_THANGNAM, ThangNam);
                replacerDetail.Add(V_HOVATEN, (phieuLuong.HoDem + " " + phieuLuong.Ten).Trim());
                replacerDetail.Add(V_CHUCDANH, phieuLuong.ChucVu);
                replacerDetail.Add(V_TENPHONGBAN, phongBan);
                replacerDetail.Add(V_LUONGCANBAN, luongCanBan);
                replacerDetail.Add(V_HESOLUONG, heSoLuong);
                replacerDetail.Add(V_HESOCHUCVU, heSoChucVu);
                replacerDetail.Add(V_HESOTRACHNHIEM, heSoTrachNhiem);
                replacerDetail.Add(V_HESOCHUYENMON, heSoChuyenMon);
                replacerDetail.Add(V_TONGHESO, tongHeSo);
                replacerDetail.Add(V_NGAYCONG, ngayCong);
                replacerDetail.Add(V_NGAYNGHI, ngayNghi);
                replacerDetail.Add(V_TIENHESOLUONG, tienHeSoLuong);
                replacerDetail.Add(V_TIENNGAYNGHI, tienNgayNghi);
                replacerDetail.Add(V_TIENTHUONGLE, tienThuongLe);
                replacerDetail.Add(V_TIENPHAT, tienPhat);
                replacerDetail.Add(V_THUONGKHAC, thuongKhac);
                replacerDetail.Add(V_PHUCAPKHAC, phuCapKhac);
                replacerDetail.Add(V_GIAMTRUKHAC, giamTruKhac);
                replacerDetail.Add(V_TAMUNG, tamUng);
                replacerDetail.Add(V_BAOHIEM, baoHiem);
                replacerDetail.Add(V_THUCLANH, thucLanh);
                BuildReplacerCurrentDate(ref replacerDetail);



                //Replace value;
                if (replacerDetail != null && replacerDetail.Count > 0)
                {
                    //Find and replace values
                    foreach (KeyValuePair<string, string> replacer in replacerDetail)
                    {
                        Replace(workSheet, replacer.Key, replacer.Value);
                    }
                }

                //End template
                markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
            }
            #endregion

            file = Path.GetTempFileName() + Constants.FILE_EXT_XLS;

            // Out fileName
            fileName = file;


            // Delete 2 template 2 vs 3
            workBook.Worksheets.Remove(0);

            // Save file
            workBook.SaveAs(file);
            result = true;


            // Close
            workBook.Close();
            engine.Dispose();

            return result;
        }



        #endregion

        #endregion

        #endregion

        #region ---- Class ----
        public class NoiDung
        {
            private string _ViTri;
            private string _YeuCau;

            public string YeuCau
            {
                get { return _YeuCau; }
                set { _YeuCau = value; }
            }
            public string ViTri
            {
                get { return _ViTri; }
                set { _ViTri = value; }
            }
        }
        #endregion
    }
}

