using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    /// <summary>
    /// shopInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class shopInfo
    {
        public shopInfo()
        { }
        #region Model
        private string _id;
        private string _shop_name;
        private string _shop_lxman;
        private string _shop_telphone;
        private string _shop_chuanzen;
        private string _shop_province;
        private string _shop_city;
        private string _shop_area;
        private string _shop_address;
        private string _shop_x;
        private string _shop_y;
        private string _shop_remaker;
        private DateTime? _shop_date;
        /// <summary>
        /// 
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shop_Name
        {
            set { _shop_name = value; }
            get { return _shop_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shop_LxMan
        {
            set { _shop_lxman = value; }
            get { return _shop_lxman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_Telphone
        {
            set { _shop_telphone = value; }
            get { return _shop_telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_chuanzen
        {
            set { _shop_chuanzen = value; }
            get { return _shop_chuanzen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_Province
        {
            set { _shop_province = value; }
            get { return _shop_province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_City
        {
            set { _shop_city = value; }
            get { return _shop_city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_Area
        {
            set { _shop_area = value; }
            get { return _shop_area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_Address
        {
            set { _shop_address = value; }
            get { return _shop_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_x
        {
            set { _shop_x = value; }
            get { return _shop_x; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_y
        {
            set { _shop_y = value; }
            get { return _shop_y; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_Remaker
        {
            set { _shop_remaker = value; }
            get { return _shop_remaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Shop_date
        {
            set { _shop_date = value; }
            get { return _shop_date; }
        }
        #endregion Model

    }
}
