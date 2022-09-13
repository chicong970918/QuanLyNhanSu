using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.ChamCong_TinhLuong
{
    public class TL_TongHopChamCongBLL : DataAccessBase<TL_TongHopChamCong>
    {

        /// <summary>
        /// Gets the data cham cong by thang nam.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_TongHopChamCong> GetDataChamCongByThangNam(int pThang, int pNam,int pIdPhongBan)
        {
            List<TL_TongHopChamCong> listdata=this.Context.TL_TongHopChamCongs.Where(th=>th.ThoiGian.Value.Year==pNam && th.ThoiGian.Value.Month==pThang).ToList<TL_TongHopChamCong>();
            
            List<NV_NhanVien> listNhanVien=this.Context.NV_NhanViens.Where(nv=>nv.IdPhongBan==pIdPhongBan).ToList<NV_NhanVien>();

            var query = from th in listdata
                        join nhanvien in listNhanVien on th.IdNhanVien equals ((NV_NhanVien)nhanvien).Id
                        
                        select new
                        {
                            MaNhanVien=nhanvien.MaNhanVien,
                            HoDem=nhanvien.HoDem,
                            Ten=nhanvien.Ten
                        };
            
            var result = query.ToList().ConvertAll(t => new TL_TongHopChamCong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
            });

            return result.ToList<TL_TongHopChamCong>();

        }
    }
}
