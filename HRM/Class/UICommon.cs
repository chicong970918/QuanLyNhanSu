using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Library.Forms;
using System.Resources;
using Library.Controls;
using System.Drawing;
using System.Security.Cryptography;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Library;

namespace HRM
{
   public class UICommon
    {
        /// <summary>
        /// 
        /// </summary>
        public enum DateIntTypes
        {
            /// <summary>
            /// 
            /// </summary>
            Day,
            /// <summary>
            /// 
            /// </summary>
            Month,
            /// <summary>
            /// 
            /// </summary>
            Year
        }

        #region ---- Variables ----
        private static HRMSplashPanelMessage _splashPanelMessage;
        private static Form _frmWillActiveAfterLoading = null;
        private static bool _isDesignMode = true;
        private static Thread _threadLoading;
        private static LoadingForm _frmLoading;
        public delegate void VoidEventHandler();
        private static ResourceManager _resourceManager = HRM.Properties.Resources.ResourceManager;

        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets a value indicating whether this instance is design mode.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is design mode; otherwise, <c>false</c>.
        /// </value>
        public static bool IsDesignMode
        {
            get { return UICommon._isDesignMode; }
            set { UICommon._isDesignMode = value; }
        }
        /// <summary>
        /// Gets or sets the form will active after loading.
        /// </summary>
        /// <value>The form will active after loading.</value>
        public static Form FormWillActiveAfterLoading
        {
            get { return UICommon._frmWillActiveAfterLoading; }
            set { UICommon._frmWillActiveAfterLoading = value; }
        }

        /// <summary>
        /// Gets the date format.
        /// </summary>
        /// <value>The date format.</value>
        public static string DateFormat
        {
            get { return "dd/MM/yyyy"; }
        }

        /// <summary>
        /// Gets the currency format.
        /// </summary>
        /// <value>The currency format.</value>
        public static string CurrencyFormat
        {
            get { return "N0"; }
        }

        /// <summary>
        /// Gets the integer format.
        /// </summary>
        /// <value>The integer format.</value>
        public static string IntegerFormat
        {
            get { return "N0"; }
        }

        /// <summary>
        /// Gets the float format.
        /// </summary>
        /// <value>The float format.</value>
        public static string FloatFormat
        {
            get { return "N2"; }
        }


        #endregion


        /// <summary>
        /// Starts the update.
        /// </summary>
        public static void StartUpdate()
        {
            StartLoading(GetString("STATUS_UPDATING"));
        }

        /// <summary>
        /// Stops the update.
        /// </summary>
        public static void StopUpdate()
        {
            StopLoading();
        }

        /// <summary>
        /// Starts the process.
        /// </summary>
        public static void StartProcess()
        {
            StartLoading(GetString("STATUS_PROCESSING"));
        }

        /// <summary>
        /// Stops the process.
        /// </summary>
        public static void StopProcess()
        {
            StopLoading();
        }

       /// <summary>
        /// Starts the loading.
        /// </summary>
        /// <param name="pContent">Content of the p.</param>
        /// <param name="pFormWillActiveAfterLoading">The p form will active after loading.</param>
       public static void StartLoading(string pContent = null, Form pFormWillActiveAfterLoading = null)
       {
           if (IsDesignMode)
           {
               return;
           }

           _frmWillActiveAfterLoading = pFormWillActiveAfterLoading;

           _threadLoading = new Thread(new ParameterizedThreadStart(ShowLoading));

           _threadLoading.IsBackground = true;
           _threadLoading.Start(pContent);
       }

       /// <summary>
       /// Shows the loading.
       /// </summary>
       /// <param name="value">The value.</param>
       private static void ShowLoading(object value)
       {
           if (value == null)
           {
               _frmLoading = new LoadingForm();
           }
           else
           {
               _frmLoading = new LoadingForm(value.ToString());
           }

           _frmLoading.ShowDialog();
       }

