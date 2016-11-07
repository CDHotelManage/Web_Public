using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// Entry:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Entry
	{
		public Entry()
		{}
		#region Model
		private int _id;
		private string _entry_name;
		private int? _entry_num;
		private DateTime? _entry_time;
		private string _entry_unit;
		private decimal? _entry_price;
		private string _entry_room;
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
		public string entry_name
		{
			set{ _entry_name=value;}
			get{return _entry_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? entry_num
		{
			set{ _entry_num=value;}
			get{return _entry_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? entry_time
		{
			set{ _entry_time=value;}
			get{return _entry_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entry_unit
		{
			set{ _entry_unit=value;}
			get{return _entry_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? entry_price
		{
			set{ _entry_price=value;}
			get{return _entry_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entry_room
		{
			set{ _entry_room=value;}
			get{return _entry_room;}
		}
		#endregion Model

	}
}

