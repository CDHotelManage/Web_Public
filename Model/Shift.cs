using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// Shift:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Shift
	{
		public Shift()
		{}
		#region Model
		private int _shift_id;
		private int? _user_id;
		private int? _goods_account_id;
		private string _shfit_name;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int shift_id
		{
			set{ _shift_id=value;}
			get{return _shift_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? goods_account_id
		{
			set{ _goods_account_id=value;}
			get{return _goods_account_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shfit_name
		{
			set{ _shfit_name=value;}
			get{return _shfit_name;}
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

