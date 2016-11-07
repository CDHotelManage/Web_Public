using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// room_feature:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class room_feature
	{
		public room_feature()
		{}
		#region Model
		private int _room_feature_id;
		private string _room_feature_name;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int room_feature_id
		{
			set{ _room_feature_id=value;}
			get{return _room_feature_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string room_feature_name
		{
			set{ _room_feature_name=value;}
			get{return _room_feature_name;}
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

