using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class Contacts
    {
        public Contacts()
        { }
        #region Model
        private int _id;
        private string _accounts;
        private string _cname;
        private bool _sex;
        private DateTime? _bearthday;
        private string _edituser;
        private DateTime? _adddatetime;
        private int? _appellation;
        private int? _department;
        private string _officphone;
        private string _phone;
        private string _address;
        private string _zipcode;
        private string _mail;
        private string _familyphone;
        private string _likes;
        private string _remark;

        public int Post { get; set; }
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
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Bearthday
        {
            set { _bearthday = value; }
            get { return _bearthday; }
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
        public DateTime? addDatetime
        {
            set { _adddatetime = value; }
            get { return _adddatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Appellation
        {
            set { _appellation = value; }
            get { return _appellation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string officPhone
        {
            set { _officphone = value; }
            get { return _officphone; }
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
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zipcode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mail
        {
            set { _mail = value; }
            get { return _mail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string familyPhone
        {
            set { _familyphone = value; }
            get { return _familyphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Likes
        {
            set { _likes = value; }
            get { return _likes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}
