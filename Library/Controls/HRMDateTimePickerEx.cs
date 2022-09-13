using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using Syncfusion.Windows.Forms.Tools;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class HRMDateTimePickerEx : HRMDateTimePicker
    {
        #region ---- Enums ----

        /// <summary>
        /// 
        /// </summary>
        public enum ShowTypes
        {
            /// <summary>
            /// 
            /// </summary>
            Full,
            /// <summary>
            /// 
            /// </summary>
            MonthYear,
            /// <summary>
            /// 
            /// </summary>
            Year
        }

        #endregion ---- Enums ----

        #region ---- Member variables ----

        private ShowTypes _showType = ShowTypes.Full;
        private ContextMenuStripEx contextMenuStripEx;
        private ToolStripMenuItem mnuNgayThangNam;
        private ToolStripMenuItem mnuThangNam;
        private ToolStripMenuItem mnuNam;

        #endregion ---- Member variables ----

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SECDateTimePickerEx"/> class.
        /// </summary>
        public HRMDateTimePickerEx()
        {
            InitializeComponent();

            SetShowType();
        }

        #endregion ---- Contructors ----

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the format of the picker when Format is Custom.
        /// </summary>
        /// <value></value>
        public new string CustomFormat
        {
            get { return base.CustomFormat; }
            set { }
        }

        /// <summary>
        /// Gets or sets the type of the show.
        /// </summary>
        /// <value>The type of the show.</value>
        public ShowTypes ShowType
        {
            get { return _showType; }
            set
            {
                if (_showType != value)
                {
                    _showType = value;

                    SetShowType();
                }
            }
        }

        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>The day.</value>
        public int Day
        {
            get
            {
                if (this.Value.HasValue)
                {
                    return this.Value.Value.Day;
                }

                return -1;
            }
        }

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>The month.</value>
        public int Month
        {
            get
            {
                if (this.Value.HasValue)
                {
                    return this.Value.Value.Month;
                }

                return -1;
            }
        }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year
        {
            get
            {
                if (this.Value.HasValue)
                {
                    return this.Value.Value.Year;
                }

                return -1;
            }
        }

        #endregion ---- Properties ---

        #region ---- Public methods ----

        /// <summary>
        /// Shows the menu.
        /// </summary>
        public void ShowMenu()
        {
            this.contextMenuStripEx.Show(this, new Point(0, this.Height));
        }

        #endregion ---- Public methods ----

        #region ---- Private methods ----

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.contextMenuStripEx = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.mnuNgayThangNam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThangNam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNam = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripEx
            // 
            this.contextMenuStripEx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNgayThangNam,
            this.mnuThangNam,
            this.mnuNam});
            this.contextMenuStripEx.Name = "contextMenuStripEx1";
            this.contextMenuStripEx.Size = new System.Drawing.Size(162, 70);
            // 
            // mnuNgayThangNam
            // 
            this.mnuNgayThangNam.CheckOnClick = true;
            this.mnuNgayThangNam.Name = "mnuNgayThangNam";
            this.mnuNgayThangNam.Size = new System.Drawing.Size(161, 22);
            this.mnuNgayThangNam.Text = "Ngày Tháng Năm";
            this.mnuNgayThangNam.Click += new System.EventHandler(this.mnuChangeShowType_Click);
            // 
            // mnuThangNam
            // 
            this.mnuThangNam.CheckOnClick = true;
            this.mnuThangNam.Name = "mnuThangNam";
            this.mnuThangNam.Size = new System.Drawing.Size(161, 22);
            this.mnuThangNam.Text = "Tháng Năm";
            this.mnuThangNam.Click += new System.EventHandler(this.mnuChangeShowType_Click);
            // 
            // mnuNam
            // 
            this.mnuNam.CheckOnClick = true;
            this.mnuNam.Name = "mnuNam";
            this.mnuNam.Size = new System.Drawing.Size(161, 22);
            this.mnuNam.Text = "Năm";
            this.mnuNam.Click += new System.EventHandler(this.mnuChangeShowType_Click);
            // 
            // CustomDateTimePickerEx
            // 
            // 
            // 
            // 
            this.Calendar.AllowMultipleSelection = false;
            this.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.Calendar.DaysFont = new System.Drawing.Font("Verdana", 8F);
            this.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar.Location = new System.Drawing.Point(0, 0);
            this.Calendar.Name = "monthCalendar";
            this.Calendar.SelectedDates = new System.DateTime[0];
            this.Calendar.Size = new System.Drawing.Size(206, 174);
            this.Calendar.SizeToFit = true;
            this.Calendar.TabIndex = 0;
            this.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.Calendar.NoneButton.Location = new System.Drawing.Point(134, 0);
            this.Calendar.NoneButton.Size = new System.Drawing.Size(72, 20);
            this.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            this.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.Calendar.TodayButton.Size = new System.Drawing.Size(134, 20);
            this.Calendar.TodayButton.Text = "Today";
            this.contextMenuStripEx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.ContextMenuStrip = this.contextMenuStripEx;

        }

        /// <summary>
        /// Sets the type of the show.
        /// </summary>
        private void SetShowType()
        {
            string format = string.Empty;

            this.ShowUpDown = true;
            this.ShowDropButton = false;

            switch (_showType)
            {
                case ShowTypes.Full:

                    format = "dd/MM/yyyy";

                    this.ShowUpDown = false;
                    this.ShowDropButton = true;
                    this.mnuNgayThangNam.Checked = true;

                    break;

                case ShowTypes.MonthYear:

                    format = "MM/yyyy";

                    this.mnuThangNam.Checked = true;

                    break;

                case ShowTypes.Year:

                    format = "yyyy";

                    this.mnuNam.Checked = true;

                    break;
            }

            base.CustomFormat = format;
        }

        #endregion ---- Private methods ----        

        #region ---- Handle events ----

        /// <summary>
        /// Handles the Click event of the mnuChangeShowType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChangeShowType_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;

            // Uncheck other menu
            foreach (ToolStripMenuItem m in contextMenuStripEx.Items)
            {
                if (menu != m)
                {
                    m.Checked = false;
                }
            }

            if (menu == mnuNgayThangNam)
            {
                this.ShowType = ShowTypes.Full;
            }
            else if (menu == mnuThangNam)
            {
                this.ShowType = ShowTypes.MonthYear;
            }
            else
            {
                this.ShowType = ShowTypes.Year;
            }
        }

        #endregion ---- Handle events ----
    }
}
