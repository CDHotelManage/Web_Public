using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class memberState
    {
        public memberState()
        { }
        #region Model
        private int? _msid;
        private string _title;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int? msID
        {
            set { _msid = value; }
            get { return _msid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}
