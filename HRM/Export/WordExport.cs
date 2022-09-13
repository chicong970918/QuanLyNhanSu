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
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Syncfusion.Pdf.Barcode;
using System.Globalization;
using HRM.Entities;
using HRM.DataAccess.Catalogs;
using HRM.DataAccess.QuanLyNhanVien;


namespace HRM.Class
{
    public class WordExport
    {

        #region ---- Constants & Enum -----

        private const string FILE_HOPDONGLAODONG = "BM08";
        private const string FILE_HOSOUNGVIEN = "BM10";
        private const string FILE_QUYETDINHBONHIEM = "BM07";
        private const string FILE_QUYETDINHKYLUAT = "BM12";
        private const string FILE_QUYETDINHKHENTHUONG = "BM11";
        private const string FILE_QUYETDINHNANGHESOLUONG = "BM13";
        private const string FILE_QUYETDINHNANGHESOCHUYENMON = "BM14";
        private const string FILE_QUYETDINHTHANGCAP = "BM15";
        private const string FILE_QUYETDINHTHOIVIEC = "BM16";
        private const string FILE_HOPDONGTHUVIEC = "BM09";


        private enum Field_CacKhoanTien
        {
            STT,
            NoiDung,
            ChiPhi
        }

        public static HashSet<Enum> Fields = new HashSet<Enum>
        {
            Field_CacKhoanTien.STT,
            Field_CacKhoanTien.NoiDung,
            Field_CacKhoanTien.ChiPhi
        };

        #endregion

        #region ---- The sinh vien

        public void PrintStudentCard(Image imgFile, string pMaSinhVien)
        {
            object missing = System.Type.Missing;

            WordDocument document = new WordDocument();

            //IWParagraph paragraph = document.CreateParagraph();

            //paragraph.AppendPicture(Image.FromFile(pPathFileImage));

            string fileTemp = Global.AppPath + Constants.CHAR_FLASH + Constants.FOLDER_TEMP +
                                Constants.CHAR_FLASH + pMaSinhVien + Constants.FILE_EXT_DOC;

            WTableCell cell = new WTableCell(document);
            MemoryStream mStream = new MemoryStream();

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + Constants.FILE_HinhAnh;

            try
            {
                // Read template
                mStream = new MemoryStream(File.ReadAllBytes(path));
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
            }

            //Image bmp = Image.FromFile(pPathFileImage);
            //Graphics gImage = Graphics.FromImage(bmp);

            //byte[] aaa = File.ReadAllBytes(pPathFileImage);

            foreach (WTextBox textBox in document.TextBoxes)
            {
                // Find barcode textbox
                if (textBox.TextBoxBody.Paragraphs.Count > 0 &&
                    textBox.TextBoxBody.Paragraphs[0].Text == "$HinhAnh")
                {

                    // Clear text "$barcode"
                    textBox.TextBoxBody.Paragraphs.RemoveAt(0);

                    // Add barcode to file
                    textBox.TextBoxBody.AddParagraph().AppendPicture(imgFile);
                    textBox.TextBoxFormat.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    textBox.TextBoxFormat.VerticalAlignment = ShapeVerticalAlignment.Center;
                    break;
                }
            }

            document.Save(fileTemp, FormatType.Doc);

            document.Clone();

            this.PrinPriview(fileTemp);
        }

        #endregion

        #region --- Member Variables ----

        private bool _IsPringPriview = false;

        #endregion

        #region ---- Inner class ----

        public class CacKhoanTien
        {
            public string STT { get; set; }
            public string NoiDung { get; set; }
            public string ChiPhi { get; set; }
        }

        #endregion

        #region --- Private medthods ---

