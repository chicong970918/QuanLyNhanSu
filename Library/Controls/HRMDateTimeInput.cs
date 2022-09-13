using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class HRMDateTimeInput : HRMTextBox, INotifyPropertyChanged
    {
        #region ---- Member variables ----

        private DateTime? _currentDateTime = null;
        private string _format = "dd/MM/yyyy";
        private string _nullString = "Chưa chọn";
        private bool _allowNull = true;

        #endregion ---- Member variables ----

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SECDateTimeInput"/> class.
        /// </summary>
        public HRMDateTimeInput()
        {
            this.MaxLength = 10;
            this.TextAlign = HorizontalAlignment.Right;
        }

        #endregion ---- Contructors ----

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Bindable(true)]
        public DateTime? Value
        {
            get
            {
                BuildText();

                // Not allow null
                if (!_allowNull)
                {
                    return _currentDateTime.Value;
                }

                return _currentDateTime;
            }
            set
            {
                SetValue(value);

                SetText();
            }
        }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }

        /// <summary>
        /// Gets or sets the null string.
        /// </summary>
        /// <value>The null string.</value>
        public string NullString
        {
            get { return _nullString; }
            set { _nullString = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow null].
        /// </summary>
        /// <value><c>true</c> if [allow null]; otherwise, <c>false</c>.</value>
        public bool AllowNull
        {
            get { return _allowNull; }
            set
            {
                _allowNull = value;

                BuildText();
            }
        }

        #endregion ---- Properties ----

        #region ---- Protected methods ----

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"/> that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != '/')
                e.Handled = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.Text.Trim() == _nullString)
            {
                this.Text = string.Empty;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            BuildText();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            BuildText();
        }

        #endregion ---- Protected methods ----

        #region ---- Private methods ----

        /// <summary>
        /// Builds the text.
        /// </summary>
        private void BuildText()
        {
            string text;
            int day = 0;
            int month = 0;
            int year = 1900;
            DateTime? value = null;

            try
            {
                // Replace
                text = this.Text.Replace("/", "").Replace(".", "");

                if (text.Length > 1)
                {
                    day = Convert.ToInt32(text.Substring(0, 2));
                }
                if (text.Length > 3)
                {
                    month = Convert.ToInt32(text.Substring(2, 2));
                }
                if (text.Length == 8)
                {
                    year = Convert.ToInt32(text.Substring(4, 4));
                }
                else if (text.Length == 6)
                {
                    year = Convert.ToInt32(year.ToString().Substring(0, 2) + text.Substring(4, 2));
                }

                // Set date
                value = GetDateTime(day, month, year);
            }
            catch
            {
                // Allow null
                if (_allowNull)
                {
                    // Set value
                    value = null;
                }
                else
                {
                    // Set value
                    value = DateTime.Today;
                }
            }
            finally
            {
                SetValue(value);
                SetText();
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="pValue">The p value.</param>
        private void SetValue(DateTime? pValue)
        {
            bool changed = _currentDateTime != pValue;

            // Set value
            _currentDateTime = pValue;            

            if (changed && OnValueChanged != null)
            {
                OnValueChanged(this, new EventArgs());
            }

            if (changed && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        private void SetText()
        {
            if (_currentDateTime.HasValue)
            {
                this.Text = _currentDateTime.Value.ToString(_format);
            }
            else
            {                
                this.Text = _nullString;
            }
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="pDay">The p day.</param>
        /// <param name="pMonth">The p month.</param>
        /// <param name="pYear">The p year.</param>
        /// <returns></returns>
        private DateTime? GetDateTime(int pDay, int pMonth, int pYear)
        {
            DateTime? dateTime = null;

            try
            {
                dateTime = new DateTime(pYear, pMonth, pDay);
            }
            catch
            {
                // Allow null
                if (_allowNull)
                {
                    dateTime = null;
                }
                else
                {
                    dateTime = DateTime.Now;
                }
            }

            return dateTime;
        }

        #endregion ---- Private methods ----        

        #region ---- Handle events ----

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler OnValueChanged; 

        #endregion ---- Handle events ----
    }
}
