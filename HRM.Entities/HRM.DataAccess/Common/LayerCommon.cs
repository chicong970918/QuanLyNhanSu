using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
 

using System.Reflection;

namespace HRM.DataAccess.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class LayerCommon
    {
        #region ---- Member variables ----

        private static UserInfo _currentUser;

        public static Thread _SecondThread;

        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>The current user.</value>
        public static UserInfo CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        #endregion

        #region ---- Public methods ----

        /// <summary>
        /// Gets the string resource.
        /// </summary>
        /// <param name="pResourceID">The p resource ID.</param>
        /// <returns></returns>
        public static string GetStringResource(string pResourceID)
        {
            string message = Properties.Resources.ResourceManager.GetString(pResourceID);
           
            return message;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <param name="pPropertyName">Name of the p property.</param>
        /// <returns></returns>
        public static dynamic GetPropertyValue(object pObject, string pPropertyName)
        {
            dynamic value = null;

            // Had object and Property name
            if (pObject != null &&
                !string.IsNullOrEmpty(pPropertyName))
            {
                // Get type
                Type type = pObject.GetType();

                // Get value
                value = type.GetProperty(pPropertyName).GetValue(pObject, null);
            }

            return value;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="pData">The p data.</param>
        /// <param name="pPropertyName">Name of the p property.</param>
        /// <param name="pValue">The p value.</param>
        /// <param name="pOverride">if set to <c>true</c> [p override].</param>
        public static void SetPropertyValue(dynamic pData, string pPropertyName,
                                            dynamic pValue, bool pOverride = false)
        {
            // Get property info
            PropertyInfo property = pData.GetType().GetProperty(pPropertyName);

            // Property existed
            if (property != null)
            {
                // Override
                if (pOverride)
                {
                    // Set value
                    property.SetValue(pData, pValue, null);
                }
                else // Not override
                {
                    // Get value of property
                    dynamic value = property.GetValue(pData, null);

                    // Value is null
                    if (value == null)
                    {
                        // Set value
                        property.SetValue(pData, pValue, null);
                    }
                }
            }
        }

        /// <summary>
        /// Starts the thread.
        /// </summary>
        /// <param name="pValue">The p value.</param>
        public static void StartThread(ThreadStart pValue)
        {
            while (_SecondThread != null)
            {
                if (_SecondThread.ThreadState == ThreadState.Stopped)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(100);
                }
            }

            _SecondThread = new Thread(pValue) { Name = "SeconThread", Priority = ThreadPriority.Highest, };
            _SecondThread.Start();
        }

        /// <summary>
        /// Copies the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        public static void Copy(object source, object destination, params object[] propertyNonCopy)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            foreach (PropertyInfo info in sourceType.GetProperties())
            {
                if ((propertyNonCopy.Length > 0 && propertyNonCopy.Contains(info.Name)) ||
                    string.Equals(info.Name, "TrackingState") ||
                    string.Equals(info.Name, "ChangeTracker") ||
                    string.Equals(info.Name, "Item"))
                {
                    continue;
                }

                PropertyInfo destinationInfo = destinationType.GetProperty(info.Name);
                if (destinationInfo != null && destinationInfo.CanWrite && info.CanRead)
                {
                    destinationInfo.SetValue(destination, info.GetValue(source, null), null);
                }
            }
        }

        #endregion
    }
}