        /// <summary>
        /// Fill cac khoan thu to the document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="fields"></param>
        /// <param name="ObjectCollection"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        private bool AddKhoanThu<T>(ref WordDocument document, HashSet<Enum> fields, List<T> ObjectCollection, string prefix = "@")
        {
            WTable tableRepeart = null;
            WTableRow cloneRow = null;
            int rowIndex = -1;

            bool nextTable = false;
            foreach (WSection section in document.Sections)
            {
                foreach (WTable table in section.Tables)
                {
                    nextTable = false;
                    foreach (WTableRow row in table.Rows)
                    {
                        foreach (WTableCell cell in row.Cells)
                        {
                            if (fields.Count(m => (prefix + m) == cell.LastParagraph.Text) > 0)
                            {
                                cloneRow = row.Clone();
                                rowIndex = row.GetRowIndex();
                                tableRepeart = table;
                                nextTable = true;
                                break;
                            }
                        }

                        if (nextTable)
                            break;
                    }
                }
            }
            if (tableRepeart != null)
            {
                //foreach (T obj in ObjectCollection)
                for (int i = ObjectCollection.Count() - 1; i >= 0; i--)
                {
                    object obj = ObjectCollection[i];
                    foreach (Enum field in fields)
                    {
                        WTableCell cell = tableRepeart.Rows[rowIndex].Cells.OfType<WTableCell>().FirstOrDefault<WTableCell>(m => m.LastParagraph.Text == (prefix + field));
                        if (cell != null)
                        {
                            object objValue = obj.GetType().GetProperty(field.ToString()).GetValue(obj, null);
                            string Text = objValue == null ? string.Empty : objValue.ToString();
                            cell.LastParagraph.Text = string.Empty;
                            cell.LastParagraph.AppendText(Text).CharacterFormat.FontSize = 13;
                        }
                    }
                    //if (ObjectCollection.IndexOf(obj) != ObjectCollection.Count)                    
                    tableRepeart.Rows.Insert(rowIndex, cloneRow.Clone());
                }

                tableRepeart.Rows.RemoveAt(0);

            }
            return true;
        }

        /// <summary>
        /// PrinPreview the document
        /// </summary>
        /// <param name="fileToPrint"></param>
        private void PrinPriview(string fileToPrint)
        {
            object missing = System.Type.Missing;
            object objFile = fileToPrint;
            object readOnly = true;
            object addToRecentOpen = false;

            // Create  a new Word application           
            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            try
            {
                // Create a new file based on our template
                Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Open(ref objFile, ref missing, ref readOnly, ref addToRecentOpen);

                wordApplication.Options.SaveNormalPrompt = false;

                if (wordDocument != null)
                {
                    // Show print preview
                    wordApplication.Visible = true;
                    wordDocument.PrintPreview();
                    wordDocument.Activate();
                    //wordDocument.op
                    while (!_IsPringPriview)
                    {
                        wordDocument.ActiveWindow.View.Magnifier = true;
                        Thread.Sleep(500);
                    }

                    wordDocument.Close(ref missing, ref missing, ref missing);
                    wordDocument = null;
                }
            }
            catch
            {
                //I didn't include a default error handler so i'm just throwing the error
                // throw ex;
            }
            finally
            {
                // Finally, Close our Word application
                wordApplication.Quit(ref missing, ref missing, ref missing);
                wordApplication = null;
            }
        }

        /// <summary>
        /// Manage WordExport_DocumentBeforeClose
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="Cancel"></param>
        private void WordExport_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            _IsPringPriview = false;
        }

