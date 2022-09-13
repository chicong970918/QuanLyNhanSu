using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Reflection;
using System.Data.Linq;
 
using System.Data.Linq.Mapping;

namespace HRM.Entities
{

    public class CacheData
    {

        private const string SQL = "SELECT COUNT(*) FROM {0} WHERE {1}=@p0";
        public static string ConnectionString = string.Empty;
        public enum OjectState
        {
            Added,
            Deleted,
            Modified,
            Unchaged,
        };

        #region ---- Variables ----

        private static DataEntitiesDataContext _Context = null;
        private static QL_NguoiDung _UserCurrent = null;

        #endregion

        public static DataEntitiesDataContext Context
        {
            get
            {
                if (CacheData._Context == null)
                {
                    CacheData._Context = new DataEntitiesDataContext();
                    ConnectionString = _Context.Connection.ConnectionString;
                }
                return CacheData._Context;
            }
            set { CacheData._Context = value; }
        }

        /// <summary>
        /// Gets or sets the user current.
        /// </summary>
        /// <value>The user current.</value>
        public static QL_NguoiDung CurrentUser
        {
            get { return CacheData._UserCurrent; }
            set { CacheData._UserCurrent = value; }
        }

        #region ---- GetDanhMuc ----

        public string GetTenChucDanhById(int pId)
        {
            DM_ChucDanh chucdanh = _Context.DM_ChucDanhs.Where(cd => cd.Id == pId).FirstOrDefault();

            return chucdanh == null ? string.Empty : chucdanh.TenChucDanh;
        }

        /// <summary>
        /// Gets the danh muc cap tuyen dung.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_CapTuyenDung> GetDanhMucCapTuyenDung()
        {
            return Context.DM_CapTuyenDungs.Select(c => c);

        }

        /// <summary>
        /// Gets the danh muc chuc danh.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_ChucDanh> GetDanhMucChucDanh()
        {
            return Context.DM_ChucDanhs.Select(cd => cd);
        }

        /// <summary>
        /// Gets the danh muc chuyen nganh.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_ChuyenNganh> GetDanhMucChuyenNganh()
        {
            return Context.DM_ChuyenNganhs.Select(cn => cn);
        }

        /// <summary>
        /// Gets the danh muc dan toc.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_DanToc> GetDanhMucDanToc()
        {
            return Context.DM_DanTocs.Select(dt => dt);
        }

        /// <summary>
        /// Gets the danh muc huyen.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_Huyen> GetDanhMucHuyen()
        {
            return Context.DM_Huyens.Select(h => h);
        }

        /// <summary>
        /// Gets the danh muc ly do.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_LyDo> GetDanhMucLyDo()
        {
            return Context.DM_LyDos.Select(ld => ld);
        }

        /// <summary>
        /// Gets the danh muc ngoai ngu.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_NgoaiNgu> GetDanhMucNgoaiNgu()
        {
            return Context.DM_NgoaiNgus.Select(nn => nn);
        }

        /// <summary>
        /// Gets the danh muc phong ban.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_PhongBan> GetDanhMucPhongBan()
        {
            return Context.DM_PhongBans.Select(pb => pb);
        }

        /// <summary>
        /// Gets the danh muc phu cap.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_PhuCap> GetDanhMucPhuCap()
        {
            return Context.DM_PhuCaps.Select(pc => pc);
        }

        /// <summary>
        /// Gets the danh muc quan he.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_QuanHe> GetDanhMucQuanHe()
        {
            return Context.DM_QuanHes.Select(qh => qh); ;
        }

        /// <summary>
        /// Gets the danh muc quy.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_Quy> GetDanhMucQuy()
        {
            return Context.DM_Quys.Select(t => t);
        }

        /// <summary>
        /// Gets the danh muc tinh.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_Tinh> GetDanhMucTinh()
        {
            return Context.DM_Tinhs.Select(t => t);
        }

        /// <summary>
        /// Gets the danh muc tinh trang hon nhan.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_TinhTrangHonNhan> GetDanhMucTinhTrangHonNhan()
        {
            return Context.DM_TinhTrangHonNhans.Select(tt => tt);
        }

        /// <summary>
        /// Gets the danh muc ton giao.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_TonGiao> GetDanhMucTonGiao()
        {
            return Context.DM_TonGiaos.Select(tg => tg);
        }

        /// <summary>
        /// Gets the danh muc trinh do.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_TrinhDo> GetDanhMucTrinhDo()
        {
            return Context.DM_TrinhDos.Select(td => td);
        }

