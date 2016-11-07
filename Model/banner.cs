using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// 横幅
	/// </summary>
	[Serializable]
	public partial class banner
	{
		public banner()
		{}
		#region Model
		private string _banner_id;
		private string _title;
		private string _imgurl;
		private int? _sortid;
		private DateTime? _pubdate;
		/// <summary>
		/// 横幅ID
		/// </summary>
		public string banner_id
		{
			set{ _banner_id=value;}
			get{return _banner_id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
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
		/// 发布时间
		/// </summary>
		public DateTime? pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
		}
		#endregion Model

	}
}

