using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    /// <summary>
    /// 
    /// </summary>
   public partial class DM_ChuyenNganh: EntityBase
    {
        #region ---- Variables ----

        private string _State = string.Empty;

        #endregion

       #region ---- Properties ----

        /// <summary>
        /// Gets or sets the added.
        /// </summary>
        /// <value>The added.</value>
        public string State
       {
           get
           {
               return this._State;
           }
           set
           {
               _State = value;
           }
       }
       #endregion
    }
}
