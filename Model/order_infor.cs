using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// order_infor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class order_infor
	{
		public order_infor()
		{}
		#region Model
		private int _order_id;
		private string _order_no;
		private string _room_id;
		private int? _occ_id;
		private decimal? _order_money;
		private decimal? _return_money;
		private string _order_state;
		private DateTime? _order_time;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int order_id
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order_no
		{
			set{ _order_no=value;}
			get{return _order_no;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string room_id
		{
			set{ _room_id=value;}
			get{return _room_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? occ_id
		{
			set{ _occ_id=value;}
			get{return _occ_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? order_money
		{
			set{ _order_money=value;}
			get{return _order_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? return_money
		{
			set{ _return_money=value;}
			get{return _return_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order_state
		{
			set{ _order_state=value;}
			get{return _order_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? order_time
		{
			set{ _order_time=value;}
			get{return _order_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

