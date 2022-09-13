using Syncfusion.Windows.Forms.Tools;
namespace Library.Controls
{
    public partial class HRMTextBox : TextBoxExt
    {
        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the current text in the <see cref="T:System.Windows.Forms.TextBox"/>.
        /// </summary>
        /// <value></value>
        /// <returns>The text displayed in the control.</returns>
        public override string Text
        {
            get
            {
                return base.Text.Trim();
            }
            set
            {
                base.Text = value;
            }
        }

        #endregion ---- Properties ----

        #region ---- Protected methods ----

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BindingContextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnBindingContextChanged(System.EventArgs e)
        {
            foreach (System.Windows.Forms.Binding bin in this.DataBindings)
            {
                // Binding text
                if (bin.PropertyName == "Text")
                {
                    // Set null value is empty string
                    bin.NullValue = string.Empty;
                }
            }

            base.OnBindingContextChanged(e);
        }

        #endregion ---- Protected methods ----
    }
}
