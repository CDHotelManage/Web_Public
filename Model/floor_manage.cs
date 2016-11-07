using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// floor_manage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class floor_manage
	{
		public floor_manage()
		{}
		#region Model
		private int _floor_id;
		private string _floor_number;
		private string _floor_name;
		private string _floor_sorting;
		private string _floor_remaker;
		private string _floor_shoping;
		/// <summary>
		/// 
		/// </summary>
		public int floor_id
		{
			set{ _floor_id=value;}
			get{return _floor_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string floor_number
		{
			set{ _floor_number=value;}
			get{return _floor_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string floor_name
		{
			set{ _floor_name=value;}
			get{return _floor_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string floor_sorting
		{
			set{ _floor_sorting=value;}
			get{return _floor_sorting;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string floor_remaker
		{
			set{ _floor_remaker=value;}
			get{return _floor_remaker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string floor_shoping
		{
			set{ _floor_shoping=value;}
			get{return _floor_shoping;}
		}
		#endregion Model

	}
}