        /// <summary>
        /// Merges the specified files to merge.
        /// </summary>
        /// <param name="filesToMerge">The files to merge.</param>
        /// <param name="outputFilename">The output filename.</param>
        /// <param name="insertPageBreaks">if set to <c>true</c> [insert page breaks].</param>
        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            string fileTempate = Global.AppPath + Constants.FOLDER_TEMPLATES +
                                 Constants.CHAR_FLASH + Constants.FILE_NORMAL_DOT;
            Merge(filesToMerge, outputFilename, insertPageBreaks, fileTempate);
        }

        /// <summary>
        /// A function that merges Microsoft Word Documents that uses a template specified by the user
        /// </summary>
        /// <param name="filesToMerge">An array of files that we want to merge</param>
        /// <param name="outputFilename">The filename of the merged document</param>
        /// <param name="insertPageBreaks">Set to true if you want to have page breaks inserted after each document</param>
        /// <param name="documentTemplate">The word document you want to use to serve as the template</param>
        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks, string documentTemplate)
        {
            object defaultTemplate = documentTemplate;
            object missing = System.Type.Missing;
            object pageBreak = Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
            object outputFile = outputFilename;

            // Create  a new Word application
            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            if (filesToMerge.Count() == 1)
                pageBreak = false;
            try
            {
                // Create a new file based on our template
                Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Add(ref defaultTemplate, ref missing, ref missing, ref missing);

                // Make a Word selection object.
                Microsoft.Office.Interop.Word.Selection selection = wordApplication.Selection;

                int index = 0;

                // Loop thru each of the Word documents
                foreach (string file in filesToMerge)
                {
                    // Insert the files to our template
                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);

                    //Do we want page breaks added after each documents?
                    if (insertPageBreaks && index != filesToMerge.Count() - 1)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }

                    index++;
                }

                // Save the document to it's output file.
                wordDocument.SaveAs(ref outputFile, ref missing, ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                // Clean up!
                wordDocument.Close(ref missing, ref missing, ref missing);
                wordDocument = null;
            }
            catch (Exception ex)
            {
                //I didn't include a default error handler so i'm just throwing the error
                throw ex;
            }
            finally
            {
                // Finally, Close our Word application
                wordApplication.Quit(ref missing, ref missing, ref missing);
            }
        }

        /// <summary>
        /// Page setup the word document
        /// </summary>
        /// <param name="document"></param>
        private void PageSetup(ref WordDocument document)
        {
            foreach (WSection section in document.Sections)
            {

                // Setting Page Margins
                section.PageSetup.Margins.Top = 72f;
                section.PageSetup.Margins.Bottom = 90f;
                section.PageSetup.Margins.Left = 72f;
                section.PageSetup.Margins.Right = 72f;

                section.PageSetup.HeaderDistance = 1;
                section.PageSetup.FooterDistance = 1;

                //Setup page size
                section.PageSetup.PageSize = PageSize.A4;

                // Setting the Page Orientation as Portrait or Landscape
                section.PageSetup.Orientation = PageOrientation.Landscape;
            }
        }

        #endregion

        #region ---- Public methods ----

        #region ---- TuyenDung ----

        /// <summary>
        /// Hoes the so ung vien.
        /// </summary>
        /// <param name="pUngVien">The p ung vien.</param>
        /// <Author>LONG LY</Author>
        /// <Date>12/06/2011</Date>
        public void ExportHoSoUngVien(TD_UngVien pUngVien)
        {
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileHoSo = string.Empty;

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;


            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_HOSOUNGVIEN;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();

            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_HOSOUNGVIEN).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            if (pUngVien.HinhAnh != null)
            {
                foreach (WTextBox textBox in document.TextBoxes)
                {
                    // Find barcode textbox
                    if (textBox.TextBoxBody.Paragraphs.Count > 0 &&
                        textBox.TextBoxBody.Paragraphs[0].Text == "$HinhAnh" && pUngVien.HinhAnh != null)
                    {

                        MemoryStream memoryStream = new MemoryStream();
                        memoryStream.Write(pUngVien.HinhAnh.ToArray(), 0, pUngVien.HinhAnh.Length);
                        Image image = Image.FromStream(memoryStream);

                        // Clear text "$barcode"
                        textBox.TextBoxBody.Paragraphs.RemoveAt(0);

                        // Add barcode to file
                        textBox.TextBoxBody.AddParagraph().AppendPicture(image);

                        // Align barcode to center
                        textBox.TextBoxBody.Paragraphs[1].ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        //textBox.TextBoxBody.Paragraphs[0].AppendPicture().
                        break;
                    }
                }
            }



            // AppPath\Temp\MaHoSo.doc
            fileHoSo = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pUngVien.MaUngVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg

            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string soDienThoaiString = pUngVien.SoDienThoai;
            string ngaySinh = pUngVien.NgaySinh.HasValue ? pUngVien.NgaySinh.Value.Day.ToString() : string.Empty;
            string thangSinh = pUngVien.NgaySinh.HasValue ? pUngVien.NgaySinh.Value.Month.ToString() : string.Empty;
            string namSinh = pUngVien.NgaySinh.HasValue ? pUngVien.NgaySinh.Value.Year.ToString() : string.Empty;
            string ngayNhanViec = pUngVien.NgayNhanViec.HasValue ? pUngVien.NgayNhanViec.Value.ToString("dd/MM/yyyy") : string.Empty;
            string luongThuViec = pUngVien.LuongThuViec.HasValue ? pUngVien.LuongThuViec.Value.ToString() : string.Empty;
            string luongSauThuViec = pUngVien.LuongSauThuViec.HasValue ? pUngVien.LuongSauThuViec.ToString() : string.Empty;
            string trinhDoChuyenMon = string.Empty;
 
                trinhDoChuyenMon = CacheData.GettenTrinhDo(pUngVien.IdTrinhDo);
            

            //// Read money
            //string SoTienChu = NumberReader.Read(SoTienSo, Constants.VN_UNIT);

            //noiDungThu = noiDungThu.Remove(noiDungThu.Length - 2, 2);

            string[] fields = new string[] { "MaUngVien", "HoVaTen", "GioiTinh", "NgaySinh", "ThangSinh", "NamSinh"
                                                , "ChucDanh","TrinhDoChuyenMon", "NoiSinh", "DanToc", "TonGiao","QuocTich","DiaChi","SoDienThoai"
                                                ,"SoCMND","NoiCapCMND","Email","TinhTrangHonNhan","NgayNhanViec"
                                                , "LuongThuViec","LuongChinhThuc","GhiChu","Ngay","Thang","Nam"};
            string[] values = new string[] { pUngVien.MaUngVien, pUngVien.HoDem.ToUpper() + " " + pUngVien.Ten.ToUpper(), pUngVien.GioiTinhText,ngaySinh,thangSinh,namSinh,
                                                    pUngVien.ChucDanhText,trinhDoChuyenMon, pUngVien.NoiSinhText,pUngVien.DanTocText,pUngVien.TonGiaoText, pUngVien.QuocTich,pUngVien.DiaChiHienTai, soDienThoaiString,
                                                    pUngVien.CMND,pUngVien.NoiCapCMND,pUngVien.Email,pUngVien.HonNhanText,ngayNhanViec,
                                                    luongThuViec,luongSauThuViec,pUngVien.GhiChu, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileHoSo, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileHoSo);
        }

        #endregion

        #region  ---- Nhan Vien ----

        /// <summary>
        /// Quyets the dinh bo nhiem.
        /// </summary>
        /// <param name="pUngVien">The p ung vien.</param>
        /// <param name="boNhiem">The bo nhiem.</param>
        /// <Author>LONG LY</Author>
        /// <Date>26/06/2011</Date>
        public void QuyetDinhBoNhiem(TD_UngVien pUngVien, NV_QuyetDinhBoNhiem boNhiem)
        {
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileBoNhiem = string.Empty;
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

           //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHBONHIEM;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_QUYETDINHBONHIEM).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pUngVien.MaUngVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string TenPhongBan = CacheData.GetTenPhongBan(pUngVien.IdPhongBan);
            string heSoCV = string.Empty;
            string NgayHieuLuc = boNhiem.NgayHieuLuc.HasValue ? boNhiem.NgayHieuLuc.Value.ToString("dd/MM/yyyy") : string.Empty;
            if (pUngVien.IdChucDanh.HasValue)
            {
                DM_ChucDanh chucDanh = _busChucDanh.GetEntityById(pUngVien.IdChucDanh.Value);
                if (chucDanh != null && chucDanh.HeSoChucVu.HasValue)
                {
                    heSoCV = chucDanh.HeSoChucVu.Value.ToString();
                }
            }

            string[] fields = new string[] { "SoQuyetDinh", "HoVaTen", "ChucVu", "TenPhongBan", "SoCMND", "HeSoChucVu", "NgayHieuLuc", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { boNhiem.SoQuyetDinh.ToString(), pUngVien.HoDem + " " + pUngVien.Ten.Trim(), pUngVien.ChucDanhText, TenPhongBan, pUngVien.CMND, heSoCV, NgayHieuLuc, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileBoNhiem, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileBoNhiem);
        }

        /// <summary>
        /// Quyets the dinh ky luat.
        /// </summary>
        /// <param name="pUngVien">The p ung vien.</param>
        /// <param name="pkyLuat">The pky luat.</param>
        /// <Author>LONG LY</Author>
        /// <Date>26/06/2011</Date>
        public void QuyetDinhKyLuat(NV_NhanVien pNhanVien, NV_QuyetDinhKyLuat pkyLuat)
        {
            NV_HopDongBLL _busHopDong = new NV_HopDongBLL();
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileBoNhiem = string.Empty;
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHKYLUAT;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_QUYETDINHKYLUAT).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string TenPhongBan = CacheData.GetTenPhongBan(pNhanVien.IdPhongBan);
            string heSoCV = string.Empty;
            string NgayHieuLuc = pkyLuat.NgayHieuLuc.HasValue ? pkyLuat.NgayHieuLuc.Value.ToString("dd/MM/yyyy") : string.Empty;
            string tienPhat = "Không";
            string NgayKyHopDong = string.Empty;

            NV_HopDong hopDong = _busHopDong.GetHopDongGanNhat(pNhanVien.Id, 1); // 2 is  the loai hop dong chinh thuc
            if (hopDong != null && hopDong.NgayKy.HasValue)
            {
                NgayKyHopDong = hopDong.NgayKy.Value.ToString("dd/MM/yyyy");
            }
            if (pkyLuat.TienPhat.HasValue)
            {
                tienPhat = pkyLuat.TienPhat.Value.ToString("C", vnfi);
            }
            string[] fields = new string[] { "SoQuyetDinh", "HoVaTen", "ChucVu", "TenPhongBan", "NoiDung", "NgayKyHopDong", "HinhThucKyLuat", "TienPhat", "NgayHieuLuc", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pkyLuat.SoQuyetDinh.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten.Trim(), pNhanVien.TenChucDanh, TenPhongBan, pkyLuat.TenQuyetDinh, NgayKyHopDong, pkyLuat.NoiDung, tienPhat, NgayHieuLuc, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileBoNhiem, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileBoNhiem);
        }

        /// <summary>
        /// Quyets the dinh khen thuong.
        /// </summary>
        /// <param name="pNhanVien">The p nhan vien.</param>
        /// <param name="pKhenThuong">The p khen thuong.</param>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        public void QuyetDinhKhenThuong(NV_NhanVien pNhanVien, NV_QuyetDinhKhenThuong pKhenThuong)
        {
            NV_HopDongBLL _busHopDong = new NV_HopDongBLL();
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileBoNhiem = string.Empty;
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHKHENTHUONG;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_QUYETDINHKHENTHUONG).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string TenPhongBan = CacheData.GetTenPhongBan(pNhanVien.IdPhongBan);
            string heSoCV = string.Empty;
            string NgayHieuLuc = pKhenThuong.NgayHieuLuc.HasValue ? pKhenThuong.NgayHieuLuc.Value.ToString("dd/MM/yyyy") : string.Empty;
            string tienThuong = "Không";
            string NgayKyHopDong = string.Empty;

            NV_HopDong hopDong = _busHopDong.GetHopDongGanNhat(pNhanVien.Id, 1); // 2 is  the loai hop dong chinh thuc
            if (hopDong != null && hopDong.NgayKy.HasValue)
            {
                NgayKyHopDong = hopDong.NgayKy.Value.ToString("dd/MM/yyyy");
            }
            if (pKhenThuong.TienThuong.HasValue)
            {
                tienThuong = pKhenThuong.TienThuong.Value.ToString("C", vnfi);
            }
            string[] fields = new string[] { "SoQuyetDinh", "HoVaTen", "ChucVu", "TenPhongBan", "NoiDung", "NgayKyHopDong", "HinhThucKhenThuong", "TienThuong", "NgayHieuLuc", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pKhenThuong.SoQuyetDinh.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten.Trim(), pNhanVien.TenChucDanh, TenPhongBan, pKhenThuong.TenQuyetDinh, NgayKyHopDong, pKhenThuong.NoiDung, tienThuong, NgayHieuLuc, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileBoNhiem, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileBoNhiem);
        }

        /// <summary>
        /// Quyets the dinh nang he so luong.
        /// </summary>
        /// <param name="pNhanVien">The p nhan vien.</param>
        /// <param name="pHeSoLuong">The p he so luong.</param>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        public void QuyetDinhNangHeSoLuong(NV_NhanVien pNhanVien, NV_QuyetDinhNangHeSoLuong pHeSoLuong)
        {
            NV_HopDongBLL _busHopDong = new NV_HopDongBLL();
            DanhMucChucDanhBLL _busChucVu = new DanhMucChucDanhBLL();
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileBoNhiem = string.Empty;
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHNANGHESOLUONG;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_QUYETDINHNANGHESOLUONG).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string TenPhongBan = CacheData.GetTenPhongBan(pNhanVien.IdPhongBan);
            string NgayHieuLuc = pHeSoLuong.NgayHieuLuc.HasValue ? pHeSoLuong.NgayHieuLuc.Value.ToString("dd/MM/yyyy") : string.Empty;
            string NgayKyHopDong = string.Empty;
            string HeSoLuongHienTai = pHeSoLuong.HeSoLuong.ToString();
            NV_HopDong hopDong = _busHopDong.GetHopDongGanNhat(pNhanVien.Id, 1); // 2 is  the loai hop dong chinh thuc

            if (hopDong != null && hopDong.NgayKy.HasValue)
            {
                NgayKyHopDong = hopDong.NgayKy.Value.ToString("dd/MM/yyyy");
            }

            string[] fields = new string[] { "SoQuyetDinh", "HoVaTen", "ChucVu", "TenPhongBan", "NgayKyHopDong", "HeSoMoi", "NgayHieuLuc", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pHeSoLuong.SoQuyetDinh.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten.Trim(), pNhanVien.TenChucDanh, TenPhongBan, NgayKyHopDong, HeSoLuongHienTai, NgayHieuLuc, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileBoNhiem, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileBoNhiem);
        }

        /// <summary>
        /// Quyets the dinh nang he so chuyen mon.
        /// </summary>
        /// <param name="pNhanVien">The p nhan vien.</param>
        /// <param name="pHSChuyenMon">The p HS chuyen mon.</param>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        public void QuyetDinhNangHeSoChuyenMon(NV_NhanVien pNhanVien, NV_QuyetDinhNangHeSoChuyenMon pHSChuyenMon)
        {
            NV_HopDongBLL _busHopDong = new NV_HopDongBLL();
            DanhMucTrinhDoBLL _busTrinhDo = new DanhMucTrinhDoBLL();
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileBoNhiem = string.Empty;
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

           // string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHNANGHESOCHUYENMON;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_QUYETDINHNANGHESOCHUYENMON).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string TenPhongBan = CacheData.GetTenPhongBan(pNhanVien.IdPhongBan);
            string heSoCMCu = string.Empty;
            string heSoCMMoi = string.Empty;
            string NgayHieuLuc = pHSChuyenMon.NgayHieuLuc.HasValue ? pHSChuyenMon.NgayHieuLuc.Value.ToString("dd/MM/yyyy") : string.Empty;

            
                DM_TrinhDo trinhDo = _busTrinhDo.GetEntityById(pNhanVien.IdTrinhDo);
                DM_TrinhDo trinhDoMoi = _busTrinhDo.GetEntityById(pHSChuyenMon.IdTrinhDo);
                if (trinhDo != null && trinhDo.HeSoChuyenMon.HasValue)
                {
                    heSoCMCu = trinhDo.HeSoChuyenMon.ToString();
                }

                if (trinhDoMoi != null && trinhDoMoi.HeSoChuyenMon.HasValue)
                {
                    heSoCMMoi = trinhDoMoi.HeSoChuyenMon.Value.ToString();
                }
            
            string NgayKyHopDong = string.Empty;

            NV_HopDong hopDong = _busHopDong.GetHopDongGanNhat(pNhanVien.Id, 1); // 2 is  the loai hop dong chinh thuc
            if (hopDong != null && hopDong.NgayKy.HasValue)
            {
                NgayKyHopDong = hopDong.NgayKy.Value.ToString("dd/MM/yyyy");
            }

            string[] fields = new string[] { "SoQuyetDinh", "HoVaTen", "ChucVu", "TenPhongBan", "NgayKyHopDong", "HeSoCu", "HeSoMoi", "NgayHieuLuc", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pHSChuyenMon.SoQuyetDinh.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten.Trim(), pNhanVien.TenChucDanh, TenPhongBan, NgayKyHopDong, heSoCMCu, heSoCMMoi, NgayHieuLuc, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileBoNhiem, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileBoNhiem);
        }

        /// <summary>
        /// Quyets the dinh thang cap.
        /// </summary>
        /// <param name="pNhanVien">The p nhan vien.</param>
        /// <param name="pThangCap">The p thang cap.</param>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        public void QuyetDinhThangCap(NV_NhanVien pNhanVien, NV_QuyetDinhThangChuc pThangCap)
        {
            NV_HopDongBLL _busHopDong = new NV_HopDongBLL();
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileBoNhiem = string.Empty;
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHTHANGCAP;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_QUYETDINHTHANGCAP).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string TenPhongBan = CacheData.GetTenPhongBan(pNhanVien.IdPhongBan);
            string heSoCDCu = string.Empty;
            string heSoCDMoi = string.Empty;
            string heSoTNCu = string.Empty;
            string heSoTNMoi = string.Empty;
            string luongCBCu = string.Empty;
            string luongCBMoi = string.Empty;

            string NgayHieuLuc = pThangCap.NgayHieuLuc.HasValue ? pThangCap.NgayHieuLuc.Value.ToString("dd/MM/yyyy") : string.Empty;

            DM_ChucDanh chucDanhCu = _busChucDanh.GetEntityById(pNhanVien.IdChucDanh);
            DM_ChucDanh chucDanhMoi = _busChucDanh.GetEntityById(pThangCap.IdChucVu);

            if (chucDanhCu != null)
            {
                heSoCDCu = chucDanhCu.HeSoChucVu.HasValue ? chucDanhCu.HeSoChucVu.Value.ToString() : string.Empty;
                heSoTNCu = chucDanhCu.HeSoTrachNhiem.HasValue ? chucDanhCu.HeSoTrachNhiem.Value.ToString() : string.Empty;
                luongCBCu = chucDanhCu.LuongCanBan.HasValue ? chucDanhCu.LuongCanBan.Value.ToString("C", vnfi) : string.Empty;
            }
            if (chucDanhMoi != null)
            {
                heSoCDMoi = chucDanhMoi.HeSoChucVu.HasValue ? chucDanhMoi.HeSoChucVu.Value.ToString() : string.Empty;
                heSoTNMoi = chucDanhMoi.HeSoTrachNhiem.HasValue ? chucDanhMoi.HeSoTrachNhiem.Value.ToString() : string.Empty;
                luongCBMoi = chucDanhMoi.LuongCanBan.HasValue ? chucDanhMoi.LuongCanBan.Value.ToString("C", vnfi) : string.Empty;
            }

            string NgayKyHopDong = string.Empty;
            NV_HopDong hopDong = _busHopDong.GetHopDongGanNhat(pNhanVien.Id, 1); // 2 is  the loai hop dong chinh thuc
            if (hopDong != null && hopDong.NgayKy.HasValue)
            {
                NgayKyHopDong = hopDong.NgayKy.Value.ToString("dd/MM/yyyy");
            }

            string[] fields = new string[] { "SoQuyetDinh", "HoVaTen", "ChucVu", "TenPhongBan", "NgayKyHopDong", "HSCVCu", "HSCVMoi", "HSTNCu", "HSTNMoi", "LuongCanBanCu", "LuongCanBanMoi", "NgayHieuLuc", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pThangCap.SoQuyetDinh.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten.Trim(), pNhanVien.TenChucDanh, TenPhongBan, NgayKyHopDong, heSoCDCu, heSoCDMoi, heSoTNCu, heSoTNMoi, luongCBCu, luongCBMoi, NgayHieuLuc, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileBoNhiem, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileBoNhiem);
        }

        /// <summary>
        /// Quyets the dinh thoi viec.
        /// </summary>
        /// <param name="pNhanVien">The p nhan vien.</param>
        /// <param name="pThoiViec">The p thoi viec.</param>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        public void QuyetDinhThoiViec(NV_NhanVien pNhanVien, NV_QuyetDinhThoiViec pThoiViec)
        {
            NV_HopDongBLL _busHopDong = new NV_HopDongBLL();
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileBoNhiem = string.Empty;
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHTHOIVIEC;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_QUYETDINHTHOIVIEC).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string TenPhongBan = CacheData.GetTenPhongBan(pNhanVien.IdPhongBan);


            string NgayHieuLuc = pThoiViec.NgayHieuLuc.HasValue ? pThoiViec.NgayHieuLuc.Value.ToString("dd/MM/yyyy") : string.Empty;

            string NgayKyHopDong = string.Empty;
            NV_HopDong hopDong = _busHopDong.GetHopDongGanNhat(pNhanVien.Id, 1); // 2 is  the loai hop dong chinh thuc
            if (hopDong != null && hopDong.NgayKy.HasValue)
            {
                NgayKyHopDong = hopDong.NgayKy.Value.ToString("dd/MM/yyyy");
            }

            string[] fields = new string[] { "SoQuyetDinh", "HoVaTen", "ChucVu", "TenPhongBan", "NgayKyHopDong", "LyDoThoiViec", "NgayHieuLuc", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pThoiViec.SoQuyetDinh.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten.Trim(), pNhanVien.TenChucDanh, TenPhongBan, NgayKyHopDong, pThoiViec.TenQuyetDinh, NgayHieuLuc, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileBoNhiem, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileBoNhiem);
        }


        #endregion

        #region ---- Hop Dong ----

        /// <summary>
        /// Exports the hop dong lao dong.
        /// </summary>
        /// <param name="pUngVien">The p ung vien.</param>
        /// <Author>LONG LY</Author>
        /// <Date>12/06/2011</Date>
        public void ExportHopDongLaoDong(NV_HopDong pHopDong)
        {
            MemoryStream mStream = null;
            WordDocument document = null;
            NV_NhanVienBLL _busNhanVien = new NV_NhanVienBLL();
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();
            string fileHopDong = string.Empty;

            NV_NhanVien pNhanVien = _busNhanVien.GetNhanVienbyId(pHopDong.IdNhanVien);

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;


            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_HOPDONGLAODONG;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_HOPDONGLAODONG).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileHopDong = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string soDienThoaiString = pNhanVien.SoDienThoai;
            string LuongCanBan = string.Empty;
            string ThuViecTuNgay = string.Empty;
            string ThuViecDenNgay = string.Empty;
            string TenChucDanh = string.Empty;
            string TenTrinhDo = string.Empty;

            DM_ChucDanh chucDanh = _busChucDanh.GetEntityById(pNhanVien.IdChucDanh);
            
                TenTrinhDo = CacheData.GettenTrinhDo(pNhanVien.IdTrinhDo);
            

            if (chucDanh != null && chucDanh.LuongCanBan.HasValue)
            {
                LuongCanBan = chucDanh.LuongCanBan.Value.ToString("C", vnfi);
                TenChucDanh = chucDanh.TenChucDanh;
            }
            if (pHopDong.NgayBatDau.HasValue)
            {
                ThuViecTuNgay = pHopDong.NgayBatDau.Value.ToString("dd/MM/yyyy");
            }
            if (pHopDong.NgayKetThuc.HasValue)
            {
                ThuViecDenNgay = pHopDong.NgayKetThuc.Value.ToString("dd/MM/yyyy");
            }

            string[] fields = new string[] { "SoHopDong", "HoVaTen", "ChucDanh", "TenTrinhDo", "DiaChi", "CMND", "Email", "TuNgay", "DenNgay", "LuongCoBan", "DienThoai", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pHopDong.SoHopDong.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten, TenChucDanh, TenTrinhDo, pNhanVien.DiaChiHienTai, pNhanVien.CMND, pNhanVien.Email, ThuViecTuNgay, ThuViecDenNgay, LuongCanBan, soDienThoaiString, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileHopDong, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileHopDong);
        }

        /// <summary>
        /// Exports the hop dong thu viec.
        /// </summary>
        /// <param name="pHopDong">The p hop dong.</param>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        public void ExportHopDongThuViec(NV_HopDong pHopDong)
        {
            MemoryStream mStream = null;
            WordDocument document = null;
            NV_NhanVienBLL _busNhanVien = new NV_NhanVienBLL();
            DanhMucChucDanhBLL _busChucDanh = new DanhMucChucDanhBLL();
            string fileHopDong = string.Empty;

            NV_NhanVien pNhanVien = _busNhanVien.GetNhanVienbyId(pHopDong.IdNhanVien);

            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;


            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);

            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }

            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_HOPDONGTHUVIEC;
            DM_BieuMauBLL _busBieuMau = new DM_BieuMauBLL();
            try
            {
                // Read template
                mStream = new MemoryStream(_busBieuMau.GetBieuMauByMau(FILE_HOPDONGTHUVIEC).NoiDung.ToArray());
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {
                UICommon.StopLoading();
                UICommon.ShowMsgInfo("MSG029");
                return;
            }

            // AppPath\Temp\MaHoSo.doc
            fileHopDong = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + pNhanVien.MaNhanVien + Constants.FILE_EXT_DOC;

            //Prepare to mailMerg


            DateTime SysDate = CacheData.Context.GetSystemDate();

            string ngay = SysDate.Day.ToString();
            string thang = SysDate.Month.ToString();
            string nam = SysDate.Year.ToString();
            string soDienThoaiString = pNhanVien.SoDienThoai;
            string LuongThuViec = string.Empty;
            string ThuViecTuNgay = string.Empty;
            string ThuViecDenNgay = string.Empty;
            string TenChucDanh = string.Empty;
            string TenTrinhDo = string.Empty;
            decimal luong = 0;
            DM_ChucDanh chucDanh = _busChucDanh.GetEntityById(pNhanVien.IdChucDanh);
          
                TenTrinhDo = CacheData.GettenTrinhDo(pNhanVien.IdTrinhDo);
           

            if (chucDanh != null && chucDanh.LuongCanBan.HasValue)
            {
                luong = (chucDanh.LuongCanBan.Value * 70) / 100;
                LuongThuViec = luong.ToString("C", vnfi);
                TenChucDanh = chucDanh.TenChucDanh;
            }
            if (pHopDong.NgayBatDau.HasValue)
            {
                ThuViecTuNgay = pHopDong.NgayBatDau.Value.ToString("dd/MM/yyyy");
            }
            if (pHopDong.NgayKetThuc.HasValue)
            {
                ThuViecDenNgay = pHopDong.NgayKetThuc.Value.ToString("dd/MM/yyyy");
            }

            string[] fields = new string[] { "SoHopDong", "HoVaTen", "ChucDanh", "TenTrinhDo", "DiaChi", "CMND", "Email", "TuNgay", "DenNgay", "LuongThuViec", "DienThoai", "Ngay", "Thang", "Nam" };
            string[] values = new string[] { pHopDong.SoHopDong.ToString(), pNhanVien.HoDem + " " + pNhanVien.Ten, TenChucDanh, TenTrinhDo, pNhanVien.DiaChiHienTai, pNhanVien.CMND, pNhanVien.Email, ThuViecTuNgay, ThuViecDenNgay, LuongThuViec, soDienThoaiString, ngay, thang, nam };

            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileHopDong, FormatType.Doc);

            // Close the document after save
            document.Close();

            UICommon.StopLoading();
            this.PrinPriview(fileHopDong);
        }

        #endregion

        #endregion

    }
}

