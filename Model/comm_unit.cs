using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// comm_unit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class comm_unit
	{
		public comm_unit()
		{}
		#region Model
		private int _id;
		private string _unit_name;
		private string _remark;
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
		public string unit_name
		{
			set{ _unit_name=value;}
			get{return _unit_name;}
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

