using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// goods_account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class goods_account
	{
		public goods_account()
		{}
		#region Model
		private int _id;
		private string _ga_name;
		private string _ga_number;
		private string _ga_roomnumber;
		private string _ga_unit;
		private int? _ga_num;
		private decimal? _ga_price;
		private int? _ga_zffs_id;
		private DateTime? _ga_date;
		private string _ga_people;
		private int? _ga_type;
		private decimal? _ga_sum_price;
		private string _ga_remker;
        private string _ga_occuid;
        private string _ga_sfacount;
        public int ga_isjz { get; set; }
        public int ga_isys { get; set; }
        public int ga_jsfs { get; set; }
        public string Ga_Account { get; set; }

        private Model.meth_pay meth_pay_model;

        public Model.meth_pay Meth_pay_model
        {
            get { return meth_pay_model; }
            set { meth_pay_model = value; }
        }
        private string _ga_goodNo;

        public string Ga_goodNo
        {
            get { return _ga_goodNo; }
            set { _ga_goodNo = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ga_name
		{
			set{ _ga_name=value;}
			get{return _ga_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ga_number
		{
			set{ _ga_number=value;}
			get{return _ga_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ga_roomNumber
		{
			set{ _ga_roomnumber=value;}
			get{return _ga_roomnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ga_unit
		{
			set{ _ga_unit=value;}
			get{return _ga_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ga_num
		{
			set{ _ga_num=value;}
			get{return _ga_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ga_price
		{
			set{ _ga_price=value;}
			get{return _ga_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ga_zffs_id
		{
			set{ _ga_zffs_id=value;}
			get{return _ga_zffs_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ga_date
		{
			set{ _ga_date=value;}
			get{return _ga_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ga_people
		{
			set{ _ga_people=value;}
			get{return _ga_people;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ga_Type
		{
			set{ _ga_type=value;}
			get{return _ga_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ga_sum_price
		{
			set{ _ga_sum_price=value;}
			get{return _ga_sum_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ga_remker
		{
			set{ _ga_remker=value;}
			get{return _ga_remker;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string ga_occuid
        {
            set { _ga_occuid = value; }
            get { return _ga_occuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ga_sfacount
        {
            set { _ga_sfacount = value; }
            get { return _ga_sfacount; }
        }
		#endregion Model

	}
}