        /// <summary>
        /// Gets the danh muc trinh do tin hoc.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_TrinhDoTinHoc> GetDanhMucTrinhDoTinHoc()
        {
            return Context.DM_TrinhDoTinHocs.Select(td => td);
        }

        /// <summary>
        /// Gets the danh muc yeu cau cong viec.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<DM_YeuCauCongViec> GetDanhMucYeuCauCongViec()
        {
            return Context.DM_YeuCauCongViecs.Select(yc => yc);
        }

        #endregion

        #region ---- Get Ten Danh Muc

        /// <summary>
        /// Get the names of the phong ban
        /// </summary>
        /// <param name="pIdPhongBan"></param>
        /// <returns></returns>
        public static string GetTenPhongBan(int pIdPhongBan)
        {
            DM_PhongBan item = Context.DM_PhongBans.Where(cd => ((DM_PhongBan)cd).Id == pIdPhongBan).FirstOrDefault();
            return item == null ? string.Empty : item.TenPhongBan;
        }
        /// <summary>
        /// Gets the ma phong ban.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public static string GetMaPhongBan(int pIdPhongBan)
        {
            DM_PhongBan item = Context.DM_PhongBans.Where(cd => ((DM_PhongBan)cd).Id == pIdPhongBan).FirstOrDefault();
            return item == null ? string.Empty : item.MaPhongBan;
        }

        /// <summary>
        /// Get the ten chuc danh
        /// </summary>
        /// <param name="pIdChucDanh"></param>
        /// <returns></returns>
        public static string GetTenChucDanh(int pIdChucDanh)
        {
             DM_ChucDanh item =  Context.DM_ChucDanhs.Where(cd => ((DM_ChucDanh)cd).Id == pIdChucDanh).FirstOrDefault();
             return item == null ? string.Empty : item.TenChucDanh;
        }
        /// <summary>
        /// Gets the ten ton giao.
        /// </summary>
        /// <param name="pIdTonGiao">The p id ton giao.</param>
        /// <returns></returns>
        public static string GetTenTonGiao(int pIdTonGiao)
        {
            DM_TonGiao item = Context.DM_TonGiaos.Where(cd => ((DM_TonGiao)cd).Id == pIdTonGiao).FirstOrDefault();
            return item == null ? string.Empty : item.TenTonGiao;
        }

        /// <summary>
        /// Gets the ten tinh thanh.
        /// </summary>
        /// <param name="pIdTinh">The p id tinh.</param>
        /// <returns></returns>
        public static string GetTenTinhThanh(int pIdTinh)
        {
            DM_Tinh item = Context.DM_Tinhs.Where(cd => ((DM_Tinh)cd).Id == pIdTinh).FirstOrDefault();
            return item == null ? string.Empty : item.TenTinh;
        }

        /// <summary>
        /// Get the name tinh trang hon nhan
        /// </summary>
        /// <param name="pIdTinhTrangHonNhan"></param>
        /// <returns></returns>
        public static string GetTenTinhTrangHonNhan(int pIdTinhTrangHonNhan)
        {
            DM_TinhTrangHonNhan item = Context.DM_TinhTrangHonNhans.Where(cd => ((DM_TinhTrangHonNhan)cd).Id == pIdTinhTrangHonNhan).FirstOrDefault();
            return item == null ? string.Empty : item.TenTinhTrang;
        }
        /// <summary>
        /// Gets the ten dan toc.
        /// </summary>
        /// <param name="pIdDanToc">The p id dan toc.</param>
        /// <returns></returns>
        public static string GetTenDanToc(int pIdDanToc)
        {
            DM_DanToc item = Context.DM_DanTocs.Where(cd => ((DM_DanToc)cd).Id == pIdDanToc).FirstOrDefault();
            return item == null ? string.Empty : item.TenDanToc;
        }

        /// <summary>
        /// Get the name trinh do
        /// </summary>
        /// <param name="pIdTrinhDo"></param>
        /// <returns></returns>
        public static string GettenTrinhDo(int pIdTrinhDo)
        {
            DM_TrinhDo item = Context.DM_TrinhDos.Where(cd => ((DM_TrinhDo)cd).Id == pIdTrinhDo).FirstOrDefault();
            return item == null ? string.Empty : item.TenTrinhDo;
        }

