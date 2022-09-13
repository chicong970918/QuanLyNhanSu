using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Library
{
   public  class ControlsSettings
    {
        #region ---- Member variables ----

        /// <summary>
        /// 
        /// </summary>
        private static Size _statusCellImageSize = new Size(16, 16);

        /// <summary>
        /// 
        /// </summary>
        private static Color _gridGrouppingErrorHighLightColor = Color.Orange;

        #endregion ---- Member variables ----

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the color of the grid groupping error high light.
        /// </summary>
        /// <value>The color of the grid groupping error high light.</value>
        public static Color GridGrouppingErrorHighLightColor
        {
            get { return ControlsSettings._gridGrouppingErrorHighLightColor; }
            set { ControlsSettings._gridGrouppingErrorHighLightColor = value; }
        }

        /// <summary>
        /// Gets or sets the size of the status cell image.
        /// </summary>
        /// <value>The size of the status cell image.</value>
        public static Size StatusCellImageSize
        {
            get { return ControlsSettings._statusCellImageSize; }
            set { ControlsSettings._statusCellImageSize = value; }
        }

        #endregion ---- Properties ----
    }
}
