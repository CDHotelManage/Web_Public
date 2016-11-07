using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// cost_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class cost_type
	{
		public cost_type()
		{}
		#region Model
		private int _id;
		private string _ct_number;
		private string _ct_name;
		private int? _ct_iftype;
		private string _ct_remark;
		private decimal? _ct_money;
		private int? _ct_categories;
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
		public string ct_number
		{
			set{ _ct_number=value;}
			get{return _ct_number;}
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
		public int? ct_iftype
		{
			set{ _ct_iftype=value;}
			get{return _ct_iftype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ct_remark
		{
			set{ _ct_remark=value;}
			get{return _ct_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ct_money
		{
			set{ _ct_money=value;}
			get{return _ct_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ct_categories
		{
			set{ _ct_categories=value;}
			get{return _ct_categories;}
		}
		#endregion Model

	}
}

