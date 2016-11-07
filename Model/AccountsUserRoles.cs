using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    [Serializable]
    public class AccountsUserRoles
    {
        public AccountsUserRoles()
        { }
        #region Model
        private string _userid;
        private int _roleid;
        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model
    }
}
