using System;
namespace CdHotelManage.Model
{
    /// <summary>
    /// member:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class member
    {
        public member()
        { }
        #region Model
        private string _mid;
        private string _name;
        private bool _sex;
        private int? _zjtype;
        private string _zjnumber;
        private int? _mtype;
        private int? _sales;
        private string _phone;
        private DateTime? _baithday;
        private string _pwd;
        private string _likes;
        private string _address;
        private string _ramrek;
        private int? _integration;
        private int? _integradh;
        private int? _integradj;
        private int? _stored;
        private int? _statid;

        private DateTime? addDate;

        public DateTime? AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }

        public DateTime? XqTime  { get; set; }

        public string AddUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Mid
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Zjtype
        {
            set { _zjtype = value; }
            get { return _zjtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZjNumber
        {
            set { _zjnumber = value; }
            get { return _zjnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Mtype
        {
            set { _mtype = value; }
            get { return _mtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sales
        {
            set { _sales = value; }
            get { return _sales; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Baithday
        {
            set { _baithday = value; }
            get { return _baithday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Likes
        {
            set { _likes = value; }
            get { return _likes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ramrek
        {
            set { _ramrek = value; }
            get { return _ramrek; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Integration
        {
            set { _integration = value; }
            get { return _integration; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IntegraDh
        {
            set { _integradh = value; }
            get { return _integradh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IntegraDj
        {
            set { _integradj = value; }
            get { return _integradj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Stored
        {
            set { _stored = value; }
            get { return _stored; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Statid
        {
            set { _statid = value; }
            get { return _statid; }
        }
        #endregion Model

    }
}

