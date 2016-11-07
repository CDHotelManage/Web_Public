using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// hourse_scheme:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hourse_scheme
	{
        public hourse_scheme()
        { }
        #region Model
        private int _id;
        private int? _hs_room;
        private string _hs_name;
        private decimal? _hs_psmoney;
        private string _hs_discount;
        private int? _hs_type;
        private int? _hs_jgtype;
        private int? _hs_source_id;
        private bool _hs_isall;
        private DateTime? _hs_strat;
        private DateTime? _hs_end;
        private decimal? _hs_zdr;
        private string _hs_reamrk;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? hs_room
        {
            set { _hs_room = value; }
            get { return _hs_room; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_name
        {
            set { _hs_name = value; }
            get { return _hs_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? hs_psmoney
        {
            set { _hs_psmoney = value; }
            get { return _hs_psmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_Discount
        {
            set { _hs_discount = value; }
            get { return _hs_discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? hs_type
        {
            set { _hs_type = value; }
            get { return _hs_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? hs_jgtype
        {
            set { _hs_jgtype = value; }
            get { return _hs_jgtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? hs_source_id
        {
            set { _hs_source_id = value; }
            get { return _hs_source_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Hs_isAll
        {
            set { _hs_isall = value; }
            get { return _hs_isall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Hs_Strat
        {
            set { _hs_strat = value; }
            get { return _hs_strat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Hs_End
        {
            set { _hs_end = value; }
            get { return _hs_end; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Hs_zdr
        {
            set { _hs_zdr = value; }
            get { return _hs_zdr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Hs_Reamrk
        {
            set { _hs_reamrk = value; }
            get { return _hs_reamrk; }
        }
        #endregion Model

	}
}

