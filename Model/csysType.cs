using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class csysType
    {
        public csysType()
        { }
        #region Model
        private int _id;
        private string _stname;
        private string _reamrk;
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
        public string stName
        {
            set { _stname = value; }
            get { return _stname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reamrk
        {
            set { _reamrk = value; }
            get { return _reamrk; }
        }
        #endregion Model
    }
}
