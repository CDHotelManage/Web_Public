using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class Commission
    {
        public Commission()
        { }
        #region Model
        private int _id;
        private string _accounts;
        private string _commdesp;
        private DateTime? _commdate;
        private int? _commsum;
        private bool _isback;
        private string _goodnumber;
        private bool _iseveryday;
        private int? _daycomm;
        private string _commremark;
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
        public string CommDesp
        {
            set { _commdesp = value; }
            get { return _commdesp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CommDate
        {
            set { _commdate = value; }
            get { return _commdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CommSum
        {
            set { _commsum = value; }
            get { return _commsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBack
        {
            set { _isback = value; }
            get { return _isback; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodNumber
        {
            set { _goodnumber = value; }
            get { return _goodnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEveryDay
        {
            set { _iseveryday = value; }
            get { return _iseveryday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DayComm
        {
            set { _daycomm = value; }
            get { return _daycomm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CommRemark
        {
            set { _commremark = value; }
            get { return _commremark; }
        }
        #endregion Model
    }
}
