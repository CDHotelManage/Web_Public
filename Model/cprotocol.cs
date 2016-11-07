using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class cprotocol
    {
        public cprotocol()
        { }
        #region Model
        private int _id;
        private string _accounts;
        private string _ptheme;
        private int? _ptype;
        private string _pnumber;
        private bool _ishire;
        private DateTime? _term;
        private DateTime? _period;
        private int? _breakfast;
        private int? _commission;
        private bool _dayhire;
        private bool _prohire;
        private string _signatory;
        private string _companysignatory;
        private string _roomnumber;
        private bool _isdiscount;
        private decimal? _discount;
        private string _remark;
        private bool _isverify;
        private string _edituser;
        private int? _verifyuser;
        private string _details;
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
        public string Accounts
        {
            set { _accounts = value; }
            get { return _accounts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ptheme
        {
            set { _ptheme = value; }
            get { return _ptheme; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pType
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PNumber
        {
            set { _pnumber = value; }
            get { return _pnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ishire
        {
            set { _ishire = value; }
            get { return _ishire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? term
        {
            set { _term = value; }
            get { return _term; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? period
        {
            set { _period = value; }
            get { return _period; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? breakfast
        {
            set { _breakfast = value; }
            get { return _breakfast; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Commission
        {
            set { _commission = value; }
            get { return _commission; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Dayhire
        {
            set { _dayhire = value; }
            get { return _dayhire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool prohire
        {
            set { _prohire = value; }
            get { return _prohire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string signatory
        {
            set { _signatory = value; }
            get { return _signatory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companysignatory
        {
            set { _companysignatory = value; }
            get { return _companysignatory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string roomNumber
        {
            set { _roomnumber = value; }
            get { return _roomnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Isdiscount
        {
            set { _isdiscount = value; }
            get { return _isdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? discount
        {
            set { _discount = value; }
            get { return _discount; }
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
        public bool isVerify
        {
            set { _isverify = value; }
            get { return _isverify; }
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
        public string Details
        {
            set { _details = value; }
            get { return _details; }
        }
        #endregion Model

    }
}