       /// <summary>
       /// Stops the loading.
       /// </summary>
       public static void StopLoading()
       {
           try
           {
               if (IsDesignMode)
               {
                   return;
               }

               // Thread aborted
               if (_threadLoading.ThreadState == ThreadState.Aborted)
               {
                   return;
               }

               if (_threadLoading.ThreadState == ThreadState.Background)
               {
                   // Close form loading and release memory
                   if (_frmLoading.InvokeRequired)
                   {
                       _frmLoading.Invoke(new VoidEventHandler(delegate()
                       {

                           _frmLoading.Close();
                           _frmLoading.Dispose();

                       }));
                   }
                   else
                   {
                       _frmLoading.Close();
                       _frmLoading.Dispose();
                   }

                   // Call collect
                   GC.Collect();

                   // Had Form main then active
                   if (_frmWillActiveAfterLoading != null)
                   {
                       if (_frmWillActiveAfterLoading.InvokeRequired)
                       {
                           _frmWillActiveAfterLoading.Invoke(new VoidEventHandler(delegate()
                           {

                               _frmWillActiveAfterLoading.Activate();

                           }));
                       }
                       else
                       {
                           _frmWillActiveAfterLoading.Activate();
                       }
                   }
               }
           }
           catch { }
       }

        

       #region ---- Show message ----

       /// <summary>
       /// Shows the MSG info.
       /// </summary>
       /// <param name="messageID">The message ID.</param>
       /// <returns></returns>
       public static DialogResult ShowMsgInfo(string messageID, params string[] parameter)
       {
           return ShowMessage(messageID, MessageBoxButtons.OK, MessageBoxIcon.Information, parameter);
       }

       /// <summary>
       /// Shows the MSG warning.
       /// </summary>
       /// <param name="messageID">The message ID.</param>
       /// <param name="parameter">The parameter.</param>
       /// <returns></returns>
       public static DialogResult ShowMsgWarning(string messageID, params string[] parameter)
       {
           return ShowMessage(messageID, MessageBoxButtons.OK, MessageBoxIcon.Warning, parameter);
       }

       /// <summary>
       /// Shows the MSG confirm.
       /// </summary>
       /// <param name="messageID">The message ID.</param>
       /// <param name="parameter">The parameter.</param>
       /// <returns></returns>
       public static DialogResult ShowMsgConfirm(string messageID, params string[] parameter)
       {
           return ShowMessage(messageID, MessageBoxButtons.YesNo, MessageBoxIcon.Question, parameter);
       }

       /// <summary>
       /// Shows the MSG error.
       /// </summary>
       /// <param name="messageID">The message ID.</param>
       /// <param name="parameter">The parameter.</param>
       /// <returns></returns>
       public static DialogResult ShowMsgError(string messageID, params string[] parameter)
       {
           return ShowMessage(messageID, MessageBoxButtons.OK, MessageBoxIcon.Error, parameter);
       }

