using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class cprotocolPrice
    {
        public cprotocolPrice()
        { }
        #region Model
        private int _id;
        private string _accounts;
        private int? _roomtype;
        private int? _price;
        private int? _protoprice;
        private int? _mothprice;
        private float? _zdprice;
        private int? _lcprice;
        private int? _breakfast;
        private int? _commission;

        public int CpID { get; set; }
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
        public string Accounts
        {
            set { _accounts = value; }
            get { return _accounts; }
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
        public int? protoPrice
        {
            set { _protoprice = value; }
            get { return _protoprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? mothPrice
        {
            set { _mothprice = value; }
            get { return _mothprice; }
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
        public int? Breakfast
        {
            set { _breakfast = value; }
            get { return _breakfast; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? commission
        {
            set { _commission = value; }
            get { return _commission; }
        }
        #endregion Model
    }
}
