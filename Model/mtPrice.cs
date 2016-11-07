using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class mtPrice
    {
        public mtPrice()
        { }
        #region Model
        private int _id;
        private int? _mtid;
        private int? _roomtype;
        private int? _price;
        private int? _dayprice;
        private float? _zdprice;
        private int? _lcprice;
        private string _mothprice;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MTID
        {
            set { _mtid = value; }
            get { return _mtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RoomType
        {
            set { _roomtype = value; }
            get { return _roomtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Dayprice
        {
            set { _dayprice = value; }
            get { return _dayprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float? zdPrice
        {
            set { _zdprice = value; }
            get { return _zdprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? lcPrice
        {
            set { _lcprice = value; }
            get { return _lcprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mothPrice
        {
            set { _mothprice = value; }
            get { return _mothprice; }
        }
        #endregion Model
    }
}
