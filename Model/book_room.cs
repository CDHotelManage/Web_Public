using System;
using System.Collections.Generic;
namespace CdHotelManage.Model
{
	/// <summary>
	/// book_room:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class book_room
	{
		public book_room()
		{}
		#region Model
		private int _book_id;
		private string _book_no;
		private string _book_name;
		private string _tele_no;
		private string _onli_no;
		private string _guar_way;
		private string _mem_cardno;
		private DateTime? _time_to;
		private DateTime? _time_from;
		private DateTime? _real_time;
		private int? _source_id;
		private int? _meth_pay_id;
		private decimal? _deposit;
		private int? _real_type_id;
		private int? _real_scheme_id;
		private decimal? _real_price;
		private int? _state_id;
		private int? _real_num;
		private string _remark;
        private string _room_number;
        private decimal? _back_deposit;
        private string _userid;

        /// <summary>
        /// 
        /// </summary>
        public string Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        private List<Model.Book_Rdetail> listBr;

        public List<Model.Book_Rdetail> ListBr
        {
            get { return listBr; }
            set { listBr = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		public int book_id
		{
			set{ _book_id=value;}
			get{return _book_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string book_no
		{
			set{ _book_no=value;}
			get{return _book_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string book_Name
		{
			set{ _book_name=value;}
			get{return _book_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tele_no
		{
			set{ _tele_no=value;}
			get{return _tele_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string onli_no
		{
			set{ _onli_no=value;}
			get{return _onli_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string guar_way
		{
			set{ _guar_way=value;}
			get{return _guar_way;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mem_cardno
		{
			set{ _mem_cardno=value;}
			get{return _mem_cardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time_to
		{
			set{ _time_to=value;}
			get{return _time_to;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time_from
		{
			set{ _time_from=value;}
			get{return _time_from;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? real_time
		{
			set{ _real_time=value;}
			get{return _real_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? source_id
		{
			set{ _source_id=value;}
			get{return _source_id;}
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
		public decimal? deposit
		{
			set{ _deposit=value;}
			get{return _deposit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? real_type_id
		{
			set{ _real_type_id=value;}
			get{return _real_type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? real_scheme_id
		{
			set{ _real_scheme_id=value;}
			get{return _real_scheme_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? real_price
		{
			set{ _real_price=value;}
			get{return _real_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state_id
		{
			set{ _state_id=value;}
			get{return _state_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? real_num
		{
			set{ _real_num=value;}
			get{return _real_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        public string room_number
        {
            set { _room_number = value; }
            get { return _room_number; }
        }
		#endregion Model
        public string Accounts { get; set; }
        public int? CpID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? back_deposit
        {
            set { _back_deposit = value; }
            get { return _back_deposit; }
        }

     

	}
}

