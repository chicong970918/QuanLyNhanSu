using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using HRM.Entities;

namespace HRM.DataAccess.Common
{
    public class DataAccessCommon
    {
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
        /// Sets the default value.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <param name="pIsInsert">if set to <c>true</c> [p is insert].</param>
        public static void SetDefaultValue(EntityBase pObject, bool pIsInsert)
        {
            //if (pIsInsert)
            //{
            //    SetPropertyValue(pObject, "CreatedUser", LayerCommon.CurrentUser.IdNhanVien.Value, true);
            //    SetPropertyValue(pObject, "CreatedDate", CacheData.Context.GetSystemDate(), true);

            //}

            //SetPropertyValue(pObject, "UpdatedUser", LayerCommon.CurrentUser.IdNhanVien.Value, true);
            //SetPropertyValue(pObject, "UpdatedDate", CacheData.Context.GetSystemDate(), true);
        }

        /// <summary>
        /// Copies the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        public static void Copy(object source, object destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            foreach (PropertyInfo info in sourceType.GetProperties())
            {
                PropertyInfo destinationInfo = destinationType.GetProperty(info.Name);
                if (destinationInfo != null && destinationInfo.CanWrite && info.CanRead)
                {
                    destinationInfo.SetValue(destination, info.GetValue(source, null), null);
                }
            }
        }
    }
}
