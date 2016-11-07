using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// room_number:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class room_number
	{
		public room_number()
		{}
		#region Model
		private int _id;
		private string _rn_floor;
		private string _rn_roomnum;
		private int? _rn_state;
		private string _rn_room;
		private int? _rn_type;
		private decimal? _rn_price;
		private string _rn_remaker;
        private string _rn_flloeld;
        private string _room_sort;
        public int Rn_Tobe { get; set; }
        public string Room_sort
        {
            get { return _room_sort; }
            set { _room_sort = value; }
        }
        public string Rn_flloeld
        {
            get { return _rn_flloeld; }
            set { _rn_flloeld = value; }
        }
        private string _room_suod;

        public string Room_suod
        {
            get { return _room_suod; }
            set { _room_suod = value; }
        }

        public string Rn_suo { get; set; }

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
		public string Rn_floor
		{
			set{ _rn_floor=value;}
			get{return _rn_floor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Rn_roomNum
		{
			set{ _rn_roomnum=value;}
			get{return _rn_roomnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Rn_state
		{
			set{ _rn_state=value;}
			get{return _rn_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Rn_room
		{
			set{ _rn_room=value;}
			get{return _rn_room;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Rn_Type
		{
			set{ _rn_type=value;}
			get{return _rn_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Rn_price
		{
			set{ _rn_price=value;}
			get{return _rn_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Rn_remaker
		{
			set{ _rn_remaker=value;}
			get{return _rn_remaker;}
		}
		#endregion Model

	}
}

