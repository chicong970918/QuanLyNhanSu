using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DataAccess.Common
{
    /// <summary>
    /// 
    /// </summary>
    public struct UserInfo
    {
        private int _userID;
        private string _userName;
        private int? _idNhanVien;
        private bool? _IsPhongNhanSu;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> struct.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="idKhoa">The id khoa.</param>
        public UserInfo(int userID, string userName, int? idNhanVien,bool? pIsPhongNS)
        {
            _userID = userID;
            _userName = userName;
            _idNhanVien = idNhanVien;
            _IsPhongNhanSu = pIsPhongNS;
        }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        /// <value>The user ID.</value>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// Gets or sets the id NhanVien.
        /// </summary>
        /// <value>The id khoa.</value>
        public int? IdNhanVien
        {
            get { return _idNhanVien; }
            set { _idNhanVien = value; }
        }
        /// <summary>
        /// Gets or sets the is phong nhan su.
        /// </summary>
        /// <value>The is phong nhan su.</value>
        public bool? IsPhongNhanSu
        {
            get { return _IsPhongNhanSu; }
            set { _IsPhongNhanSu = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// Wrong username or password
        /// </summary>
        Invalid,
        /// <summary>
        /// User had been disabled
        /// </summary>
        Disabled,
        /// <summary>
        /// Loging success
        /// </summary>
        Success
    }
}
