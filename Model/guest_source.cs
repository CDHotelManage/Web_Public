using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// guest_source:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class guest_source
	{
		public guest_source()
		{}
		#region Model
		private int _id;
		private string _gs_name;
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
		public string gs_name
		{
			set{ _gs_name=value;}
			get{return _gs_name;}
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

