using System;
namespace CdHotelManage.Model
{
	/// <summary>
	/// meth_pay:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class meth_pay
	{
        public meth_pay()
        { }
        #region Model
        private int _meth_pay_id;
        private string _meth_pay_name;
        private bool _meth_is_ya;
        private bool _meth_is_jie;
        private int? _meth_sort;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int meth_pay_id
        {
            set { _meth_pay_id = value; }
            get { return _meth_pay_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string meth_pay_name
        {
            set { _meth_pay_name = value; }
            get { return _meth_pay_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool meth_is_ya
        {
            set { _meth_is_ya = value; }
            get { return _meth_is_ya; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool meth_is_jie
        {
            set { _meth_is_jie = value; }
            get { return _meth_is_jie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? meth_sort
        {
            set { _meth_sort = value; }
            get { return _meth_sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

	}
}

