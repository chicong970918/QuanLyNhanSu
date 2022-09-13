using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.TuyenDung
{
    public class TD_KeHoachThuViecBLL : DataAccessBase<TD_KeHoachThuViec>
    {
        /// <summary>
        /// Gets the data by phong ban quy.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <returns></returns>
        public List<TD_KeHoachThuViec> GetDataByPhongBanQuy(int pIdPhongBan, int pQuy, int pNam)
        {
            DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == pIdPhongBan).FirstOrDefault();

            if (phongban != null)
            {
                if (!phongban.IsPhongNhanSu.HasValue || !phongban.IsPhongNhanSu.Value)
                {
                    List<TD_KeHoachThuViec> list = this.Context.TD_KeHoachThuViecs.Where(td => td.IdPhongBan == pIdPhongBan && td.Quy == pQuy && td.Nam == pNam).ToList<TD_KeHoachThuViec>();
                    var query = from kh in list
                                join uv in this.Context.NV_NhanViens on kh.IdNhanVien equals uv.Id into tempnhanvien
                                from tempvn in tempnhanvien
                                select new
                                {
                                    Id=kh.Id,
                                    MaKeHoachThuViec=kh.MaKeHoachThuViec,
                                    IdPhongBan=kh.IdPhongBan,
                                    Quy=kh.Quy,
                                    Nam=kh.Nam,
                                    IdNhanVien=kh.IdNhanVien,
                                    ThuViecTuNgay=kh.ThuViecTuNgay,
                                    ThuViecDenNgay=kh.ThuViecDenNgay,
                                    GhiChu=kh.GhiChu,
                                    MaQuanLy=tempvn.MaNhanVien,
                                    HoDemQuanLy=tempvn.HoDem,
                                    TenNV=tempvn.Ten
                                };
                    var result = query.ToList().ConvertAll(t => new TD_KeHoachThuViec()
          {
              Id = t.Id,
              MaKeHoachThuViec = t.MaKeHoachThuViec,
              IdPhongBan = t.IdPhongBan,
              Quy = t.Quy,
              Nam = t.Nam,
              IdNhanVien = t.IdNhanVien,
              ThuViecTuNgay = t.ThuViecTuNgay,
              ThuViecDenNgay = t.ThuViecDenNgay,
              GhiChu = t.GhiChu,
              MaNhanVienQuanLy = t.MaQuanLy,
              HoDemQuanLy = t.HoDemQuanLy,
              TenQuanLy = t.TenNV
          });

                    return result.ToList<TD_KeHoachThuViec>();
                }
                else
                {
                    //List<TD_KeHoachThuViec> list = this.Context.TD_KeHoachThuViecs.Where(td => td.IdPhongBan == pIdPhongBan && td.Quy == pQuy && td.Nam == pNam).ToList<TD_KeHoachThuViec>();
                    //return list;
                    List<TD_KeHoachThuViec> list = this.Context.TD_KeHoachThuViecs.Where(td => td.IdPhongBan == pIdPhongBan && td.Quy == pQuy && td.Nam == pNam).ToList<TD_KeHoachThuViec>();
                    var query = from kh in list
                                join uv in this.Context.NV_NhanViens on kh.IdNhanVien equals uv.Id into tempnhanvien
                                from tempvn in tempnhanvien
                                select new
                                {
                                    Id = kh.Id,
                                    MaKeHoachThuViec = kh.MaKeHoachThuViec,
                                    IdPhongBan = kh.IdPhongBan,
                                    Quy = kh.Quy,
                                    Nam = kh.Nam,
                                    IdNhanVien = kh.IdNhanVien,
                                    ThuViecTuNgay = kh.ThuViecTuNgay,
                                    ThuViecDenNgay = kh.ThuViecDenNgay,
                                    GhiChu = kh.GhiChu,
                                    MaQuanLy = tempvn.MaNhanVien,
                                    HoDemQuanLy = tempvn.HoDem,
                                    TenNV = tempvn.Ten
                                };
                    var result = query.ToList().ConvertAll(t => new TD_KeHoachThuViec()
                    {
                        Id = t.Id,
                        MaKeHoachThuViec = t.MaKeHoachThuViec,
                        IdPhongBan = t.IdPhongBan,
                        Quy = t.Quy,
                        Nam = t.Nam,
                        IdNhanVien = t.IdNhanVien,
                        ThuViecTuNgay = t.ThuViecTuNgay,
                        ThuViecDenNgay = t.ThuViecDenNgay,
                        GhiChu = t.GhiChu,
                        MaNhanVienQuanLy = t.MaQuanLy,
                        HoDemQuanLy = t.HoDemQuanLy,
                        TenQuanLy = t.TenNV
                    });

                    return result.ToList<TD_KeHoachThuViec>();
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the data by IDPYC.
        /// </summary>
        /// <param name="pIdPYC">The p id PYC.</param>
        /// <returns></returns>
        ///  26/07/11
        /// DANHTTT-PC
        public List<TD_KeHoachThuViec> GetDataByIDPYC(int pIdPYC)
        {
            List<TD_KeHoachThuViec> listData = this.Context.TD_KeHoachThuViecs.Where(kh => kh.IdPhieuYeuCauTuyenDung == pIdPYC).ToList<TD_KeHoachThuViec>();

            var query = from kh in listData
                        join uv in this.Context.NV_NhanViens on kh.IdNhanVien equals uv.Id into tempnhanvien
                        from tempvn in tempnhanvien
                        select new
                        {
                            Id = kh.Id,
                            MaKeHoachThuViec = kh.MaKeHoachThuViec,
                            IdPhongBan = kh.IdPhongBan,
                            Quy = kh.Quy,
                            Nam = kh.Nam,
                            IdNhanVien = kh.IdNhanVien,
                            ThuViecTuNgay = kh.ThuViecTuNgay,
                            ThuViecDenNgay = kh.ThuViecDenNgay,
                            GhiChu = kh.GhiChu,
                            MaQuanLy = tempvn.MaNhanVien,
                            HoDemQuanLy = tempvn.HoDem,
                            TenNV = tempvn.Ten
                        };
            var result = query.ToList().ConvertAll(t => new TD_KeHoachThuViec()
            {
                Id = t.Id,
                MaKeHoachThuViec = t.MaKeHoachThuViec,
                IdPhongBan = t.IdPhongBan,
                Quy = t.Quy,
                Nam = t.Nam,
                IdNhanVien = t.IdNhanVien,
                ThuViecTuNgay = t.ThuViecTuNgay,
                ThuViecDenNgay = t.ThuViecDenNgay,
                GhiChu = t.GhiChu,
                MaNhanVienQuanLy = t.MaQuanLy,
                HoDemQuanLy = t.HoDemQuanLy,
                TenQuanLy = t.TenNV
            });

            return result.ToList<TD_KeHoachThuViec>();
        }

        /// <summary>
        /// Gets the id phong ban by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public int GetIdPhongBanByIdNhanVien(int pIdNhanVien)
        {
            NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).FirstOrDefault();
            if (item != null)
            {
                return item.IdPhongBan;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets the is phong nhan su.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public bool GetIsPhongNhanSu(int pIdPhongBan)
        {
            DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == pIdPhongBan).FirstOrDefault();
            if (phongban != null)
            {
                return phongban.IsPhongNhanSu.Value;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the data by ten phong ban.
        /// </summary>
        /// <param name="pTenPhongBan">The p ten phong ban.</param>
        /// <returns></returns>
        public List<TD_KeHoachThuViec> GetDataByTenPhongBan(string pTenPhongBan)
        {
            List<TD_KeHoachThuViec> list = new List<TD_KeHoachThuViec>();

            DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => pb.TenPhongBan == pTenPhongBan).FirstOrDefault();

            if (phongban != null)// checked null phongban
            {
                int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue ? LayerCommon.CurrentUser.IdNhanVien.Value : -1;

                NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == IdNhanVien).FirstOrDefault();

                if (item != null)// checked null user dang nhap
                {
                    DM_PhongBan phongbanNS = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == item.IdPhongBan).FirstOrDefault();

                    if (phongbanNS.IsPhongNhanSu.Value)// checked user is nhansu
                    {
                        return this.Context.TD_KeHoachThuViecs.Where(td => td.IdPhongBan == phongban.Id).ToList<TD_KeHoachThuViec>();
                    }
                    else
                    {
                        if (phongban.Id == phongbanNS.Id)
                        {
                            return this.Context.TD_KeHoachThuViecs.Where(td => td.IdPhongBan == item.IdPhongBan).ToList<TD_KeHoachThuViec>();
                        }
                        else
                        {
                            return list;
                        }
                    }
                }
                else
                {
                    return list;
                }
            }
            else
            {
                return list;
            }
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
        /// Gets the nhan vien by ma nhan vien.
        /// </summary>
        /// <param name="pMaNhanVien">The p ma nhan vien.</param>
        /// <returns></returns>
        public NV_NhanVien GetNhanVienByMaNhanVien(string pMaNhanVien,int pIdPhongBan)
        {
            return this.Context.NV_NhanViens.Where(nv => nv.MaNhanVien == pMaNhanVien&& nv.IdPhongBan==pIdPhongBan).FirstOrDefault();

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
        /// Gets the phieu YC by phong ban quy nam.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        ///  26/07/11
        /// DANHTTT-PC
        public List<TD_PhieuYeuCauTuyenDung> GetPhieuYCByPhongBanQuyNam(int pIdPhongBan, int pQuy, int pNam)
        {
            List<TD_PhieuYeuCauTuyenDung> listData = this.Context.TD_PhieuYeuCauTuyenDungs.Where(pyc => pyc.IdPhongBan == pIdPhongBan && pyc.Quy == pQuy && pyc.Nam == pNam && pyc.DaDuyet.HasValue && pyc.DaDuyet.Value == true).ToList<TD_PhieuYeuCauTuyenDung>();

            return listData;
        }
    }
}
