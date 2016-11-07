using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class cPost
    {
        public cPost()
        { }
        #region Model
        private int _id;
        private string _cpname;
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
        public string cpName
        {
            set { _cpname = value; }
            get { return _cpname; }
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
