using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class cDepartment
    {
        public cDepartment()
        { }
        #region Model
        private int _id;
        private string _cdname;
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
        public string cDName
        {
            set { _cdname = value; }
            get { return _cdname; }
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
