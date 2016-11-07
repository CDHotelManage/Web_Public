using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class print
    {
        public print()
        { }
        #region Model
        private int _id;
        private string _pritname;
        private string _pricontent;
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
        public string pritName
        {
            set { _pritname = value; }
            get { return _pritname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string priContent
        {
            set { _pricontent = value; }
            get { return _pricontent; }
        }
        #endregion Model
    }
}
