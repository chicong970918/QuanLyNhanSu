using System.Data.Linq.Mapping;
using System;
using System.Reflection;
namespace HRM.Entities
{
    partial class DataEntitiesDataContext
    {
        [Function(Name = "GetDate", IsComposable = true)]
        public DateTime GetSystemDate()
        {
            MethodInfo mi = MethodBase.GetCurrentMethod() as MethodInfo;
            return (DateTime)this.ExecuteMethodCall(this, mi, new object[] { }).ReturnValue;
        }

    }
}
