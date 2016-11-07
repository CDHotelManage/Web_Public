using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// 角色_菜单
	/// </summary>
	[Serializable]
	public partial class RoleMenu
	{
		public RoleMenu()
		{}
		#region Model
		private int? _roleid;
		private int? _menu_id;
		private int? _menu_pid;
		/// <summary>
		/// 角色ID
		/// </summary>
		public int? RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 菜单ID
		/// </summary>
		public int? Menu_id
		{
			set{ _menu_id=value;}
			get{return _menu_id;}
		}
		/// <summary>
		/// 菜单父类ID
		/// </summary>
		public int? Menu_pid
		{
			set{ _menu_pid=value;}
			get{return _menu_pid;}
		}
		#endregion Model

	}
}