        /// <summary>
        /// Get the name Ly do
        /// </summary>
        /// <param name="pIdLyDo"></param>
        /// <returns></returns>
        public static string GetTenLyDo(int pIdLyDo)
        {
            DM_LyDo item = Context.DM_LyDos.Where(cd => ((DM_LyDo)cd).Id == pIdLyDo).FirstOrDefault();
            return item == null ? string.Empty : item.TenLyDo;
        }

        /// <summary>
        /// Get the name chuyen nganh
        /// </summary>
        /// <param name="pIdChuyenNganh"></param>
        /// <returns></returns>
        public static string GetTenChuyenNgah(int pIdChuyenNganh)
        {
            DM_ChuyenNganh item = Context.DM_ChuyenNganhs.Where(cd => ((DM_ChuyenNganh)cd).Id == pIdChuyenNganh).FirstOrDefault();
            return item == null ? string.Empty : item.TenChuyenNganh;
        }

        /// <summary>
        /// Get the name trinh do ngoai ngu
        /// </summary>
        /// <param name="pIdNgoaiNgu"></param>
        /// <returns></returns>
        public static string GetTenTrinhDoNgoaiNgu(int pIdNgoaiNgu)
        {
            DM_NgoaiNgu item = Context.DM_NgoaiNgus.Where(cd => ((DM_NgoaiNgu)cd).Id == pIdNgoaiNgu).FirstOrDefault();
            return item == null ? string.Empty : item.TenNgoaiNgu;
        }

        /// <summary>
        /// Get the name trinh do tin hoc
        /// </summary>
        /// <param name="pIdTinHoc"></param>
        /// <returns></returns>
        public static string GetTenTrinhDoTinHoc(int pIdTinHoc)
        {
            DM_TrinhDoTinHoc item = Context.DM_TrinhDoTinHocs.Where(cd => ((DM_TrinhDoTinHoc)cd).Id == pIdTinHoc).FirstOrDefault();
            return item == null ? string.Empty : item.TenTrinhDoTinHoc;
        }

        #endregion

        #region ---- Get NhanVien

        /// <summary>
        /// Gets the nhan vien by ma nhan vien.
        /// </summary>
        /// <param name="pMaNhanVien">The p ma nhan vien.</param>
        /// <returns></returns>
        public static NV_NhanVien GetNhanVienByMaNhanVien(int pIdNhanVien)
        {
            return Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).FirstOrDefault();
        }

        #endregion

        #region ---- Using Key ----

        /// <summary>
        /// Determines whether [is key using] [the specified object name].
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// 	<c>true</c> if [is key using] [the specified object name]; otherwise, <c>false</c>.
        /// </returns>
        /// <Author>LONG LY</Author>
        /// <Date>11/06/2011</Date>
        public static bool IsKeyUsing(string objectName, object entity)
        {

            string sql = string.Empty;
            string tableName = string.Empty;
            string fieldName = string.Empty;

            Context.SP_UpdateReferenceTable();
            // Get list of tables
            List<HT_Table> tblList = Context.HT_Tables.ToList();
           // DM_ManHinh manHinh = Context.DM_ManHinhs.Where(mh=>mh.MaManHinh == objectName).FirstOrDefault();
            HT_Table tbl = tblList.Find(d => d.TableName == objectName);

            // Check data
            if (tbl != null)
            {
                List<HT_ReferenceTable> refList = Context.HT_ReferenceTables.Where(d =>((HT_ReferenceTable)d).IdTable == ((HT_Table)tbl).Id).ToList();

                // Process data
                if (refList.Count > 0)
                {
                    // Get fields
                    List<HT_Field> fieldList = Context.HT_Fields.ToList();

                    // Check if data is exist
                    foreach (HT_ReferenceTable item in refList)
                    {
                        // Generate sql and execute
                        tableName = tblList.Find(d => d.Id == item.IdReferenceTable).TableName;
                        fieldName = fieldList.Find(d => d.Id == item.IdReferenceField).FieldName;
                        sql = string.Format(SQL, tableName, fieldName);
                        var result = Context.ExecuteQuery<int>(sql, GetPropertyValue(entity, "Id"));

                        // Existed
                        if (result.FirstOrDefault() > 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>11/06/2011</Date>
        public static string GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null).ToString();
        }

        #endregion

        public static bool TestConnection()
        {
            CacheData._Context = new DataEntitiesDataContext();
            ConnectionString = _Context.Connection.ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// Tests the connection config.
        /// </summary>
        /// <param name="conn">The conn.</param>
        /// <returns></returns>
        ///  17/05/22
        /// PC
        public static bool TestConnectionConfig(string conn)
        {
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
