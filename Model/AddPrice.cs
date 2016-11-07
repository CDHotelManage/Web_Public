using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// AddPrice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AddPrice
    {
        public AddPrice()
        { }
        #region Model
        private int _mtid;
        private int? _addpice;
        private int? _zspice;
        private int? _zsjf;
        private bool _isok;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int MtID
        {
            set { _mtid = value; }
            get { return _mtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AddPice
        {
            set { _addpice = value; }
            get { return _addpice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ZsPice
        {
            set { _zspice = value; }
            get { return _zspice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ZsJf
        {
            set { _zsjf = value; }
            get { return _zsjf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsOk
        {
            set { _isok = value; }
            get { return _isok; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

