using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// modes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class modes
    {
        public modes()
        { }
        #region Model
        private int _id;
        private string _moshi_name;
        private string _reanker;
        private int? _sort;
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
        public string moshi_name
        {
            set { _moshi_name = value; }
            get { return _moshi_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reanker
        {
            set { _reanker = value; }
            get { return _reanker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model

    }
}

