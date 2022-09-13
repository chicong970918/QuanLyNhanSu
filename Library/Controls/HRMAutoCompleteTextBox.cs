using System ;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.Windows.Forms.Tools;
using System.Windows.Forms;


namespace Library.Controls
{
    public partial class HRMAutoCompleteTextBox : HRMTextBox, IComponent
    {
         #region ---- Member variables ----

        private HRMAutoComplete autoComplete;
        private IContainer components;
        private List<AutoCompleteDataColumnInfo> _cols = new List<AutoCompleteDataColumnInfo>();
        private bool _addedColumns = false;

        #endregion ---- Member variables ----

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SECAutoCompleteTextBox"/> class.
        /// </summary>
        public HRMAutoCompleteTextBox()
        {
            InitializeComponent();
            this.Text = string.Empty;            
        }

        #endregion ---- Contructors ----

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets an option that controls how automatic completion works for the <see cref="T:System.Windows.Forms.TextBox"/>.
        /// </summary>
        /// <value></value>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.AutoCompleteMode"/>. The values are <see cref="F:System.Windows.Forms.AutoCompleteMode.Append"/>, <see cref="F:System.Windows.Forms.AutoCompleteMode.None"/>, <see cref="F:System.Windows.Forms.AutoCompleteMode.Suggest"/>, and <see cref="F:System.Windows.Forms.AutoCompleteMode.SuggestAppend"/>. The default is <see cref="F:System.Windows.Forms.AutoCompleteMode.None"/>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteMode"/>. </exception>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        public new AutoCompleteModes AutoCompleteMode
        {
            get { return this.autoComplete.GetAutoComplete(this); }
            set { this.autoComplete.SetAutoComplete(this, value); }
        }

        /// <summary>
        /// Gets the auto complete control.
        /// </summary>
        /// <value>The auto complete control.</value>
        public HRMAutoComplete AutoCompleteControl
        {
            get { return autoComplete; }
        }

        /// <summary>
        /// Gets or sets the auto complete data source.
        /// </summary>
        /// <value>The auto complete data source.</value>
        [DefaultValue("")]
        [Description("Indicates the source of data for the AutoCompleteControl.")]
        [RefreshProperties(RefreshProperties.All)]
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        [AttributeProvider(typeof(IListSource))]
        public object AutoCompleteDataSource
        {
            get { return this.autoComplete.DataSource; }
            set { this.autoComplete.DataSource = value; }
        }

        /// <summary>
        /// Gets the auto complete columns.
        /// </summary>
        /// <value>The auto complete columns.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<AutoCompleteDataColumnInfo> AutoCompleteColumns
        {
            get { return _cols; }
        }

        #endregion ---- Properties ----

        #region ---- Private methods ----

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.autoComplete = new HRMAutoComplete(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.autoComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomAutoCompleteTextBox
            // 
            this.autoComplete.SetAutoComplete(this, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended);            
            ((System.ComponentModel.ISupportInitialize)(this.autoComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Sets the parent for auto complete control.
        /// </summary>
        /// <param name="pParent">The p parent.</param>
        private void SetParentForAutoCompleteControl(Control pParent)
        {
            if (pParent.Parent == null)
            {
                this.autoComplete.ParentForm = pParent;
            }
            else
            {
                SetParentForAutoCompleteControl(pParent.Parent);
            }
        }

        #endregion ---- Private methods ----

        #region ---- Protected methods ----

        /// <summary>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            SetParentForAutoCompleteControl(this);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Enter"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (!_addedColumns)
            {
                _addedColumns = true;

                this.autoComplete.Columns.Clear();

                foreach (AutoCompleteDataColumnInfo col in AutoCompleteColumns)
                {
                    this.autoComplete.Columns.Add(col);
                }
            }
        }

        

        #endregion ---- Protected methods ----
    }
}
