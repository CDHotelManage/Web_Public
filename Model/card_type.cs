using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// card_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class card_type
	{
		public card_type()
		{}
		#region Model
		private int _id;
		private string _ct_name;
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
		public string ct_name
		{
			set{ _ct_name=value;}
			get{return _ct_name;}
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

