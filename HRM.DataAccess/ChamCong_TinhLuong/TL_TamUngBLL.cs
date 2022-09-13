using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.ChamCong_TinhLuong
{
    /// <summary>
    /// 
    /// </summary>
    public class TL_TamUngBLL : DataAccessBase<TL_TamUng>
    {
        /// <summary>
        /// Loads the data by condition.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pNam">The p nam.</param>
        /// <param name="pThang">The p thang.</param>
        /// <returns></returns>
        public List<TL_TamUng> LoadDataByCondition(int pIdPhongBan, int pThang, int pNam)
        {
            List<TL_TamUng> listTamUng=this.Context.TL_TamUngs.Where(tu=>tu.NgayTamUng.Year==pNam && tu.NgayTamUng.Month==pThang).ToList<TL_TamUng>();

            List<NV_NhanVien> listNhanVien = this.Context.NV_NhanViens.Where(nv => nv.IdPhongBan == pIdPhongBan).ToList<NV_NhanVien>();

            var query = from tamung in listTamUng
                        join nhanvien in listNhanVien on tamung.IdNhanVien equals ((NV_NhanVien)nhanvien).Id
                        select new
                        {
                            MaNhanVien=nhanvien.MaNhanVien,
                            HoDem=nhanvien.HoDem,
                            Ten=nhanvien.Ten,
                            Id=((TL_TamUng)tamung).Id,
                            IdNhanVien=tamung.IdNhanVien,
                            NgayTamUng=tamung.NgayTamUng,
                            SoTien=tamung.SoTien,
                            LyDo=tamung.LyDo,
                            GhiChu=tamung.GhiChu
                        };
            var result = query.ToList().ConvertAll(t => new TL_TamUng()
            {
                Id=t.Id,
                IdNhanVien=t.IdNhanVien,
                MaNhanVien=t.MaNhanVien,
                HoDem=t.HoDem,
                Ten=t.Ten,
                NgayTamUng=t.NgayTamUng,
                SoTien=t.SoTien,
                LyDo=t.LyDo,
                GhiChu=t.GhiChu
            });

            return result.ToList<TL_TamUng>();

        }

        /// <summary>
        /// Gets the nhan vien by ma nhan vien.
        /// </summary>
        /// <param name="pMaNhanVien">The p ma nhan vien.</param>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public NV_NhanVien GetNhanVienByMaNhanVien(string pMaNhanVien,int pIdPhongBan)
        {
            NV_NhanVien item = this.Context.NV_NhanViens.Where(uv => uv.MaNhanVien == pMaNhanVien && uv.IdPhongBan==pIdPhongBan).FirstOrDefault();

            return item;
        }

        /// <summary>
        /// Checkeds the is using.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public bool CheckedIsUsing(int pThang, int pNam)
        {
            TL_BangLuong bangluong = this.Context.TL_BangLuongs.Where(bl => bl.Thang == pThang && bl.Nam == pNam).FirstOrDefault();

            if (bangluong != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checkeds the tam ung.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <param name="pSoTien">The p so tien.</param>
        /// <returns></returns>
        ///  09/10/11
        /// PC
        public bool CheckedTamUng(int pIdNhanVien,decimal pSoTien)
        {
            NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).FirstOrDefault();

            if (nhanvien == null)
            {
                return false;
            }

            DM_ChucDanh chucdah = this.Context.DM_ChucDanhs.Where(cd => ((DM_ChucDanh)cd).Id == nhanvien.HienTaiChucDanh).FirstOrDefault();

            if (chucdah == null)
            {
                return false;
            }

            if (pSoTien > (chucdah.LuongCanBan.Value / 2))
            {
                return false;
            }
            return true;
        }
    }
}
