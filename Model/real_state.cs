using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// real_state:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class real_state
	{
		public real_state()
		{}
		#region Model
		private int _id;
		private string _tr_number;
		private string _tr_name;
		private string _tr_remaker;
		private string _back1;
		private string _back2;
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
		public string tr_number
		{
			set{ _tr_number=value;}
			get{return _tr_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tr_name
		{
			set{ _tr_name=value;}
			get{return _tr_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tr_remaker
		{
			set{ _tr_remaker=value;}
			get{return _tr_remaker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string back1
		{
			set{ _back1=value;}
			get{return _back1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string back2
		{
			set{ _back2=value;}
			get{return _back2;}
		}
		#endregion Model

	}
}

