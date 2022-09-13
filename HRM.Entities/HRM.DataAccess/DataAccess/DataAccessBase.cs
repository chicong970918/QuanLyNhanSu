using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess
{
    public class DataAccessBase<T> where T: EntityBase
    {
        #region ---- Member variables ----

        /// <summary>
        /// 
        /// </summary>
        private DataEntitiesDataContext _Context = null;

        #endregion

        #region ---- Constructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessBase&lt;T&gt;"/> class.
        /// </summary>
        public DataAccessBase()
        {
            _Context = CacheData.Context;
        }

        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public DataEntitiesDataContext Context
        {
            get { return this._Context; }
        }

        #endregion

        #region ---- Public methods ----

        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <returns></returns>
        public  virtual List<T> GetAll()
        {
            return _Context.GetTable<T>().ToList<T>();
        }


        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public virtual T GetEntityById(int pId)
        {
            return _Context.GetTable<T>().Where(m => ((T)m).Id == pId).Single();
        }

        /// <summary>
        /// Inserts the data.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public virtual void InsertData(T pObject)
        {
            // Set user and date
            DataAccessCommon.SetDefaultValue(pObject, true);

            // Insert object
            _Context.GetTable<T>().InsertOnSubmit(pObject);

            // Save object is inserted
            this._Context.SubmitChanges();
        }

        /// <summary>
        /// Insers the data.
        /// </summary>
        /// <param name="pListObject">The p list object.</param>
        public virtual void InsertData(List<T> pListObject)
        {
            foreach (T pObject in pListObject)
            {
                // Set user and date
                DataAccessCommon.SetDefaultValue(pObject, true);
            }

            // Insert object
            _Context.GetTable<T>().InsertAllOnSubmit(pListObject);

            // Save object is inserted
            this._Context.SubmitChanges();
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public virtual void UpdateData(T pObject)
        {
            T objUpdated = _Context.GetTable<T>().Where(m => ((T)(m)).Id == ((T)(pObject)).Id).FirstOrDefault();

            if (objUpdated != null)
            {
                // Set value changed
                DataAccessCommon.Copy(pObject, objUpdated);

                // Set user and date
                DataAccessCommon.SetDefaultValue(pObject, false);
                
                // Save object is updated
                this._Context.SubmitChanges();
            }

        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public virtual void UpdateDataList(List<T>  plistData)
        {
            foreach (T pObject in plistData)
            {
                T objUpdated = _Context.GetTable<T>().Where(m => ((T)(m)).Id == ((T)(pObject)).Id).FirstOrDefault();

                if (objUpdated != null)
                {

                    // Set value changed
                    DataAccessCommon.Copy(pObject, objUpdated);

                    // Set user and date
                    DataAccessCommon.SetDefaultValue(pObject, false);

                    // Save object is updated
                    this._Context.SubmitChanges();
                }
                else
                {
                    InsertData(pObject);
                }
            }
        }

        /// <summary>
        /// Deletes the data.
        /// </summary>
        /// <param name="pId">The p id.</param>
        public virtual void DeleteData(int pId)
        {
            // Get object deleted
            T objDeleted = _Context.GetTable<T>().Where(m => ((T)(m)).Id == pId).FirstOrDefault();

            if (objDeleted != null)
            {
                // Do delete 
                _Context.GetTable<T>().DeleteOnSubmit(objDeleted);

                // Save changes data
                this._Context.SubmitChanges();
            }
        }

        /// <summary>
        /// Determines whether the specified p code is exist.
        /// </summary>
        /// <param name="pCode">The p code.</param>
        /// <returns>
        /// 	<c>true</c> if the specified p code is exist; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsExists(string pCode)
        {
            return true;
        }

        /// <summary>
        /// Determines whether the specified p object is exists.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns>
        /// 	<c>true</c> if the specified p object is exists; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsExists()
        {
            return true;
        }

        public virtual bool CheckStateChange(T pObject)
        {

            var a = this.Context.GetTable<T>().GetModifiedMembers(pObject);

           // var b = this.Context.GetTable<T>().GetNewBindingList().Clear()

            if (a.Count() > 0  )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public virtual void RefeshContext(T pObject)
        {
           // List<T> sss = this.Context.GetChangeSet().Updates.Where(o => (T)(o)GetType()  );
           // this.Context.Refresh(RefreshMode. )
        }


        #endregion
    }
}
