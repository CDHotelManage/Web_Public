using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// real_mode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class real_mode
	{
		public real_mode()
		{}
		#region Model
		private int _real_mode_id;
		private string _real_mode_name;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int real_mode_id
		{
			set{ _real_mode_id=value;}
			get{return _real_mode_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string real_mode_name
		{
			set{ _real_mode_name=value;}
			get{return _real_mode_name;}
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

