using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// hour_room:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hour_room
	{
		public hour_room()
		{}
		#region Model
		private int _id;
		private int? _hs_room_id;
		private string _hs_name;
		private string _hs_start_long;
		private decimal? _hs_start_price;
		private string _hs_add_time;
		private decimal? _hs_add_price;
		private string _hs_min_time;
		private decimal? _hs_min_price;
		private string _hs_max_time;
		private int? _hs_type_id;
		private int? _hs_jgtype_id;
		private int? _hs_source_id;
        public TimeSpan LostTime { get; set; }

        public int MtID { get; set; }
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
		public int? hs_room_id
		{
			set{ _hs_room_id=value;}
			get{return _hs_room_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hs_name
		{
			set{ _hs_name=value;}
			get{return _hs_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hs_start_long
		{
			set{ _hs_start_long=value;}
			get{return _hs_start_long;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? hs_start_price
		{
			set{ _hs_start_price=value;}
			get{return _hs_start_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hs_add_time
		{
			set{ _hs_add_time=value;}
			get{return _hs_add_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? hs_add_price
		{
			set{ _hs_add_price=value;}
			get{return _hs_add_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hs_min_time
		{
			set{ _hs_min_time=value;}
			get{return _hs_min_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? hs_min_price
		{
			set{ _hs_min_price=value;}
			get{return _hs_min_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hs_max_time
		{
			set{ _hs_max_time=value;}
			get{return _hs_max_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hs_type_id
		{
			set{ _hs_type_id=value;}
			get{return _hs_type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hs_jgtype_id
		{
			set{ _hs_jgtype_id=value;}
			get{return _hs_jgtype_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hs_source_id
		{
			set{ _hs_source_id=value;}
			get{return _hs_source_id;}
		}
		#endregion Model

	}
}

