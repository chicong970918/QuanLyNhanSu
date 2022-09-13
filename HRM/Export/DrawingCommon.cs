using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using Syncfusion.Pdf.Barcode;
using HRM.Entities;

namespace HRM.Class
{
    public class DrawingCommon
    {
        #region ---- Constants ----

        private const string FONT_NAME = "Tahoma";

        #endregion

        #region ---- Constructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingCommon"/> class.
        /// </summary>
        public DrawingCommon()
        {

        }

        #endregion

        #region ---- Private methods ----

        /// <summary>
        /// Draws the template student card.
        /// </summary>
        /// <param name="nhanVien">The nhan vien.</param>
        /// <returns></returns>
        public string DrawTemplateNhanVien(NV_NhanVien nhanVien)
        {

            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }

            //Declare path App/Templates/Excels
            string path = Global.AppPath + Constants.FOLDER_TEMP + Constants.CHAR_FLASH + nhanVien.MaNhanVien + ".Png";


            // Create size
            Bitmap bmp = new Bitmap(350, 450);

            GraphicsUnit grapUnit = GraphicsUnit.Pixel;

            // Create graphic
            Graphics gImage = Graphics.FromImage(bmp);

            // Using pen with blue color and 2.0 width
            Pen pen = new Pen(Color.Blue, 2.0F);

            // Get rectangle of image
            RectangleF rect = bmp.GetBounds(ref grapUnit);

            // Fill white color
            gImage.FillRectangle(new SolidBrush(Color.White), rect);

            // Draw round rectangle with blue color
            this.DrawRoundRect(gImage, pen, rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4, 15.0F);

            // Constants
            gImage.DrawString("MIEN DONG CORP", new Font("Tahoma", 10.0F, FontStyle.Bold), new SolidBrush(Color.Black), 110, 10);
            gImage.DrawString("Công ty TNHH 5 Thành Viên", new Font("Tahoma", 10.0F, FontStyle.Bold), new SolidBrush(Color.Black), 65, 30);

            gImage.DrawLine(new Pen(Color.Black, 1.0F), 75, 45, 275, 45);
            if (nhanVien.HinhAnh == null)
            {
                UICommon.ShowMsgInfo("MSG031", nhanVien.HoDem.Trim() + " " + nhanVien.Ten.Trim());
                return string.Empty;
            }
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(nhanVien.HinhAnh.ToArray(), 0, nhanVien.HinhAnh.Length);
            Image image = Image.FromStream(memoryStream);
            // Image student

            gImage.DrawString("THẺ NHÂN  VIÊN", new Font("Tahoma", 16.0F, FontStyle.Bold), new SolidBrush(Color.Red), 80, 68);
            gImage.DrawImage(image, new RectangleF(85, 100, 185, 215));
            string TenChucDanh = CacheData.GetTenChucDanh(nhanVien.IdChucDanh);
            string TenPhongBan = CacheData.GetTenPhongBan(nhanVien.IdPhongBan);
            if ((nhanVien.HoDem + nhanVien.Ten).Trim().Length > 15)
            {
                // Name
                gImage.DrawString(nhanVien.HoDem.ToUpper() + " " + nhanVien.Ten.ToUpper(), new Font("Tahoma", 12.0F, FontStyle.Bold), new SolidBrush(Color.Black), 70, 320);
            }
            else if ((nhanVien.HoDem + nhanVien.Ten).Trim().Length >= 15)
            {
                // Name
                gImage.DrawString(nhanVien.HoDem.ToUpper() + " " + nhanVien.Ten.ToUpper(), new Font("Tahoma", 12.0F, FontStyle.Bold), new SolidBrush(Color.Black), 80, 320);
            }
            else if ((nhanVien.HoDem + nhanVien.Ten).Trim().Length > 13)
            {
                // Name
                gImage.DrawString(nhanVien.HoDem.ToUpper() + " " + nhanVien.Ten.ToUpper(), new Font("Tahoma", 12.0F, FontStyle.Bold), new SolidBrush(Color.Black), 95, 320);
            }
            else if ((nhanVien.HoDem + nhanVien.Ten).Trim().Length > 12)
            {
                // Name
                gImage.DrawString(nhanVien.HoDem.ToUpper() + " " + nhanVien.Ten.ToUpper(), new Font("Tahoma", 12.0F, FontStyle.Bold), new SolidBrush(Color.Black), 105, 320);
            }
            else if ((nhanVien.HoDem + nhanVien.Ten).Trim().Length > 10)
            {
                // Name
                gImage.DrawString(nhanVien.HoDem.ToUpper() + " " + nhanVien.Ten.ToUpper(), new Font("Tahoma", 12.0F, FontStyle.Bold), new SolidBrush(Color.Black), 125, 320);
            }
            else
            {
                // Name
                gImage.DrawString(nhanVien.HoDem.ToUpper() + " " + nhanVien.Ten.ToUpper(), new Font("Tahoma", 12.0F, FontStyle.Bold), new SolidBrush(Color.Black), 130, 320);
            }
           
            gImage.DrawString("Phòng Ban: " + TenPhongBan, new Font("Tahoma", 10.0F, FontStyle.Bold), new SolidBrush(Color.Black), 85, 335);
            gImage.DrawString("Chức Vụ: " + TenChucDanh, new Font("Tahoma", 10.0F, FontStyle.Bold), new SolidBrush(Color.Black), 105, 350);

            PdfCode39ExtendedBarcode barcode = new PdfCode39ExtendedBarcode();
            barcode.Text = nhanVien.MaNhanVien;       // MSSV
            barcode.BarHeight = 30;
            barcode.TextDisplayLocation = TextLocation.None;

            Image imgBarcode = barcode.ToImage();

            gImage.DrawImage(imgBarcode, new RectangleF(105, 370, imgBarcode.Width, 30));

            // MSNV
            gImage.DrawString(nhanVien.MaNhanVien, new Font("Tahoma", 10.0F, FontStyle.Bold), new SolidBrush(Color.Black), 145, 400);

            // Save file
            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);

            gImage.Dispose();
            return path;
        }

        /// <summary>
        /// Draws the round rect.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="p">The p.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        private void DrawRoundRect(Graphics g, Pen p, RectangleF rect, float radius)
        {
            float x = rect.X;
            float y = rect.Y;
            float width = rect.Width;
            float height = rect.Height;

            DrawRoundRect(g, p, x, y, width, height, radius);
        }

        /// <summary>
        /// Draws the round rect.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="p">The p.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        private void DrawRoundRect(Graphics g, Pen p, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();

            g.DrawPath(p, gp);

            gp.Dispose();
        }

        /// <summary>
        /// Finds the location substring.
        /// </summary>
        /// <param name="pValue">The p value.</param>
        /// <returns></returns>
        private int findLocationSubstring(string pValue)
        {
            int count = 0;
            for (int i = 0; i < pValue.Length; i++)
            {
                if (pValue[i] == ' ')
                {
                    count++;
                }

                if (count == 5)
                {
                    return i;
                }
            }

            return 0;
        }

        #endregion

    }
}
