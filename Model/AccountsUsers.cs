using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    [Serializable]
    public class AccountsUsers
    {
        public AccountsUsers()
        { }
        #region Model
        private string _userid;
        private string _username;
        private string _password;
        private string _truename;
        private string _sex;
        private string _phone;
        private string _email;
        private int? _employeeid;
        private string _departmentid;
        private bool _activity;
        private string _usertype;
        private int? _style;
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentID
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Activity
        {
            set { _activity = value; }
            get { return _activity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Style
        {
            set { _style = value; }
            get { return _style; }
        }
        #endregion Model
    }
}
