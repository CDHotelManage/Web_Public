using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class SuoRoom
    {
        public SuoRoom()
        { }
        #region Model
        private int _id;
        private string _suotype;
        private string _roomnumber;
        private string _suoma;
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
        public string SuoType
        {
            set { _suotype = value; }
            get { return _suotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoomNumber
        {
            set { _roomnumber = value; }
            get { return _roomnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SuoMa
        {
            set { _suoma = value; }
            get { return _suoma; }
        }
        #endregion Model
    }
}
