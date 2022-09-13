using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Forms.Tools;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace Library.Controls
{
    public partial class HRMAutoComplete : AutoComplete
    {
        public HRMAutoComplete()
            : base()
        {

        }

        public HRMAutoComplete(IContainer container)
            : base(container)
        {

        }

        /// <summary>
        /// Populates the list with matches.
        /// </summary>
        /// <param name="currentText">The current text.</param>
        /// <param name="listDataView">The DataView object that has the list of matches.</param>
        /// <returns></returns>
        protected override int PopulateListWithMatches(string currentText, ref DataView listDataView)
        {

            try
            {
                return base.PopulateListWithMatches(currentText, ref listDataView);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Filters the complete list of items to be considered for matches to form a
        /// set of probable matches.
        /// </summary>
        /// <param name="currentText">The text to the matched.</param>
        /// <param name="listDataView">The matching items will be added to this ListView.</param>
        /// <param name="exactMatch"></param>
        /// <param name="matchingRow"></param>
        /// <returns>The count of the matches.</returns>
        /// <remarks>
        /// Override this function if you want to use a different matching routine
        /// from the internal built in matching routine.
        /// </remarks>
        protected override int PopulateListWithMatches(string currentText, ref DataView listDataView, bool exactMatch, ref DataRow matchingRow)
        {
            try
            {
                return base.PopulateListWithMatches(currentText, ref listDataView, exactMatch, ref matchingRow);
            }
            catch
            {
                return 0;
            }
        }          
    }
}
