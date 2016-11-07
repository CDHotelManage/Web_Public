using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class customerState
    {
        public customerState()
        { }
        #region Model
        private int _id;
        private string _csname;
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
        public string csName
        {
            set { _csname = value; }
            get { return _csname; }
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
