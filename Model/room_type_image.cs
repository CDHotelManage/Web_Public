using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// 房型图片
	/// </summary>
	[Serializable]
	public partial class room_type_image
	{
		public room_type_image()
		{}
		#region Model
		private string _imgid;
		private int? _typeid;
		private string _imgurl;
		private int? _sortid;
		private DateTime? _pubdate;
		/// <summary>
		/// 图片ID
		/// </summary>
		public string imgid
		{
			set{ _imgid=value;}
			get{return _imgid;}
		}
		/// <summary>
		/// 房型ID
		/// </summary>
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string imgurl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? sortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 发布日期
		/// </summary>
		public DateTime? pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
		}
		#endregion Model

	}
}

