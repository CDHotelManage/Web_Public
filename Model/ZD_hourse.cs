using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdHotelManage.Model
{
    public class ZD_hourse
    {
        public ZD_hourse()
        { }
        #region Model
        private int _id;
        private TimeSpan? _latest;
        private int? _buffer;
        private int? _tixing;
        private TimeSpan? _beigin;
        private TimeSpan? _endtime;
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
        public TimeSpan? latest
        {
            set { _latest = value; }
            get { return _latest; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Buffer
        {
            set { _buffer = value; }
            get { return _buffer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tixing
        {
            set { _tixing = value; }
            get { return _tixing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? beigin
        {
            set { _beigin = value; }
            get { return _beigin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? endtime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        #endregion Model
    }
}
