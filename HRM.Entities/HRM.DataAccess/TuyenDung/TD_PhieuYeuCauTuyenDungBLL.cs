using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.TuyenDung
{
    public class TD_PhieuYeuCauTuyenDungBLL : DataAccessBase<TD_PhieuYeuCauTuyenDung>
    {

        /// <summary>
        /// Loads all data.
        /// </summary>
        /// <returns></returns>
        public List<TD_PhieuYeuCauTuyenDung> LoadAllData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Gets the phong ban.
        /// </summary>
        /// <returns></returns>
        public List<DM_PhongBan> GetPhongBan()
        {
            UserInfo _user = LayerCommon.CurrentUser;
            if (_user.IdNhanVien == null || _user.IsPhongNhanSu == true)
            {
                return this.Context.DM_PhongBans.Select(pb => pb).ToList();
            }
            else
            {
                int userPhongBan = (from Pb in this.Context.DM_PhongBans
                                    from Nv in this.Context.NV_NhanViens
                                    where Pb.Id == Nv.IdPhongBan
                                    && Nv.Id == _user.IdNhanVien
                                    select Pb).FirstOrDefault().Id;

                return this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)(pb)).Id == userPhongBan).ToList();
            }
        }

        /// <summary>
        /// Gets the quy.
        /// </summary>
        /// <returns></returns>
        public List<DM_Quy> GetQuy()
        {
            return this.Context.DM_Quys.Select(q => q).ToList();
        }

        /// <summary>
        /// Get Phieu yeu cau by condition
        /// </summary>
        /// <param name="pIdPhongban"></param>
        /// <param name="pQuy"></param>
        /// <param name="pNam"></param>
        /// <returns></returns>
        public List<TD_PhieuYeuCauTuyenDung> GetPhieuYeuCauTDByCondition(int pIdPhongban = 0, int pQuy = 0, int pNam = 0)
        {
            List<TD_PhieuYeuCauTuyenDung> pList = LoadAllData();


            pList = pList.Where(p => p.IdPhongBan == pIdPhongban && p.Quy == pQuy && p.Nam == pNam).ToList();

            var aa = from PYC in pList.ToList()
                     join PB in this.Context.DM_PhongBans on PYC.IdPhongBan equals PB.Id into tmpPhongBan
                     join CD in this.Context.DM_ChucDanhs on PYC.IdChucDanh equals CD.Id into tmpChucDanh
                     join HN in this.Context.DM_TinhTrangHonNhans on PYC.IdTinhTrangHonNhan equals HN.Id into tmpHonNhan
                     join TD in this.Context.DM_TrinhDos on PYC.IdTrinhDo equals TD.Id into tmpTrinhDo
                     join LD in this.Context.DM_LyDos on PYC.IdLyDo equals LD.Id into tmpLyDo
                     join CN in this.Context.DM_ChuyenNganhs on PYC.IdChuyenNganh equals CN.Id into tmpChuyenNganh
                     join NN in this.Context.DM_NgoaiNgus on PYC.IdNgoaiNgu equals NN.Id into tmpNgoaiNgu
                     join TH in this.Context.DM_TrinhDoTinHocs on PYC.IdTrinhDoTinHoc equals TH.Id into tmpTinHoc

                     from phongBan in tmpPhongBan.DefaultIfEmpty()
                     from chucDanh in tmpChucDanh.DefaultIfEmpty()
                     from honNhan in tmpHonNhan.DefaultIfEmpty()
                     from trinhDo in tmpTrinhDo.DefaultIfEmpty()
                     from lyDo in tmpLyDo.DefaultIfEmpty()
                     from chuyenNganh in tmpChuyenNganh.DefaultIfEmpty()
                     from ngoaiNgu in tmpNgoaiNgu.DefaultIfEmpty()
                     from tinHoc in tmpTinHoc.DefaultIfEmpty()

                     select new
                     {
                         Id = PYC.Id,
                         MaPhieuYeuCau = PYC.MaPhieuYeuCau,
                         TenPhieuYeuCau = PYC.TenPhieuYeuCau,
                         IdPhongBan = PYC.IdPhongBan,
                         TenPhongBan = phongBan.TenPhongBan,
                         Quy = PYC.Quy,
                         Nam = PYC.Nam,
                         IdChucDanh = chucDanh != null ? chucDanh.Id : 0,
                         TenChucDanh = chucDanh != null ? chucDanh.TenChucDanh : string.Empty,
                         SoLuong = PYC.SoLuong,
                         SoLuongNam = PYC.SoLuongNam,
                         TuoiTu = PYC.TuoiTu,
                         DenTuoi = PYC.DenTuoi,
                         IdTinhTrangHonNhan = honNhan != null ? honNhan.Id : 0,
                         TenTinhTrangHonNhan = honNhan != null ? honNhan.TenTinhTrang : string.Empty,
                         TenTrinhDo = trinhDo != null ? trinhDo.TenTrinhDo : string.Empty,
                         IdTrinhDo = trinhDo != null ? trinhDo.Id : 0,
                         IdChuyenNganh = chuyenNganh != null ? chuyenNganh.Id : 0,
                         TenChuyenNganh = chuyenNganh != null ? chuyenNganh.TenChuyenNganh : string.Empty,
                         IdLyDo = lyDo != null ? lyDo.Id : 0,
                         TenLyDo = lyDo != null ? lyDo.TenLyDo : string.Empty,
                         IdTrinhDoNgoaiNgu = ngoaiNgu != null ? ngoaiNgu.Id : 0,
                         TenTrinhDoNgoaiNgu = ngoaiNgu != null ? ngoaiNgu.TenNgoaiNgu : string.Empty,
                         IdTrinhDoTinHoc = tinHoc != null ? tinHoc.Id : 0,
                         TenTrinhDoTinHoc = tinHoc != null ? tinHoc.TenTrinhDoTinHoc : string.Empty,
                         SoNamKinhNghiem = PYC.SoNamKinhNghiem,
                         YeuCauKhac = PYC.YeuCauKhac,
                         YeuCauCanThiet = PYC.YeuCauCanThiet,
                         YeuCauSucKhoe = PYC.YeuCauSucKhoe,
                         NgayCanNhanSu = PYC.NgayCanNhanSu,
                         DaDuyet = PYC.DaDuyet,
                         KhongDuyet = PYC.KhongDuyet
                     };

            var result = aa.ToList().ConvertAll<TD_PhieuYeuCauTuyenDung>(td => new TD_PhieuYeuCauTuyenDung()
            {
                Id = td.Id,
                MaPhieuYeuCau = td.MaPhieuYeuCau,
                TenPhieuYeuCau = td.TenPhieuYeuCau,
                IdPhongBan = td.IdPhongBan,
                TenPhongBan = td.TenPhongBan,
                Quy = td.Quy,
                Nam = td.Nam,
                IdChucDanh = td.IdChucDanh,
                TenChucDanh = td.TenChucDanh,
                SoLuong = td.SoLuong,
                SoLuongNam = td.SoLuongNam,
                TuoiTu = td.TuoiTu,
                DenTuoi = td.DenTuoi,
                IdTinhTrangHonNhan = td.IdTinhTrangHonNhan,
                TenTinhTrangHonNhan = td.TenTinhTrangHonNhan,
                TenTrinhDo = td.TenTrinhDo,
                IdTrinhDo = td.IdTrinhDo,
                IdChuyenNganh = td.IdChuyenNganh,
                TenChuyenNganh = td.TenChuyenNganh,
                IdLyDo = td.IdLyDo,
                TenLyDo = td.TenLyDo,
                IdNgoaiNgu = td.IdTrinhDoNgoaiNgu,
                IdTrinhDoTinHoc = td.IdTrinhDoTinHoc,
                TenTrinhDoTinHoc = td.TenTrinhDoTinHoc,
                TenTrinhDoNgoaiNgu = td.TenTrinhDoNgoaiNgu,
                SoNamKinhNghiem = td.SoNamKinhNghiem,
                YeuCauKhac = td.YeuCauKhac,
                YeuCauCanThiet = td.YeuCauCanThiet,
                YeuCauSucKhoe = td.YeuCauSucKhoe,
                NgayCanNhanSu = td.NgayCanNhanSu,
                DaDuyet = td.DaDuyet,
                KhongDuyet = td.KhongDuyet

            });

            return result;
        }

        /// <summary>
        /// Gets the nhan vien by ID.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public NV_NhanVien GetNhanVienByID(int pIdNhanVien)
        {
            return this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).FirstOrDefault();
        }

        /// <summary>
        /// Checks the existed ma phieu yeu cau.
        /// </summary>
        /// <param name="pYeuCau">The p yeu cau.</param>
        /// <returns></returns>
        public bool CheckExistedMaPhieuYeuCau(TD_PhieuYeuCauTuyenDung pYeuCau)
        {
            IQueryable<TD_PhieuYeuCauTuyenDung> listPYC = this.Context.TD_PhieuYeuCauTuyenDungs.Where(p => ((TD_PhieuYeuCauTuyenDung)p).IdPhongBan == pYeuCau.IdPhongBan
                                                        && ((TD_PhieuYeuCauTuyenDung)p).MaPhieuYeuCau == pYeuCau.MaPhieuYeuCau);
            if (listPYC.Count() > 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ups the date xet duyet phieu yeu cau.
        /// </summary>
        /// <param name="pListId">The p list id.</param>
        /// <param name="pListKhongDuyet">The p list khong duyet.</param>
        /// <returns></returns>
        public bool UpDateXetDuyetPhieuYeuCau(List<int> pListId,List<int> pListKhongDuyet)
        {
            for (int i = 0; i < pListId.Count; i++)
            {
                TD_PhieuYeuCauTuyenDung phieyYeuCau = this.Context.TD_PhieuYeuCauTuyenDungs.Where(p => ((TD_PhieuYeuCauTuyenDung)p).Id == pListId[i]).FirstOrDefault();
                if (phieyYeuCau != null)
                {
                    phieyYeuCau.DaDuyet = true;
                    phieyYeuCau.KhongDuyet = false;
                }
            }
            this.Context.SubmitChanges();

            for (int i = 0; i < pListKhongDuyet.Count; i++)
            {
                TD_PhieuYeuCauTuyenDung phieyYeuCau = this.Context.TD_PhieuYeuCauTuyenDungs.Where(p => ((TD_PhieuYeuCauTuyenDung)p).Id == pListKhongDuyet[i]).FirstOrDefault();
                if (phieyYeuCau != null)
                {
                    phieyYeuCau.KhongDuyet = true;
                }
            }
            this.Context.SubmitChanges();
            return true;

        }

        /// <summary>
        /// Gets the ke hoach tuyen dung.
        /// </summary>
        /// <param name="pIDPhongban">The p ID phongban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TD_BangKeHoachTuyenDung> GetKeHoachTuyenDung(int pIDPhongban, int pQuy, int pNam)
        {
            List<TD_BangKeHoachTuyenDung> list = this.Context.TD_BangKeHoachTuyenDungs.Where(td => td.IdPhongBan == pIDPhongban && td.Quy == pQuy && td.Nam == pNam&& td.DaDuyet.Value==true).ToList<TD_BangKeHoachTuyenDung>();

            return list;
        }

        /// <summary>
        /// Gets the ke hoach tuyen dung.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public List<TD_ChiTietKeHoachTuyenDung> GetChiTietKeHoachTuyenDungById(int pId)
        {
            List<TD_ChiTietKeHoachTuyenDung> list = this.Context.TD_ChiTietKeHoachTuyenDungs.Where(td => td.IdBangKeHoachTuyenDung == pId).ToList<TD_ChiTietKeHoachTuyenDung>();

            return list;
        }

        /// <summary>
        /// Gets the ke hoach tuyen dung by id.
        /// </summary>
        /// <param name="pId">The p id.</param>
        /// <returns></returns>
        public TD_BangKeHoachTuyenDung GetKeHoachTuyenDungById(int pId)
        {
            TD_BangKeHoachTuyenDung list = this.Context.TD_BangKeHoachTuyenDungs.Where(td => ((TD_BangKeHoachTuyenDung)td).Id == pId).FirstOrDefault();

            return list; 
        }

        /// <summary>
        /// Checkeds the is using.
        /// </summary>
        /// <param name="pIdPhieuYeuCau">The p id phieu yeu cau.</param>
        /// <returns></returns>
        ///  20/08/11
        /// DANHTTT-PC
        public bool CheckedIsUsing(int pIdPhieuYeuCau)
        {
            TD_PhieuYeuCauTuyenDung PYC = this.Context.TD_PhieuYeuCauTuyenDungs.Where(pyc => ((TD_PhieuYeuCauTuyenDung)pyc).Id == pIdPhieuYeuCau).FirstOrDefault();

            if (PYC != null && PYC.DaDuyet.HasValue && PYC.DaDuyet.Value==true)
            {
                return false;
            }

            return true;
        }
    }
}
