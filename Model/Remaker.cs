using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// Remaker:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Remaker
    {
        public Remaker()
        { }
        #region Model
        private int _id;
        private string _remaker;
        private int? _type;
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
        public string remaker
        {
            set { _remaker = value; }
            get { return _remaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model

    }
}

