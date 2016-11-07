using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Menu
	{
		public Menu()
		{}
		#region Model
		private int _menu_id;
		private string _title;
		private int? _parent_id;
		private string _url;
		private string _imgurl;
		private int? _sortid;
		private bool _isable;
		/// <summary>
		///菜单ID
		/// </summary>
		public int menu_id
		{
			set{ _menu_id=value;}
			get{return _menu_id;}
		}
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 父类ID
		/// </summary>
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 路径
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 图标
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
		/// 是否启用
		/// </summary>
		public bool isable
		{
			set{ _isable=value;}
			get{return _isable;}
		}
		#endregion Model

	}
}