       /// <summary>
       /// Initilizes the specified p resource manager.
       /// </summary>
       /// <param name="pResourceManager">External ResourceManager.</param>
       /// <param name="pSplashPanelMessage">The splash panel message.</param>
       /// <param name="pIsDesignMode">if set to <c>true</c> [p is design mode].</param>
       public static void Initilize(HRMSplashPanelMessage pSplashPanelMessage, bool pIsDesignMode = true)
       {

          // HRMSplashPanelMessage splashPanelMessage = new HRMSplashPanelMessage();

           pSplashPanelMessage.Alignment = System.Drawing.StringAlignment.Center;
           pSplashPanelMessage.BackgroundColor =new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(233)))), ((int)(((byte)(0))))));
           pSplashPanelMessage.BorderType = Syncfusion.Windows.Forms.Tools.SplashBorderType.None;
           pSplashPanelMessage.CloseOnClick = true;
           pSplashPanelMessage.CloseOnLostFocus = true;
           pSplashPanelMessage.DiscreetLocation = new System.Drawing.Point(0, 0);
           pSplashPanelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           pSplashPanelMessage.ForeColor = System.Drawing.Color.Red;
           pSplashPanelMessage.LineAlignment = System.Drawing.StringAlignment.Center;
           pSplashPanelMessage.Location = new System.Drawing.Point(382, 267);
           pSplashPanelMessage.Name = "splashPanelMessage";
           pSplashPanelMessage.ShowAnimation = false;
           pSplashPanelMessage.Size = new System.Drawing.Size(187, 24);
           pSplashPanelMessage.TabIndex = 5;
           pSplashPanelMessage.Text = "Cập nhật dữ liệu thành công";
           pSplashPanelMessage.TimerInterval = 500;

           _splashPanelMessage = pSplashPanelMessage;
           _isDesignMode = pIsDesignMode;

       }

       #endregion ---- Show message ----

       /// <summary>
       /// Gets the message.
       /// </summary>
       /// <param name="pMessageID">The p message ID.</param>
       /// <param name="pParameter">The p parameter.</param>
       /// <returns></returns>
       public static string GetString(string pMessageID, params string[] pParameter)
       {
           string message = string.Empty;

           if (pParameter != null)
           {
               message = string.Format(GetString(pMessageID), pParameter);
           }
           else
           {
               message = GetString(pMessageID);
           }

           return message;
       }

       /// <summary>
       /// Gets the message.
       /// </summary>
       /// <param name="pMessageID">The p message ID.</param>
       /// <returns></returns>
       public static string GetString(string pMessageID)
       {
           if (_resourceManager == null)
           {
               throw new Exception("Resource wasn't initilize");
           }

           string message = _resourceManager.GetString(pMessageID);

           return message;
       }

       /// <summary>
       /// Shows the message.
       /// </summary>
       /// <param name="pMessageID">The p message ID.</param>
       /// <param name="pParameter">The p parameter.</param>
       /// <param name="pTitle">The p title.</param>
       /// <param name="pMessageBoxButtons">The p message box buttons.</param>
       /// <param name="pMessageBoxIcon">The p message box icon.</param>
       /// <returns></returns>
       public static DialogResult ShowMessage(string pMessageID, string pTitle,
                                           MessageBoxButtons pMessageBoxButtons,
                                           MessageBoxIcon pMessageBoxIcon, params string[] pParameter)
       {
           try
           {
               string message = GetString(pMessageID, pParameter);

               // Replace \n
               message = message.Replace("\\n", "\n");

               return MessageBoxAdv.Show(message, pTitle, pMessageBoxButtons, pMessageBoxIcon);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           return DialogResult.None;
       }

       /// <summary>
       /// Shows the message.
       /// </summary>
       /// <param name="pMessageID">The p message ID.</param>
       /// <param name="pParameter">The p parameter.</param>
       /// <param name="pMessageBoxButtons">The p message box buttons.</param>
       /// <param name="pMessageBoxIcon">The p message box icon.</param>
       /// <returns></returns>
       public static DialogResult ShowMessage(string pMessageID, MessageBoxButtons pMessageBoxButtons,
                                               MessageBoxIcon pMessageBoxIcon, params string[] pParameter)
       {
           try
           {
               string title = string.Empty;

               switch (pMessageBoxIcon)
               {
                   case MessageBoxIcon.Question:
                       title = GetString("MessageBox_Question_Title");
                       break;
                   case MessageBoxIcon.Error:
                       title = GetString("MessageBox_Error_Title");
                       break;
                   case MessageBoxIcon.Warning:
                       title = GetString("MessageBox_Warning_Title");
                       break;
                   default:
                       title = GetString("MessageBox_Message_Title");
                       break;
               }

               return ShowMessage(pMessageID, title, pMessageBoxButtons, pMessageBoxIcon, pParameter);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           return DialogResult.None;
       }

       /// <summary>
       /// Shows the message.
       /// </summary>
       /// <param name="pMessageID">The p message ID.</param>
       /// <param name="pMessageBoxButtons">The p message box buttons.</param>
       /// <param name="pMessageBoxIcon">The p message box icon.</param>
       /// <returns></returns>
       public static DialogResult ShowMessage(string pMessageID, MessageBoxButtons pMessageBoxButtons,
                                               MessageBoxIcon pMessageBoxIcon)
       {
           try
           {
               return ShowMessage(pMessageID, pMessageBoxButtons, pMessageBoxIcon, null);
           }
           catch (Exception ex)
           {
               throw (ex);
           }

           return DialogResult.None;
       }

       /// <summary>
       /// Manages the validation exception.
       /// </summary>
       /// <param name="pException">The p exception.</param>
       /// <param name="pBidingSource">The p biding source.</param>
       //public static void ManageValidationException(ValidationException pException, CustomBindingSource pBidingSource)
       //{
       //    MessageBoxAdv.Show(pException.GetErrorMessage(), "Lỗi dữ liệu!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
       //}

       /// <summary>
       /// Get md5 string
       /// </summary>
       /// <param name="pValue">Value want get MD5</param>
       /// <returns>md5 string</returns>
       public static string MD5(string pValue)
       {
           HashAlgorithm hashClass = new MD5CryptoServiceProvider();

           byte[] byteValue = System.Text.Encoding.ASCII.GetBytes(pValue);

           // obtain the hash code from the HashAlgorithm by 
           // using the ComputeHash method
           byte[] hashValue = hashClass.ComputeHash(byteValue);

           return Convert.ToBase64String(hashValue);
       }

       /// <summary>
       /// Compares the object.
       /// </summary>
       /// <param name="obj1">The obj1.</param>
       /// <param name="obj2">The obj2.</param>
       /// <param name="pProperties">The p properties.</param>
       /// <returns></returns>
       public static bool CompareObject(object obj1, object obj2, params string[] pProperties)
       {
           foreach (string str in pProperties)
           {
               System.Reflection.PropertyInfo piObj1 = obj1.GetType().GetProperty(str);
               System.Reflection.PropertyInfo piObj2 = obj2.GetType().GetProperty(str);
               if (piObj1 != null && piObj2 != null)
               {
                   object objVal1 = piObj1.GetValue(obj1, null);
                   object objVal2 = piObj2.GetValue(obj2, null);
                   if ((objVal1 == null && objVal2 != null) || (objVal1 != null && objVal2 == null))
                   {
                       return false;
                   }
                   if (objVal1 != null && objVal2 != null)
                   {
                       string a = objVal1.ToString();
                       string b = objVal2.ToString();
                       if (!a.Equals(b))
                       {
                           return false;
                       }
                   }
               }
           }

           return true;
       }

       /// <summary>
       /// Rotates the image.
       /// </summary>
       /// <param name="pImage">The p image.</param>
       /// <param name="angle">The angle.</param>
       /// <returns></returns>
       public static Bitmap RotateImage(Image pImage, float angle)
       {
           //create a new empty bitmap to hold rotated image
           Bitmap returnBitmap = new Bitmap(pImage.Width, pImage.Height);

           //make a graphics object from the empty bitmap
           Graphics g = Graphics.FromImage(returnBitmap);

           //move rotation point to center of image
           g.TranslateTransform((float)pImage.Width / 2, (float)pImage.Height / 2);

           //rotate
           g.RotateTransform(angle);

           //move image back
           g.TranslateTransform(-(float)pImage.Width / 2, -(float)pImage.Height / 2);

           //draw passed in image onto graphics object
           g.DrawImage(pImage, new Point(0, 0));

           return returnBitmap;
       }

       /// <summary>
       /// Gets the date int.
       /// </summary>
       /// <param name="pValue">The p value.</param>
       /// <param name="pShowType">Type of the p show.</param>
       /// <param name="pDateIntType">Type of the p date int.</param>
       /// <returns></returns>
       public static int? GetDateInt(DateTime? pValue, HRMDateTimePickerEx.ShowTypes pShowType, DateIntTypes pDateIntType)
       {
           if (pValue != null)
           {
               switch (pShowType)
               {
                   case HRMDateTimePickerEx.ShowTypes.Full:

                       switch (pDateIntType)
                       {
                           case DateIntTypes.Day:

                               return pValue.Value.Day;

                           case DateIntTypes.Month:

                               return pValue.Value.Month;

                           case DateIntTypes.Year:

                               return pValue.Value.Year;
                       }

                       break;

                   case HRMDateTimePickerEx.ShowTypes.MonthYear:

                       switch (pDateIntType)
                       {

                           case DateIntTypes.Month:

                               return pValue.Value.Month;

                           case DateIntTypes.Year:

                               return pValue.Value.Year;
                       }

                       break;

                   case HRMDateTimePickerEx.ShowTypes.Year:

                       switch (pDateIntType)
                       {
                           case DateIntTypes.Year:

                               return pValue.Value.Year;
                       }

                       break;
               }
           }

           return null;
       }

       ///// <summary>
       ///// Shows the splash panel message.
       ///// </summary>
       ///// <param name="pMessage">The p message.</param>
       //private static void ShowSplashPanelMessage(string pMessage)
       //{
       //    _splashPanelMessage = new HRMSplashPanelMessage();
       //        _splashPanelMessage.Text = pMessage;
       //        _splashPanelMessage.ShowSplash();
       //}

       /// <summary>
       /// Shows the splash panel message.
       /// </summary>
       /// <param name="pMessage">The p message.</param>
       private static void ShowSplashPanelMessage(string pMessage)
       {
           

           if (_splashPanelMessage != null)
           {
               _splashPanelMessage.Text = pMessage;
               _splashPanelMessage.ShowSplash();
           }
       }

       /// <summary>
       /// Shows the splash panel update MSG.
       /// </summary>
       public static void ShowSplashPanelUpdateMsg()
       {
           ShowSplashPanelMessage(GetString("MSG007"));
       }
       
       #region Format

       /// <summary>
       /// Grids the format money.
       /// </summary>CheckBox
       /// <param name="pGridColumnDescriptorCollection">The p grid column descriptor collection.</param>
       /// <param name="pMappingColumnsName">Name of the p mapping columns.</param>
       public static void GridFormatMoney(GridColumnDescriptorCollection pGridColumnDescriptorCollection, params string[] pMappingColumnsName)
       {
           foreach (GridColumnDescriptor col in pGridColumnDescriptorCollection)
           {
               if (pMappingColumnsName.Contains(col.MappingName))
               {
                   //ChiTrung
                   col.Appearance.AnyRecordFieldCell.CellType = "Currency";
                   col.Appearance.AnyRecordFieldCell.CellValueType = typeof(decimal);
                   col.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = "";
                   col.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 0;
                   //
                   col.Appearance.AnyRecordFieldCell.Format = CurrencyFormat;
                   col.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
               }
           }
       }
       public static void GridFormatCheckBox(GridColumnDescriptorCollection pGridColumnDescriptorCollection, params string[] pMappingColumnsName)
       {
           foreach (GridColumnDescriptor col in pGridColumnDescriptorCollection)
           {
               if (pMappingColumnsName.Contains(col.MappingName))
               {
                   //ChiTrung
                   col.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
                //  col.Appearance.AnyRecordFieldCell.CellValueType = typeof(decimal);
                 //  col.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = "";
                  // col.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 0;
                   //
                   //col.Appearance.AnyRecordFieldCell.Format = CurrencyFormat;
                   col.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
               }
           }
       }
       /// <summary>
       /// Grids the format date.
       /// </summary>
       /// <param name="pGridColumnDescriptorCollection">The p grid column descriptor collection.</param>
       /// <param name="pStatic">if set to <c>true</c> [p static].</param>
       /// <param name="pMappingColumnsName">Name of the p mapping columns.</param>
       public static void GridFormatDate(GridColumnDescriptorCollection pGridColumnDescriptorCollection, bool pStatic = true, params string[] pMappingColumnsName)
       {
           foreach (GridColumnDescriptor col in pGridColumnDescriptorCollection)
           {
               if (pMappingColumnsName.Contains(col.MappingName))
               {
                   col.Appearance.AnyRecordFieldCell.Format = DateFormat;
                   col.Appearance.AnyRecordFieldCell.CellValueType = typeof(DateTime);
                   col.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;

                   if (pStatic)
                   {
                       col.Appearance.AnyRecordFieldCell.CellType = "Static";
                   }
               }
           }
       }

       /// <summary>
       /// Grids the format number.
       /// </summary>
       /// <param name="pGridColumnDescriptorCollection">The p grid column descriptor collection.</param>
       /// <param name="pIsInteger">if set to <c>true</c> [p is integer].</param>
       /// <param name="pMappingColumnsName">Name of the p mapping columns.</param>
       public static void GridFormatNumber(GridColumnDescriptorCollection pGridColumnDescriptorCollection, bool pIsInteger, params string[] pMappingColumnsName)
       {
           foreach (GridColumnDescriptor col in pGridColumnDescriptorCollection)
           {
               if (pMappingColumnsName.Contains(col.MappingName))
               {
                   col.Appearance.AnyRecordFieldCell.Format = pIsInteger ? IntegerFormat : FloatFormat;
                   col.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
               }
           }
       }

       /// <summary>
       /// Summaries the format currency.
       /// </summary>
       /// <param name="pGridGrouping">The p grid grouping.</param>
       /// <param name="pName">Name of the p.</param>
       public static void GridSummaryFormatCurrencyVN(HRMGrigouping pGridGrouping, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment pGridHoziontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right, params string[] pName)
       {
           foreach (GridSummaryRowDescriptor gsr in pGridGrouping.TableDescriptor.SummaryRows)
           {
               foreach (GridSummaryColumnDescriptor gscd in gsr.SummaryColumns)
               {
                   if (pName.Contains<string>(gscd.Name))
                   {
                       gscd.Appearance.AnySummaryCell = FormatCurrencyVNCell();
                   }
               }
           }
       }

       /// <summary>
       /// Formats the currency VN cell.
       /// </summary>
       /// <param name="pGridHoziontalAlignment">The p grid hoziontal alignment.</param>
       /// <returns></returns>
       ///  25/07/11
       /// PC
       public static GridTableCellStyleInfo FormatCurrencyVNCell(GridHorizontalAlignment pGridHoziontalAlignment = GridHorizontalAlignment.Right)
       {
           GridTableCellStyleInfo style = new GridTableCellStyleInfo()
           {
               CellType = "Currency",
               CellValueType = typeof(decimal),
               HorizontalAlignment = pGridHoziontalAlignment,
           };

           System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("vi-VN");
           ci.NumberFormat.NegativeSign = "-";
           ci.NumberFormat.NumberDecimalDigits = 0;
           ci.NumberFormat.CurrencySymbol = "";

           style.CultureInfo = ci;

           style.CurrencyEdit.CurrencySymbol = "";
           style.CurrencyEdit.CurrencyDecimalDigits = 0;
           style.CurrencyEdit.NegativeSign = "-";
           return style;
       }

       public static GridTableCellStyleInfo FormatDateCell()
       {
           GridTableCellStyleInfo style = new GridTableCellStyleInfo()
           {
               CellType = "Static",
               HorizontalAlignment = GridHorizontalAlignment.Center,
               Format = DateFormat,
           };
           return style;
       }
       #endregion

    }
}
