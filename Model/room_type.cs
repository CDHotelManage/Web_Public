using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// room_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class room_type
	{
		public room_type()
		{}
		#region Model
		private int _id;
		private string _room_number;
		private string _room_name;
		private string _room_hour;
		private decimal? _room_listedmoney;
		private decimal? _room_zmmoney;
		private string _room_hourmation;
		private string _room_reamker;
        private string _room_image;
        private decimal? _room_Moth_price;

        public decimal? Room_Moth_price
        {
            get { return _room_Moth_price; }
            set { _room_Moth_price = value; }
        }

        public int Room_Bfb { get; set; }
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
		public string room_number
		{
			set{ _room_number=value;}
			get{return _room_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string room_name
		{
			set{ _room_name=value;}
			get{return _room_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string room_hour
		{
			set{ _room_hour=value;}
			get{return _room_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? room_listedmoney
		{
			set{ _room_listedmoney=value;}
			get{return _room_listedmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? room_zmmoney
		{
			set{ _room_zmmoney=value;}
			get{return _room_zmmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string room_hourmation
		{
			set{ _room_hourmation=value;}
			get{return _room_hourmation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string room_reamker
		{
			set{ _room_reamker=value;}
			get{return _room_reamker;}
		}

        public string room_image
        {
            set { _room_image = value; }
            get { return _room_image; }
        }
		#endregion Model


        public decimal? Room_ealry_price { get; set; }

	}
}

