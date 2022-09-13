using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.QuanLyNhanVien
{
    public class NV_HopDongBLL : DataAccessBase<NV_HopDong>
    {
        /// <summary>
        /// Gets the hop dong by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<NV_HopDong> GetHopDongByIdNhanVien(int pIdNhanVien, int pLoaiHopDong)
        {
            return this.Context.NV_HopDongs.Where(kt => kt.IdNhanVien == pIdNhanVien && kt.IdLoaiHopDong == pLoaiHopDong).ToList<NV_HopDong>();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
        public override void UpdateDataList(List<NV_HopDong> plistData)
        { 
            foreach (NV_HopDong item in plistData)
            {
                if (!(item.SoHopDong>0))
                {
                    int soquyetdinh = -1;
                    try
                    {
                        soquyetdinh = this.Context.NV_HopDongs.Select(u => u).Max(u => u.SoHopDong) + 1;
                    }
                    catch
                    {
                        soquyetdinh = 1;
                    }
                 
                    item.SoHopDong = soquyetdinh;
                    NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == item.IdNhanVien).FirstOrDefault();

                    if (nhanvien != null)
                    {
                        nhanvien.HienTaiLoaiHopDong = 2;
                    }
                }
            }

            base.UpdateDataList(plistData);
        }
        /// <summary>
        /// Updates the data list thu viec.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
        ///  07/07/11
        /// PC
        public   void UpdateDataListThuViec(List<NV_HopDong> plistData)
        { 
            foreach (NV_HopDong item in plistData)
            {
                if (!(item.SoHopDong >0))
                {
                    int soquyetdinh = -1;
                    try
                    {
                        soquyetdinh = this.Context.NV_HopDongs.Select(u => u).Max(u => u.SoHopDong) + 1;
                    }
                    catch
                    {
                        soquyetdinh = 1;
                    }
                    item.SoHopDong = soquyetdinh;
                    NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == item.IdNhanVien).FirstOrDefault();

                    if (nhanvien != null)
                    {
                        nhanvien.HienTaiLoaiHopDong = 1;
                    }
                }
            }

            base.UpdateDataList(plistData);
        }

        /// <summary>
        /// Gets the hop dong gan nhat.
        /// </summary>
        /// <param name="PIdNhanVien">The P id nhan vien.</param>
        /// <param name="PIdLoaiHD">The P id loai HD.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        public NV_HopDong GetHopDongGanNhat(int PIdNhanVien, int PIdLoaiHD)
        {
            return this.Context.NV_HopDongs.Where(hd => hd.IdNhanVien == PIdNhanVien && hd.IdLoaiHopDong == PIdLoaiHD).OrderByDescending(hd => hd.NgayKy).FirstOrDefault();
        }

        /// <summary>
        /// Checkeds the ket thuc HD thoi viec.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        ///  07/07/11
        /// PC
        public bool CheckedKetThucHDThoiViec(int pIdNhanVien)
        {
            NV_HopDong NhanVienThuViec = this.Context.NV_HopDongs.Where(hd => hd.IdLoaiHopDong == 1 && hd.IdNhanVien == pIdNhanVien).FirstOrDefault();

            if (NhanVienThuViec != null)
            {
                if (CacheData.Context.GetSystemDate() < NhanVienThuViec.NgayKetThuc.Value)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Checkeds the ket thuc HD chinh thuc.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        ///  07/07/11
        /// PC
        public bool CheckedKetThucHDChinhThuc(int pIdNhanVien)
        {
            try
            {
                int sohopdong = this.Context.NV_HopDongs.Where(hd => hd.IdLoaiHopDong == 2 && hd.IdNhanVien == pIdNhanVien).Max(hd => hd.SoHopDong);
                NV_HopDong NhanVienThuViec = this.Context.NV_HopDongs.Where(hd => hd.IdLoaiHopDong == 2 && hd.IdNhanVien == pIdNhanVien && hd.SoHopDong == sohopdong).FirstOrDefault();

                if (NhanVienThuViec != null)
                {
                    if (CacheData.Context.GetSystemDate() < NhanVienThuViec.NgayKetThuc.Value)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Caps the nhat loai hop dong.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        ///  07/07/11
        /// PC
        public void CapNhatLoaiHopDong(int pIdNhanVien)
        {
            NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).FirstOrDefault();
            if (nhanvien != null)
            {
                nhanvien.HienTaiLoaiHopDong = null;
            }

        }
    }
}
