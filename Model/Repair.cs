using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// Repair:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Repair
	{
		public Repair()
		{}
		#region Model
		private int _repair_id;
		private string _repair_name;
		private DateTime? _repair_time;
		private string _repair_man;
		private int? _repair_num;
		private string _repair_remark;
		/// <summary>
		/// 
		/// </summary>
		public int repair_id
		{
			set{ _repair_id=value;}
			get{return _repair_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string repair_name
		{
			set{ _repair_name=value;}
			get{return _repair_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? repair_time
		{
			set{ _repair_time=value;}
			get{return _repair_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string repair_man
		{
			set{ _repair_man=value;}
			get{return _repair_man;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? repair_num
		{
			set{ _repair_num=value;}
			get{return _repair_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string repair_remark
		{
			set{ _repair_remark=value;}
			get{return _repair_remark;}
		}
		#endregion Model

	}
}

