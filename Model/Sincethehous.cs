using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// Sincethehous:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sincethehous
    {
        public Sincethehous()
        { }
        #region Model
        private int _id;
        private string _hs_numberno;
        private string _hs_room;
        private string _hs_yuany;
        private DateTime? _hs_date;
        private DateTime? _hs_ksdate;
        private string _hs_yldate;
        private string _hs_documentno;
        private int? _hs_type;
        private string _hs_people;
        private string _hs_result;
        private string _hs_remaker;
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
        public string hs_Numberno
        {
            set { _hs_numberno = value; }
            get { return _hs_numberno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_room
        {
            set { _hs_room = value; }
            get { return _hs_room; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_yuany
        {
            set { _hs_yuany = value; }
            get { return _hs_yuany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? hs_date
        {
            set { _hs_date = value; }
            get { return _hs_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? hs_ksDate
        {
            set { _hs_ksdate = value; }
            get { return _hs_ksdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_ylDate
        {
            set { _hs_yldate = value; }
            get { return _hs_yldate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_Documentno
        {
            set { _hs_documentno = value; }
            get { return _hs_documentno; }
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
        public string hs_people
        {
            set { _hs_people = value; }
            get { return _hs_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_Result
        {
            set { _hs_result = value; }
            get { return _hs_result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hs_remaker
        {
            set { _hs_remaker = value; }
            get { return _hs_remaker; }
        }
        #endregion Model

    }
}

