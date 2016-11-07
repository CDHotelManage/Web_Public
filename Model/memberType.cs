using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    [Serializable]
    public class memberType
    {

        public memberType()
        { }
        #region Model
        private int _mtid;
        private string _typename;
        private int? _typeprice;
        private bool _limit;
        private int? _limitvalue;
        private bool _integrais;
        private bool _isconsump;
        private bool _isfz;
        private bool _isxf;
        private int? _xfprice;
        private int? _xfconsump;
        private bool _islive;
        private int? _livenum;
        private int? _liveconsump;
        private bool _istx;
        private bool _isdeaflut;
        private bool _isupgrade;
        private int? _consumpsum;
        private int? _uplive;
        private bool _isdeduction;
        private bool _isout;
        private int? _outhour;
        private int? _outzd;
        private int? _firstprice;

        private int? staPrice;
        public int? MachJf { get; set; }
        public DateTime? XqTime { get; set; }

        public int? StaPrice
        {
            get { return staPrice; }
            set { staPrice = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MtID
        {
            set { _mtid = value; }
            get { return _mtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? typePrice
        {
            set { _typeprice = value; }
            get { return _typeprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Limit
        {
            set { _limit = value; }
            get { return _limit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LimitValue
        {
            set { _limitvalue = value; }
            get { return _limitvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IntegraIs
        {
            set { _integrais = value; }
            get { return _integrais; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsConsump
        {
            set { _isconsump = value; }
            get { return _isconsump; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFz
        {
            set { _isfz = value; }
            get { return _isfz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsXf
        {
            set { _isxf = value; }
            get { return _isxf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XfPrice
        {
            set { _xfprice = value; }
            get { return _xfprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? XfConsump
        {
            set { _xfconsump = value; }
            get { return _xfconsump; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLive
        {
            set { _islive = value; }
            get { return _islive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LiveNum
        {
            set { _livenum = value; }
            get { return _livenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LiveConsump
        {
            set { _liveconsump = value; }
            get { return _liveconsump; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTx
        {
            set { _istx = value; }
            get { return _istx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeaflut
        {
            set { _isdeaflut = value; }
            get { return _isdeaflut; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpgrade
        {
            set { _isupgrade = value; }
            get { return _isupgrade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ConsumpSum
        {
            set { _consumpsum = value; }
            get { return _consumpsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UpLive
        {
            set { _uplive = value; }
            get { return _uplive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeduction
        {
            set { _isdeduction = value; }
            get { return _isdeduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Isout
        {
            set { _isout = value; }
            get { return _isout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OutHour
        {
            set { _outhour = value; }
            get { return _outhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OutZD
        {
            set { _outzd = value; }
            get { return _outzd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FirstPrice
        {
            set { _firstprice = value; }
            get { return _firstprice; }
        }
        #endregion Model
    }
}
