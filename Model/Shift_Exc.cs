using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// Shift_Exc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Shift_Exc
	{
		public Shift_Exc()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private int? _good_account_id;
		private int? _meth_pay_id;
		private int? _shift_id;
		private string _shift_state;
		private decimal? _shift_money;
		private DateTime? _shift_datetime;
		private string _ga_name;
		private string _ga_number;
		private string _ga_unit;
		private int? _ga_num;
		private decimal? _ga_price;
		private int? _ga_zffs_id;
		private DateTime? _ga_date;
		private int? _ga_type;
		private decimal? _ga_sum_price;
		private string _remark;
        private string _ga_roomNumber;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Good_Account_Id
		{
			set{ _good_account_id=value;}
			get{return _good_account_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? meth_pay_id
		{
			set{ _meth_pay_id=value;}
			get{return _meth_pay_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? shift_id
		{
			set{ _shift_id=value;}
			get{return _shift_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shift_state
		{
			set{ _shift_state=value;}
			get{return _shift_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? shift_money
		{
			set{ _shift_money=value;}
			get{return _shift_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? shift_dateTime
		{
			set{ _shift_datetime=value;}
			get{return _shift_datetime;}
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
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string ga_roomNumber
        {
            set { _ga_roomNumber = value; }
            get { return _ga_roomNumber; }
        }

		#endregion Model

	}
}

