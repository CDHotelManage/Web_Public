using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class UserInfo
    {
        public UserInfo()
        { }
        #region Model
        private int? _id;
        private string _userid;
        private string _cardid;
        private bool _sex;
        private int? _cardtypeid;
        private string _cardvalue;
        private int? _typeid;
        private string _xiaoshou;
        private string _phone;
        private DateTime? _bairthday;
        private string _xihao;
        private string _address;
        private string _meark;
        private int? _manageid;
        private string _truename;
        /// <summary>
        /// 
        /// </summary>
        public string Truename
        {
            get { return _truename; }
            set { _truename = value; }
        }

        public Model.Users UserModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cardTypeID
        {
            set { _cardtypeid = value; }
            get { return _cardtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cardValue
        {
            set { _cardvalue = value; }
            get { return _cardvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? typeid
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xiaoshou
        {
            set { _xiaoshou = value; }
            get { return _xiaoshou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? bairthday
        {
            set { _bairthday = value; }
            get { return _bairthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xihao
        {
            set { _xihao = value; }
            get { return _xihao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string meark
        {
            set { _meark = value; }
            get { return _meark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? manageID
        {
            set { _manageid = value; }
            get { return _manageid; }
        }
        #endregion Model

    }
}
