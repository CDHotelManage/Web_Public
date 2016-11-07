using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// 会员
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private string _userid;
		private string _username;
		private string _passwords;
		private int? _user_type;
		private DateTime? _pubdate;

        public Model.UserInfo UserInfoModel { get; set; }

        public Model.userType UserTypeModel { get; set; }
		/// <summary>
		/// 用户ID
		/// </summary>
		public string userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string passwords
		{
			set{ _passwords=value;}
			get{return _passwords;}
		}
		/// <summary>
		/// 用户类型
		/// </summary>
		public int? user_type
		{
			set{ _user_type=value;}
			get{return _user_type;}
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

