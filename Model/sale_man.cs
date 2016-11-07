using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// sale_man:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sale_man
	{
		public sale_man()
		{}
		#region Model
		private int _sale_man_id;
		private string _sale_man_name;
		private decimal? _sale_man_money;
		/// <summary>
		/// 
		/// </summary>
		public int sale_man_id
		{
			set{ _sale_man_id=value;}
			get{return _sale_man_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sale_man_name
		{
			set{ _sale_man_name=value;}
			get{return _sale_man_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sale_man_money
		{
			set{ _sale_man_money=value;}
			get{return _sale_man_money;}
		}
		#endregion Model

	}
}

