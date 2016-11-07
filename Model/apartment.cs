using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// apartment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class apartment
    {
        public apartment()
        { }
        #region Model
        private int _occ_id;
        private string _occ_no;
        private string _order_id;
        private string _occ_name;
        private string _occ_with;
        private int? _real_type_id;
        private string _room_number;
        private int? _real_scheme_id;
        private int? _source_id;
        private string _mem_cardno;
        private int? _real_mode_id;
        private decimal? _real_price;
        private DateTime? _occ_time;
        private int? _pre_live_day;
        private int? _stay_day;
        private decimal? _stay_deposit;
        private DateTime? _depar_time;
        private DateTime? _pha_sched;
        private int? _card_id;
        private string _card_no;
        private string _brithday;
        private string _sex;
        private string _family_name;
        private string _address;
        private int? _meth_pay_id;
        private int? _state_id;
        private decimal? _deposit;
        private decimal? _pay_money;
        private decimal? _amount_money;
        private decimal? _amount_rece;
        private decimal? _return_money;
        private int? _sale_id;
        private string _remark;
        private string _sort;
        private string _lordroomid;
        private int? _continuelive;
        private string _phonenum;
        private int? _tuifaid;
        private string _userid;
        private string _header_img;
        /// <summary>
        /// 
        /// </summary>
        public int occ_id
        {
            set { _occ_id = value; }
            get { return _occ_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string occ_no
        {
            set { _occ_no = value; }
            get { return _occ_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string occ_name
        {
            set { _occ_name = value; }
            get { return _occ_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string occ_with
        {
            set { _occ_with = value; }
            get { return _occ_with; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? real_type_id
        {
            set { _real_type_id = value; }
            get { return _real_type_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string room_number
        {
            set { _room_number = value; }
            get { return _room_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? real_scheme_id
        {
            set { _real_scheme_id = value; }
            get { return _real_scheme_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? source_id
        {
            set { _source_id = value; }
            get { return _source_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mem_cardno
        {
            set { _mem_cardno = value; }
            get { return _mem_cardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? real_mode_id
        {
            set { _real_mode_id = value; }
            get { return _real_mode_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? real_price
        {
            set { _real_price = value; }
            get { return _real_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? occ_time
        {
            set { _occ_time = value; }
            get { return _occ_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pre_live_day
        {
            set { _pre_live_day = value; }
            get { return _pre_live_day; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? stay_day
        {
            set { _stay_day = value; }
            get { return _stay_day; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? stay_deposit
        {
            set { _stay_deposit = value; }
            get { return _stay_deposit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? depar_time
        {
            set { _depar_time = value; }
            get { return _depar_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? pha_sched
        {
            set { _pha_sched = value; }
            get { return _pha_sched; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? card_id
        {
            set { _card_id = value; }
            get { return _card_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string card_no
        {
            set { _card_no = value; }
            get { return _card_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brithday
        {
            set { _brithday = value; }
            get { return _brithday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string family_name
        {
            set { _family_name = value; }
            get { return _family_name; }
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
        public int? meth_pay_id
        {
            set { _meth_pay_id = value; }
            get { return _meth_pay_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? state_id
        {
            set { _state_id = value; }
            get { return _state_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? deposit
        {
            set { _deposit = value; }
            get { return _deposit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? pay_money
        {
            set { _pay_money = value; }
            get { return _pay_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? amount_money
        {
            set { _amount_money = value; }
            get { return _amount_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? amount_rece
        {
            set { _amount_rece = value; }
            get { return _amount_rece; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? return_money
        {
            set { _return_money = value; }
            get { return _return_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sale_id
        {
            set { _sale_id = value; }
            get { return _sale_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lordRoomid
        {
            set { _lordroomid = value; }
            get { return _lordroomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? continuelive
        {
            set { _continuelive = value; }
            get { return _continuelive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phonenum
        {
            set { _phonenum = value; }
            get { return _phonenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tuifaId
        {
            set { _tuifaid = value; }
            get { return _tuifaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string header_img
        {
            set { _header_img = value; }
            get { return _header_img; }
        }
        #endregion Model

    }
}

