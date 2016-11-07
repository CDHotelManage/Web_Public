using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class customer
    {
        public customer()
        { }
        #region Model
        private int _id;
        private string _accounts;
        private string _cname;
        private int? _systype;
        private int? _custype;
        private string _cusdesy;
        private string _cusnumber;
        private string _contacts;
        private string _cphone;
        private int? _cstate;
        private int? _sales;
        private bool _prosceniumiss;
        private bool _ishire;
        private string _area;
        private string _city;
        private string _contsrr;
        private string _shiji;
        private string _email;
        private string _ybnum;
        private string _address;
        private string _companyphone;
        private string _fax;
        private string _homepage;
        private int? _csource;
        private int? _cindustry;
        private bool _ischalk;
        private int? _limit;
        private string _remark;
        private DateTime? _adddate;
        private string _edituser;
        private int? _verifyuser;
        private bool _isverify;
        private string _hotel;
        private string _details;
        private int? _occnum;
        private int? _noshow;
        private int? _xqbook;
        private int? _pming;

        public bool IsXz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string accounts
        {
            set { _accounts = value; }
            get { return _accounts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sysType
        {
            set { _systype = value; }
            get { return _systype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cusType
        {
            set { _custype = value; }
            get { return _custype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cusDesy
        {
            set { _cusdesy = value; }
            get { return _cusdesy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cusNumber
        {
            set { _cusnumber = value; }
            get { return _cusnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string contacts
        {
            set { _contacts = value; }
            get { return _contacts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPhone
        {
            set { _cphone = value; }
            get { return _cphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Cstate
        {
            set { _cstate = value; }
            get { return _cstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sales
        {
            set { _sales = value; }
            get { return _sales; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool prosceniumIss
        {
            set { _prosceniumiss = value; }
            get { return _prosceniumiss; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Ishire
        {
            set { _ishire = value; }
            get { return _ishire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Contsrr
        {
            set { _contsrr = value; }
            get { return _contsrr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shiji
        {
            set { _shiji = value; }
            get { return _shiji; }
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
        public string ybNum
        {
            set { _ybnum = value; }
            get { return _ybnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companyPhone
        {
            set { _companyphone = value; }
            get { return _companyphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string homepage
        {
            set { _homepage = value; }
            get { return _homepage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Csource
        {
            set { _csource = value; }
            get { return _csource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cindustry
        {
            set { _cindustry = value; }
            get { return _cindustry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Ischalk
        {
            set { _ischalk = value; }
            get { return _ischalk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? limit
        {
            set { _limit = value; }
            get { return _limit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string editUser
        {
            set { _edituser = value; }
            get { return _edituser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? verifyUser
        {
            set { _verifyuser = value; }
            get { return _verifyuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isVerify
        {
            set { _isverify = value; }
            get { return _isverify; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Hotel
        {
            set { _hotel = value; }
            get { return _hotel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Details
        {
            set { _details = value; }
            get { return _details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? occNum
        {
            set { _occnum = value; }
            get { return _occnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? NoShow
        {
            set { _noshow = value; }
            get { return _noshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? xqBook
        {
            set { _xqbook = value; }
            get { return _xqbook; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Pming
        {
            set { _pming = value; }
            get { return _pming; }
        }
        #endregion Model
    }
}
