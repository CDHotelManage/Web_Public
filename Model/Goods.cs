using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// Goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Goods
	{
		public Goods()
		{}
		#region Model
		private int _id;
		private string _goods_number;
		private string _goods_name;
		private decimal? _goods_price;
		private string _goods_unit;
		private string _goods_state;
		private string _goods_spell;
		private int? _goods_iftype;
        private int? _goods_categories;

        public int? Goods_jf { get; set; }

        public int? Goods_categories
        {
            get { return _goods_categories; }
            set { _goods_categories = value; }
        }
        private string _goods_Remaker;

        public string Goods_Remaker
        {
            get { return _goods_Remaker; }
            set { _goods_Remaker = value; }
        }
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
		public string Goods_number
		{
			set{ _goods_number=value;}
			get{return _goods_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Goods_name
		{
			set{ _goods_name=value;}
			get{return _goods_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Goods_price
		{
			set{ _goods_price=value;}
			get{return _goods_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Goods_unit
		{
			set{ _goods_unit=value;}
			get{return _goods_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Goods_state
		{
			set{ _goods_state=value;}
			get{return _goods_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Goods_spell
		{
			set{ _goods_spell=value;}
			get{return _goods_spell;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Goods_ifType
		{
			set{ _goods_iftype=value;}
			get{return _goods_iftype;}
		}
		#endregion Model

	}
}

